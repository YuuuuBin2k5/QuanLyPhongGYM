using BussinessAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCoder;


namespace QuanLyPhongGYMv1
{
    public partial class themInvoices : Form
    {
        private readonly CustomersService customersServices = new CustomersService();
        private readonly InvoicesServices invoicesServices = new InvoicesServices();

        public themInvoices()
        {
            InitializeComponent();
            dataGridViewHoaDontest.DataBindingComplete += DataGridViewHoaDontest_DataBindingComplete; // Đăng ký sự kiện DataBindingComplete
        }
        private void DataGridViewHoaDontest_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            CalculateAndDisplayTotalInvoiceAmount(); // Tính toán và hiển thị tổng hóa đơn
        }

        private void LoadInvoicesForCustomer(int customerId)
        {
            try
            {
                // Lấy thông tin gói tập (tên và giá) cho khách hàng từ stored procedure
                DataSet dtInvoices = invoicesServices.LayHoaDonTheoMaKhachHang(customerId);
                //xoa du lieu
                dataGridViewHoaDontest.DataSource = dtInvoices;

                // Nếu không có dữ liệu, thông báo và xóa DataGridView
                if (dtInvoices == null || dtInvoices.Tables.Count == 0 || dtInvoices.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Không có thông tin gói tập cho khách hàng này.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewHoaDontest.DataSource = null;
                    return;
                }

                // Cấu hình DataGridView để hiển thị thông tin gói tập
                dataGridViewHoaDontest.AutoGenerateColumns = false;
                dataGridViewHoaDontest.Columns.Clear();

                // Tạo cột hiển thị Tên gói
                DataGridViewTextBoxColumn colPackageName = new DataGridViewTextBoxColumn();
                colPackageName.Name = "PackageName";
                colPackageName.HeaderText = "Tên gói";
                colPackageName.DataPropertyName = "PackageName"; // Tên cột trả về từ stored procedure
                dataGridViewHoaDontest.Columns.Add(colPackageName);

                // Tạo cột hiển thị Giá gói
                DataGridViewTextBoxColumn colPackagePrice = new DataGridViewTextBoxColumn();
                colPackagePrice.Name = "PackagePrice";
                colPackagePrice.HeaderText = "Giá gói";
                colPackagePrice.DataPropertyName = "PackagePrice"; // Tên cột trả về từ stored procedure
                colPackagePrice.DefaultCellStyle.Format = "N2"; // Định dạng số với 2 chữ số thập phân nếu cần
                dataGridViewHoaDontest.Columns.Add(colPackagePrice);

                // Gán DataTable được trả về vào DataGridView
                dataGridViewHoaDontest.DataSource = dtInvoices.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin gói tập: " + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxKhachHang.SelectedItem is DataRowView drv)
            {
                int customerId = Convert.ToInt32(drv["CustomerID"]);
                string phone = drv["PhoneNumber"].ToString();

                textSDTHoaDon.Text = phone;
                LoadInvoicesForCustomer(customerId);
            }
        }


        private void themInvoices_Load(object sender, EventArgs e)
        {
            // 1. Lấy DataSet thay thế DataTable
            DataSet ds = customersServices.LayKhachHang();  // phương thức mới trả về DataSet
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];

                comboBoxKhachHang.DataSource = dt;
                comboBoxKhachHang.DisplayMember = "FullName";
                comboBoxKhachHang.ValueMember = "CustomerID";

                comboBoxKhachHang.SelectedIndexChanged += comboBoxKhachHang_SelectedIndexChanged;

                // Gọi 1 lần khi load
                comboBoxKhachHang.SelectedIndex = 0;

               //Khi vừa vào form tự động load hóa đơn cho khách hàng đầu tiên
                if (dt.Rows.Count > 0)
                {
                    int customerId = Convert.ToInt32(dt.Rows[0]["CustomerID"]);
                    string phone = dt.Rows[0]["PhoneNumber"].ToString();
                    textSDTHoaDon.Text = phone;
                    LoadInvoicesForCustomer(customerId);
                }
            }
        }


        private void CalculateAndDisplayTotalInvoiceAmount()
        {
            decimal totalAmount = 0;

            foreach (DataGridViewRow row in dataGridViewHoaDontest.Rows)
            {
                if (row.Cells["PackagePrice"].Value != null)
                {
                    decimal packagePrice = Convert.ToDecimal(row.Cells["PackagePrice"].Value);
                    totalAmount += packagePrice;
                }
            }

            tongHoaDon.Text = totalAmount.ToString("N0") + " VND";
            /*tongHoaDon.Text = totalAmount.ToString("F2", CultureInfo.InvariantCulture); // "C" format for currency*/
        }


        // Giả sử bạn lưu InvoiceID khi load/search hóa đơn, ví dụ:
        private int currentInvoiceId = 0;
        private void saveInvoices_Click(object sender, EventArgs e)
        {
            string error = string.Empty;
            int customerId = Convert.ToInt32(comboBoxKhachHang.SelectedValue);
            string customerName = comboBoxKhachHang.Text;
            string customerPhone = textSDTHoaDon.Text;
            decimal totalAmount = 0;
            DateTime startDate = DateTime.Now; // Ngày bắt đầu hóa đơn

            foreach (DataGridViewRow row in dataGridViewHoaDontest.Rows)
            {
                if (row.Cells["PackagePrice"].Value != null)
                {
                    decimal packagePrice = Convert.ToDecimal(row.Cells["PackagePrice"].Value);
                    totalAmount += packagePrice;
                }
            }

            // Kiểm tra nếu hóa đơn đã tồn tại
            if (invoicesServices.KiemTraHoaDonTonTai(customerId))
            {
                // Cập nhật hóa đơn
                if (invoicesServices.CapNhatHoaDon(ref error, currentInvoiceId, customerId, totalAmount, startDate))
                {
                    MessageBox.Show("Cập nhật hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật hóa đơn thất bại: " + error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Thêm hóa đơn mới
                if (invoicesServices.ThemHoaDon(ref error, customerId, customerName, customerPhone, totalAmount))
                {
                    MessageBox.Show("Thêm hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm hóa đơn thất bại: " + error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Đóng form sau khi lưu
            this.Close();
        }

        private void huyInvoices_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
