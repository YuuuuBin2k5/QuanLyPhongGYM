using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinessAccessLayer;
using DataAccessLayer;

namespace QuanLyPhongGYMv1
{
    public partial class ThemHv : Form
    {
        private readonly CustomersService customersServices = new CustomersService();
        private readonly MemberShipServices membershipServices = new MemberShipServices();

        public ThemHv()
        {
            InitializeComponent();
        }

        private void ThemHLV_Load(object sender, EventArgs e)
        {
            DataTable dt = membershipServices.LayTatCaGoiTap();
            textGoiTapHv.Items.Clear();

            foreach (DataRow row in dt.Rows)
            {
                textGoiTapHv.Items.Add(row["PackageName"].ToString());
            }
        }

        private void saveCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                string fullName = textnameHv.Text.Trim();
                string phoneNumber = textSDTHv.Text.Trim();
                DateTime startDate = dateTimeHv.Value;
                string packageName = textGoiTapHv.Text.Trim();

                int? membershipID = membershipServices.LayMembershipIDTheoTenGoi(packageName);

                if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(phoneNumber))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string err = "";
                bool result = customersServices.ThemKhachHang(ref err, fullName, phoneNumber, startDate, membershipID);

                if (result)
                {
                    MessageBox.Show("Thêm hội viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể thêm hội viên.\nLỗi: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void huyCustomer_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form
        }
    }
}
