using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;
using BussinessAccessLayer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ClosedXML.Excel;
using MaterialSkin;
using MaterialSkin.Controls;
using QRCoder;

namespace QuanLyPhongGYMv1
{
    public partial class Form1 : MaterialForm
    {
        #region Các trường và dịch vụ

        private readonly CustomersService customersServices = new CustomersService();
        private readonly TrainerServices trainerServices = new TrainerServices();
        private readonly InvoicesServices invoicesServices = new InvoicesServices();
        private readonly MemberShipServices membershipServices = new MemberShipServices();



        // Biến lưu instance UserControl Lịch Tập.
        private LichTap lichTapform;

        private int editingRowIndex = -1;

        #endregion

        #region Constructor và sự kiện Load form
        // Khởi tạo các thành phần giao diện.
        public Form1()
        {
            InitializeComponent();

            this.Load += Form1_Load;
            editCustomerButton.Click += editCustomerButton_Click;
            editInvoicesButton.Click += editInvoicesButton_Click;
            dataGridViewCustomer.CellClick += dataGridViewCustomer_CellClick;
            dataGridViewInvoices.CellClick += dataGridViewInvoices_CellClick;
        }

        // Xử lý khi form được load lần đầu.
        // - Ẩn header tab
        // - Tải dữ liệu ban đầu
        // - Khởi tạo điều khiển Lịch Tập
        private void Form1_Load(object sender, EventArgs e)
        {
            HideTabHeaders();          // Ẩn phần header của TabControl (nếu bạn muốn custom giao diện)
            LoadInitialData();         // Đổ dữ liệu gốc (danh sách khách hàng, hóa đơn…) lên grid
            InitializeLichTapControl();// Khởi tạo hoặc load UserControl “Lịch Tập” vào tab tương ứng
        }


        #endregion

        #region Xử lý TextBox & Giao diện

        // Kích hoạt các TextBox và control liên quan đến khách hàng để có thể chỉnh sửa
        private void EnableTextBoxesCustomer()
        {
            textNameCustomer.ReadOnly = false;       // Cho phép nhập tên khách hàng
            textSDTCustomer.ReadOnly = false;        // Cho phép nhập số điện thoại
            startDateCustomer.Enabled = true;        // Cho phép thay đổi ngày bắt đầu
            comboBoxViewCustomer.Enabled = true;     // Cho phép chọn trạng thái xem khách hàng

            textNameCustomer.BackColor = Color.White;        // Đổi màu nền để nhận biết đang ở chế độ sửa
            textSDTCustomer.BackColor = Color.White;
        }

        // Kích hoạt control liên quan đến hóa đơn để có thể chỉnh sửa
        private void EnableTextBoxesInvoices()
        {
            startDateInvoices.ReadOnly = false;      // Cho phép nhập/chỉnh sửa ngày hóa đơn

            startDateInvoices.BackColor = Color.White;      // Đổi màu nền để dễ nhận biết
        }

        private void EnableTextBoxesTrainer()
        {
            textBoxNameTrainer.ReadOnly = false;     // Cho phép nhập tên
            textSDTTrainer.ReadOnly = false;         // Cho phép nhập số điện thoại
            luongtextTrainer.ReadOnly = false;       // Cho phép nhập lương

            textBoxNameTrainer.BackColor = Color.White;      // Đổi màu nền để dễ nhận biết
            textSDTTrainer.BackColor = Color.White;
            luongtextTrainer.BackColor = Color.White;
        }

        // Vô hiệu hóa các TextBox và control khách hàng khi không ở chế độ sửa
        private void DisableTextBoxesCustomer()
        {
            textNameCustomer.ReadOnly = true;        // Khóa không cho nhập tên
            textSDTCustomer.ReadOnly = true;         // Khóa không cho nhập số điện thoại
            startDateCustomer.Enabled = false;       // Khóa không cho thay đổi ngày
            comboBoxViewCustomer.Enabled = false;    // Khóa không cho chọn trạng thái

            textNameCustomer.BackColor = SystemColors.Control;   // Thiết lập màu nền mặc định của control
            textSDTCustomer.BackColor = SystemColors.Control;
        }

        // Vô hiệu hóa control hóa đơn khi không ở chế độ sửa
        private void DisableTextBoxesInvocies()
        {
            startDateInvoices.ReadOnly = true;       // Khóa không cho chỉnh sửa ngày trong hóa đơn

            startDateInvoices.BackColor = SystemColors.Control;  // Trả về màu nền mặc định
        }

        // Đặt lại giao diện form khách hàng về trạng thái ban đầu
        // - Hiển thị lại nút Sửa
        // - Ẩn nút Lưu
        // - Vô hiệu hóa TextBox
        // - (Tuỳ chọn) Xóa vị trí hàng đang sửa

        private void DiagnosticsTextBoxesTrainer() {
            textBoxNameTrainer.ReadOnly = true;        // Khóa không cho nhập tên
            textSDTTrainer.ReadOnly = true;         // Khóa không cho nhập số điện thoại
            luongtextTrainer.ReadOnly = true;       // Khóa không cho nhập lương

            textBoxNameTrainer.BackColor = SystemColors.Control;      // Trả về màu nền mặc định
            textSDTTrainer.BackColor = SystemColors.Control;
            luongtextTrainer.BackColor = SystemColors.Control;
        }
        private void ResetFormCustomer(bool clearEditingRow = true)
        {
            editCustomerButton.Visible = true;      // Hiển thị nút Sửa
            saveEditCustomer.Visible = false;       // Ẩn nút Lưu
            DisableTextBoxesCustomer();             // Khóa TextBox

            if (clearEditingRow)
                editingRowIndex = -1;               // Đặt lại chỉ số hàng đang sửa
        }

        // Đặt lại giao diện form hóa đơn về trạng thái ban đầu
        // - Hiển thị lại nút Sửa
        // - Ẩn nút Lưu
        // - Vô hiệu hóa control
        // - (Tuỳ chọn) Xóa vị trí hàng đang sửa
        private void ResetFormInvoices(bool clearEditingRow = true)
        {
            editInvoicesButton.Visible = true;      // Hiển thị nút Sửa hóa đơn
            saveEditViewInvoices.Visible = false;   // Ẩn nút Lưu
            DisableTextBoxesInvocies();             // Khóa control

            if (clearEditingRow)
                editingRowIndex = -1;               // Đặt lại chỉ số hàng đang sửa
        }

        private void ResetFormTrainer(bool clearEditingRow = true)
        {
            editTrainerButton.Visible = true;       // Hiển thị nút Sửa
            luuButtonTrainer.Visible = false;        // Ẩn nút Lưu
            DiagnosticsTextBoxesTrainer();          // Khóa TextBox

            if (clearEditingRow)
                editingRowIndex = -1;               // Đặt lại chỉ số hàng đang sửa
        }


        #endregion

        #region Cấu hình Tab
        /// Ẩn header mặc định của TabControl để dùng navigation bằng nút riêng.
        private void HideTabHeaders()
        {
            tabTest.Appearance = TabAppearance.FlatButtons;
            tabTest.ItemSize = new Size(0, 1);
            tabTest.SizeMode = TabSizeMode.Fixed;
        }
        #endregion

        #region Tải dữ liệu khởi tạo
        // Tải dữ liệu cho tab mặc định (Khách hàng).
        // Có thể thêm các hàm Load khác nếu cần.
        private void LoadInitialData()
        {
            LoadCustomer();
        }
        #endregion

        #region Khởi tạo điều khiển Lịch Tập
        //Tạo và docking UserControl Lịch Tập vào tab tương ứng.
        private void InitializeLichTapControl()
        {
            lichTapform = new LichTap();
            lichTapform.Dock = DockStyle.Fill;
            tabLichTap.Controls.Add(lichTapform);
        }
        #endregion

        #region Các phương thức Load dữ liệu
        /// <summary>
        /// Tải danh sách khách hàng kèm gói tập vào DataGridView.
        /// </summary>
        private void LoadCustomer()
        {
            // Lấy dữ liệu từ Business
            DataTable dt = customersServices.LayTatCaKhachHangWithPackage();

            // Xóa dữ liệu cũ và đặt font Unicode
            dataGridViewCustomer.Rows.Clear();
            dataGridViewCustomer.Font = new Font("Segoe UI", 10);

            // Thêm dòng mới
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    dataGridViewCustomer.Rows.Add(
                        row["CustomerFullName"].ToString(),
                        row["CustomerPhoneNumber"].ToString(),
                        Convert.ToDateTime(row["CustomerStartDate"])  // chuyển sang kiểu ngày
                            .ToString("yyyy-MM-dd"),
                        row["PackageName"].ToString(),
                        row["CustomerID"]
                    );
                }
            }
            else
            {
                // Hiển thị thông báo nếu không có dữ liệu
                MessageBox.Show("Không có dữ liệu khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Load
            editCustomerButton.Visible = true;
            saveEditCustomer.Visible = false;
        }

        // Tải danh sách huấn luyện viên vào DataGridView.
        private void LoadTrainers()
        {
            DataTable dt = trainerServices.LayTatCaTrainer();
            datagridviewTrainer.Rows.Clear();
            datagridviewTrainer.Font = new Font("Segoe UI", 10);

            foreach (DataRow row in dt.Rows)
            {
                datagridviewTrainer.Rows.Add(
                    row["FullName"].ToString(),
                    row["PhoneNumber"].ToString(),
                    // Hiển thị định dạng tiền VND
                    Convert.ToDecimal(row["Salary"]).ToString("N0") + " VND",
                    row["TrainerID"]
                );
            }
        }

        // Tải danh sách hóa đơn vào DataGridView.
        private void LoadInvoices()
        {
            try
            {
                DataSet ds = invoicesServices.LayTatCaHoaDon();
                dataGridViewInvoices.Rows.Clear();
                dataGridViewInvoices.Font = new Font("Segoe UI", 10);

                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridViewInvoices.Rows.Add(
                            row["FullName"].ToString(),
                            row["PhoneNumber"].ToString(),
                            Convert.ToDateTime(row["InvoiceDate"]).ToString("yyyy-MM-dd"),
                            Convert.ToDecimal(row["TotalAmount"]).ToString("N0") + " VND",
                            row["InvoiceID"]
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                // Ghi log vào console để debug
                Console.WriteLine("Lỗi khi tải hóa đơn: " + ex.Message);
            }
        }

        // Tải danh sách gói tập (từ view) vào DataGridView.
        private void LoadMembershipPackages()
        {
            dataGridViewGoiTap.Rows.Clear();
            dataGridViewGoiTap.Font = new Font("Segoe UI", 10);
            dataGridViewGoiTap.RowTemplate.Height = 98;

            // Cấu hình độ rộng các cột
            dataGridViewGoiTap.Columns[0].Width = 100;
            dataGridViewGoiTap.Columns[1].Width = 100;
            dataGridViewGoiTap.Columns[2].Width = 100;
            dataGridViewGoiTap.Columns[3].Width = 100;
            dataGridViewGoiTap.Columns[4].Width = 300;

            dataGridViewGoiTap.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewGoiTap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DataTable dt = membershipServices.layMembershipPackagesFromView();
            foreach (DataRow row in dt.Rows)
            {
                dataGridViewGoiTap.Rows.Add(
                    row["PackageName"].ToString(),
                    row["Description"].ToString(),
                    string.Format("{0:N0} VND", row["Price"]),
                    row["DurationText"].ToString(),
                    row["Details"].ToString()
                );
            }
        }
        #endregion

        #region Xử lý sự kiện nút điều hướng

        // Chuyển tab và load dữ liệu tương ứng.
        private void customer_Click(object sender, EventArgs e) => SwitchTab(tabCustomer, LoadCustomer);
        private void invoices_Click(object sender, EventArgs e) => SwitchTab(tabInvoices, LoadInvoices);
        private void mp_Click(object sender, EventArgs e) => SwitchTab(tabMembership, LoadMembershipPackages);
        private void trainer_Click(object sender, EventArgs e) => SwitchTab(tabTrainer, LoadTrainers);
        private void lichTap_Click(object sender, EventArgs e) => SwitchTab(tabLichTap, () => lichTapform.LichTap_Load(sender, e));

        // Chuyển tab và gọi hàm load dữ liệu.
        private void SwitchTab(TabPage tabPage, Action loadAction)
        {
            tabTest.SelectedTab = tabPage;
            loadAction();
        }
        #endregion

        #region Tìm kiếm Functions
        // Tìm khách hàng theo số điện thoại và hiển thị thông tin.
        private void searchCustomer_Click(object sender, EventArgs e)
        {
            string phoneNumber = textSearchCustomer.Text.Trim();
            if (string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataSet customer = customersServices.LayKhachHangTheoSoDienThoai(phoneNumber);
                if (customer != null && customer.Tables[0].Rows.Count > 0)
                {
                    DataRow row = customer.Tables[0].Rows[0];
                    textNameCustomer.Text = row["FullName"].ToString();
                    textSDTCustomer.Text = row["PhoneNumber"].ToString();
                    startDateCustomer.Text = Convert.ToDateTime(row["StartDate"]).ToString("yyyy-MM-dd");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi truy vấn dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tìm kiếm hóa đơn theo số điện thoại
        private void searchInvoices_Click(object sender, EventArgs e)
        {
            string phoneNumber = textSearchInvoices.Text.Trim();

            if (string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataSet invoices = invoicesServices.LayHoaDonTheoSoDienThoai(phoneNumber);

                if (invoices != null && invoices.Tables.Count > 0 && invoices.Tables[0].Rows.Count > 0)
                {
                    DataRow row = invoices.Tables[0].Rows[0];

                    textNameInvoices.Text = row["FullName"].ToString();
                    textSDTInvoices.Text = row["PhoneNumber"].ToString();
                    startDateInvoices.Text = Convert.ToDateTime(row["InvoiceDate"]).ToString("yyyy-MM-dd");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textNameInvoices.Text = "";
                    textSDTInvoices.Text = "";
                    startDateInvoices.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi truy vấn dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tìm kiếm huấn luyện viên theo số điện thoại
        private void searchTrainer_Click(object sender, EventArgs e)
        {
            string phoneNumber1 = textSearchtrainer.Text.Trim();

            if (string.IsNullOrEmpty(phoneNumber1))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable trainerTable = trainerServices.LayTrainerTheoSDT(phoneNumber1);

                if (trainerTable != null && trainerTable.Rows.Count > 0)
                {
                    DataRow row = trainerTable.Rows[0];

                    textBoxNameTrainer.Text = row["FullName"].ToString();
                    textSDTTrainer.Text = row["PhoneNumber"].ToString();


                    decimal salary = Convert.ToDecimal(row["Salary"]);
                    // ;ấy total của datagrid view
                    luongtextTrainer.Text  = row["Salary"].ToString();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy huấn luyện viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxNameTrainer.Text = "";
                    textBoxSDTTrainer.Text = "";
                    textSDTTrainer.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi truy vấn dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Sự kiện TextBox Click and Leave
        // Khi nhấp vào TextBox tìm kiếm huấn luyện viên, xóa dữ liệu placeholder
        private void textSearchtrainer_Click(object sender, EventArgs e)
        {
            if (textSearchtrainer.Text == "Nhập SĐT")
                textSearchtrainer.Text = "";
        }

        // Khi nhấp ra ngoài, trả về dữ liệu mặc định
        private void textSearchtrainer_Leave_1(object sender, EventArgs e)
        {
            if (textSearchtrainer.Text == "")
            {
                textSearchtrainer.Text = "Nhập SĐT";
            }
        }

        // Khi nhấp vào TextBox tìm kiếm hóa đơn, xóa dữ liệu placeholder
        private void textSearchInvoices_Click(object sender, EventArgs e)
        {
            if (textSearchInvoices.Text == "Nhập SĐT")
                textSearchInvoices.Text = "";
        }

        // Khi nhấp ra ngoài, trả về dữ liệu mặc định
        private void textSearchInvoices_Leave(object sender, EventArgs e)
        {
            if (textSearchInvoices.Text == "")
            {
                textSearchInvoices.Text = "Nhập SĐT";
            }
        }

        // Khi nhấp vào TextBox tìm kiếm khách hàng, xóa dữ liệu placeholder
        private void textSearchCustomer_Click(object sender, EventArgs e)
        {
            if (textSearchCustomer.Text == "Nhập SĐT")
                textSearchCustomer.Text = "";
        }

        // Khi nhấp ra ngoài, trả về dữ liệu mặc định
        private void textSearchCustomer_Leave(object sender, EventArgs e)
        {
            if (textSearchCustomer.Text == "")
            {
                textSearchCustomer.Text = "Nhập SĐT";
            }
        }
        #endregion

        #region Thêm/Xóa Functions
        // Mở form thêm khách hàng.
        private void addCustomer_Click(object sender, EventArgs e)
        {
            ThemHv themHvForm = new ThemHv();
            themHvForm.ShowDialog();
            LoadCustomer();
        }

        // Xóa khách hàng đã chọn sau khi xác nhận, dữ liệu liên quan sẽ bị xóa cascade.
        private void removeCustomer_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustomer.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hội viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int index = dataGridViewCustomer.SelectedRows[0].Index;
            string fullName = dataGridViewCustomer.Rows[index].Cells["FullName"].Value.ToString();
            string phone = dataGridViewCustomer.Rows[index].Cells["PhoneNumber"].Value.ToString();

            DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa '{fullName}'?", "Xác nhận xóa",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string err = string.Empty;
                bool deleted = customersServices.XoaKhachHang(ref err, fullName, phone);
                if (deleted)
                {
                    LoadCustomer();
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Xóa thất bại: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        // Mở form thêm huấn luyện viên.
        private void addTrainer_Click_1(object sender, EventArgs e)
        {
            themTrainer form = new themTrainer();
            form.ShowDialog();
            LoadTrainers();
        }

        // Xóa huấn luyện viên
        private void removeTrainer_Click_1(object sender, EventArgs e)
        {
            if (datagridviewTrainer.SelectedRows.Count == 0 && datagridviewTrainer.SelectedCells.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn huấn luyện viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rowIndex = datagridviewTrainer.SelectedRows.Count > 0 ?
                           datagridviewTrainer.SelectedRows[0].Index :
                           datagridviewTrainer.SelectedCells[0].RowIndex;

            if (rowIndex < 0 || rowIndex >= datagridviewTrainer.Rows.Count)
            {
                MessageBox.Show("Vui lòng chọn huấn luyện viên hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            object idValue = datagridviewTrainer.Rows[rowIndex].Cells["IDTrainer"].Value;
            if (idValue == null || !int.TryParse(idValue.ToString(), out int trainerId))
            {
                MessageBox.Show("Không thể xác định TrainerID!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string fullName = datagridviewTrainer.Rows[rowIndex].Cells["FullNameTrainer"].Value.ToString();

            DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa huấn luyện viên '{fullName}'?",
                                                  "Xác nhận xóa",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string error = "";
                    bool isDeleted = trainerServices.XoaTrainer(trainerId, ref error);

                    if (isDeleted)
                    {
                        MessageBox.Show("Xóa huấn luyện viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadTrainers(); // Làm mới danh sách
                    }
                    else
                    {
                        MessageBox.Show($"Không thể xóa huấn luyện viên. Chi tiết lỗi: {error}", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Mở form thêm hóa đơn
        private void addInvoices_Click(object sender, EventArgs e)
        {
            themInvoices form = new themInvoices();
            form.ShowDialog();
            LoadInvoices();
        }

        // Xóa hóa đơn
        private void removeInvoices_Click(object sender, EventArgs e)
        {
            if (dataGridViewInvoices.SelectedRows.Count == 0 && dataGridViewInvoices.SelectedCells.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rowIndex = dataGridViewInvoices.SelectedRows.Count > 0 ?
                           dataGridViewInvoices.SelectedRows[0].Index :
                           dataGridViewInvoices.SelectedCells[0].RowIndex;

            if (rowIndex < 0 || rowIndex >= dataGridViewInvoices.Rows.Count)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cellValue = dataGridViewInvoices.Rows[rowIndex].Cells["InvoicesID"].Value;
            if (cellValue == null || !int.TryParse(cellValue.ToString(), out int invoiceId))
            {
                MessageBox.Show("Mã hóa đơn không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Bạn có chắc muốn xóa hóa đơn #{invoiceId}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            string loi = "";
            try
            {
                bool isDeleted = invoicesServices.XoaHoaDon(ref loi, invoiceId);
                if (isDeleted)
                {
                    MessageBox.Show("Xóa hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadInvoices();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại: " + loi, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Export to Excel
        // Xuất danh sách khách hàng ra file Excel
        private void excelCustomerButton_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustomer.Rows.Count > 0)
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            var ws = wb.Worksheets.Add("DanhSachKhachHang");

                            // Ghi tiêu đề cột
                            for (int i = 0; i < dataGridViewCustomer.Columns.Count; i++)
                            {
                                ws.Cell(1, i + 1).Value = dataGridViewCustomer.Columns[i].HeaderText;
                            }

                            // Ghi dữ liệu
                            for (int i = 0; i < dataGridViewCustomer.Rows.Count; i++)
                            {
                                for (int j = 0; j < dataGridViewCustomer.Columns.Count; j++)
                                {
                                    ws.Cell(i + 2, j + 1).Value = dataGridViewCustomer.Rows[i].Cells[j].Value?.ToString();
                                }
                            }

                            // Tự động điều chỉnh kích thước cột và hàng
                            ws.Columns().AdjustToContents();
                            ws.Rows().AdjustToContents();
                            wb.SaveAs(sfd.FileName);

                            MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Xuất danh sách hóa đơn ra file Excel
        private void excelInvoicesButton_Click(object sender, EventArgs e)
        {
            if (dataGridViewInvoices.Rows.Count > 0)
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            var ws = wb.Worksheets.Add("DanhSachHoaDon");

                            // Ghi tiêu đề cột
                            for (int i = 0; i < dataGridViewInvoices.Columns.Count; i++)
                            {
                                ws.Cell(1, i + 1).Value = dataGridViewInvoices.Columns[i].HeaderText;
                            }

                            // Ghi dữ liệu
                            for (int i = 0; i < dataGridViewInvoices.Rows.Count; i++)
                            {
                                for (int j = 0; j < dataGridViewInvoices.Columns.Count; j++)
                                {
                                    ws.Cell(i + 2, j + 1).Value = dataGridViewInvoices.Rows[i].Cells[j].Value?.ToString();
                                }
                            }

                            // Tự động điều chỉnh kích thước cột và hàng
                            ws.Columns().AdjustToContents();
                            ws.Rows().AdjustToContents();
                            wb.SaveAs(sfd.FileName);

                            MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Xuất danh sách huấn luyện viên ra file Excel
        private void excelTrainerButton_Click(object sender, EventArgs e)
        {
            if (datagridviewTrainer.Rows.Count > 0)
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            var ws = wb.Worksheets.Add("DanhSachKhachHang");

                            // Ghi tiêu đề cột
                            for (int i = 0; i < datagridviewTrainer.Columns.Count; i++)
                            {
                                ws.Cell(1, i + 1).Value = datagridviewTrainer.Columns[i].HeaderText;
                            }

                            // Ghi dữ liệu
                            for (int i = 0; i < datagridviewTrainer.Rows.Count; i++)
                            {
                                for (int j = 0; j < datagridviewTrainer.Columns.Count; j++)
                                {
                                    ws.Cell(i + 2, j + 1).Value = datagridviewTrainer.Rows[i].Cells[j].Value?.ToString();
                                }
                            }
                            // 🔥 Điều chỉnh kích thước cột và hàng
                            ws.Columns().AdjustToContents(); // Tự chỉnh chiều rộng cột
                            ws.Rows().AdjustToContents();    // Tự chỉnh chiều cao hàng
                            wb.SaveAs(sfd.FileName);

                            MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Sự kiện nhấp datagridview và nút chỉnh sửa/lưu của Customer - Invoices 

        // Custonmer
        private void dataGridViewCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewCustomer.Rows.Count)
            {
                var row = dataGridViewCustomer.Rows[e.RowIndex];

                if (row.Cells[0].Value == null || row.Cells[1].Value == null || row.Cells[2].Value == null)
                {
                    MessageBox.Show("Dữ liệu không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                textNameCustomer.Text = row.Cells[0].Value.ToString();
                textSDTCustomer.Text = row.Cells[1].Value.ToString();
                startDateCustomer.Text = Convert.ToDateTime(row.Cells[2].Value).ToString("yyyy-MM-dd");
                DataTable dt = membershipServices.LayTatCaGoiTap();
                comboBoxViewCustomer.Items.Clear();

                foreach (DataRow row1 in dt.Rows)
                {
                    comboBoxViewCustomer.Items.Add(row1["PackageName"].ToString());
                }
                comboBoxViewCustomer.Text = row.Cells[3].Value.ToString();

                editingRowIndex = e.RowIndex;
                DisableTextBoxesCustomer();
                editCustomerButton.Text = "Chỉnh sửa";
            }
        }

        private void editCustomerButton_Click(object sender, EventArgs e)
        {
            if (editCustomerButton.Text == "Chỉnh sửa")
            {
                comboBoxViewCustomer.BackColor = Color.Black;
                editCustomerButton.Text = "Lưu";
                EnableTextBoxesCustomer();
            }
            else 
            {
                //ẩn nút chỉnh sửa hiển thị nút save
                editCustomerButton.Visible = false;
                saveEditCustomer.Visible = true;
            }
        }

        private void saveEditCustomer_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(textNameCustomer.Text) || string.IsNullOrWhiteSpace(textSDTCustomer.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            try
            {
                // Lấy dòng đang chỉnh sửa
                DataGridViewRow row = dataGridViewCustomer.Rows[editingRowIndex];

                // Lấy CustomerID từ cột "CustomerID"
                if (!int.TryParse(row.Cells["CustomerID"].Value?.ToString(), out int customerID))
                {
                    MessageBox.Show("Không thể lấy CustomerID!");
                    return;
                }

                // Parse ngày bắt đầu
                if (!DateTime.TryParse(startDateCustomer.Text, out DateTime startDate))
                {
                    MessageBox.Show("Ngày bắt đầu không hợp lệ!");
                    return;
                }

                // Lấy MembershipID 
                int? membershipID = membershipServices.LayMembershipIDTheoTenGoi(comboBoxViewCustomer.Text);

                string err = string.Empty;

                // Gọi phương thức cập nhật
                bool updated = customersServices.CapNhatKhachHang(
                    ref err,
                    customerID,
                    textNameCustomer.Text,
                    textSDTCustomer.Text,
                    startDate,
                    membershipID
                );

                if (updated)
                {
                    LoadCustomer(); 
                    ResetFormCustomer(clearEditingRow: false);


                    comboBoxViewCustomer.ForeColor = SystemColors.ScrollBar;
                    MessageBox.Show("Cập nhật thông tin khách hàng thành công!");
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật. Lỗi: " + err);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật khách hàng: " + ex.Message);
            }

        }

        // Invoices
        private void dataGridViewInvoices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewInvoices.Rows.Count)
            {
                var row = dataGridViewInvoices.Rows[e.RowIndex];

                if (row.Cells[0].Value == null || row.Cells[1].Value == null || row.Cells[2].Value == null || row.Cells[3].Value == null)
                {
                    MessageBox.Show("Dữ liệu không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //Lấy ra 
                textNameInvoices.Text = row.Cells[0].Value.ToString();
                textSDTInvoices.Text = row.Cells[1].Value.ToString();
                startDateInvoices.Text = Convert.ToDateTime(row.Cells[2].Value).ToString("yyyy-MM-dd");
                textTongHoaDon.Text = row.Cells[3].Value.ToString();

                editingRowIndex = e.RowIndex;
                DisableTextBoxesInvocies();
                editInvoicesButton.Text = "Chỉnh sửa";
            }
        }
        private void editInvoicesButton_Click(object sender, EventArgs e)
        {
            if (editInvoicesButton.Text == "Chỉnh sửa")
            {
                editInvoicesButton.Text = "Lưu";
                EnableTextBoxesInvoices();
            }
            else
            {
                //ẩn nút chỉnh sửa hiển thị nút save
                editInvoicesButton.Visible = false;
                saveEditViewInvoices.Visible = true;
            }
        }

        private void saveEditViewInvoices_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(textNameInvoices.Text) ||
                string.IsNullOrWhiteSpace(textSDTInvoices.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            // 2. Đảm bảo đã chọn dòng để sửa
            if (editingRowIndex < 0 || editingRowIndex >= dataGridViewInvoices.Rows.Count)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để chỉnh sửa!");
                return;
            }

            try
            {
                // 3. Lấy dòng đang chỉnh sửa
                DataGridViewRow row = dataGridViewInvoices.Rows[editingRowIndex];

                // 4. Lấy mã hóa đơn từ cột tương ứng
                int invoiceID = Convert.ToInt32(row.Cells["InvoicesID"].Value);

                // 5. Lấy CustomerID qua service (theo InvoiceID)
                int customerID = customersServices.LayMaKhachHangTheoMaHoaDon(invoiceID);

                // 6. Lấy số tiền đã format trong TextBox (bỏ " VND" và dấu phẩy)
                decimal tongTien = Convert.ToDecimal(
                    textTongHoaDon.Text
                        .Replace(" VND", "")
                        .Replace(",", "")
                        .Trim()
                );

                // 7. Parse ngày hóa đơn
                if (!DateTime.TryParse(startDateInvoices.Text, out DateTime startDateInvoice))
                {
                    MessageBox.Show("Ngày hóa đơn không hợp lệ!");
                    return;
                }

                // 8. Gọi phương thức cập nhật
                string err = string.Empty;
                bool updated = invoicesServices.CapNhatHoaDon(
                    ref err,
                    invoiceID,
                    customerID,
                    tongTien,
                    startDateInvoice
                );

                // 9. Kiểm tra kết quả
                if (updated)
                {
                    LoadInvoices();
                    // Giữ lại editingRowIndex nếu bạn muốn tiếp tục sửa dòng này
                    ResetFormInvoices(clearEditingRow: false);

                    MessageBox.Show("Cập nhật thông tin hóa đơn thành công!");
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật. Lỗi: " + err);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật hóa đơn: " + ex.Message);
            }
        }

        //Trainer
        private void datagridviewTrainer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < datagridviewTrainer.Rows.Count)
            {
                var row = datagridviewTrainer.Rows[e.RowIndex];

                if (row.Cells[0].Value == null || row.Cells[1].Value == null || row.Cells[2].Value == null)
                {
                    MessageBox.Show("Dữ liệu không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                textBoxNameTrainer.Text = row.Cells[0].Value.ToString();
                textSDTTrainer.Text = row.Cells[1].Value.ToString();
                luongtextTrainer.Text = row.Cells[2].Value.ToString();

                editingRowIndex = e.RowIndex;
                DiagnosticsTextBoxesTrainer();
                editTrainerButton.Text = "Chỉnh sửa";
            }

        }

        private void luuButtonTrainer_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(textBoxNameTrainer.Text) ||
                string.IsNullOrWhiteSpace(textSDTTrainer.Text) ||
                string.IsNullOrWhiteSpace(luongtextTrainer.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            // 2. Đảm bảo đã chọn dòng để sửa
            if (editingRowIndex < 0 || editingRowIndex >= datagridviewTrainer.Rows.Count)
            {
                MessageBox.Show("Vui lòng chọn huấn luyện viên để chỉnh sửa!");
                return;
            }

            try
            {
                // 3. Lấy dòng đang chỉnh sửa
                DataGridViewRow row = datagridviewTrainer.Rows[editingRowIndex];

                // 4. Lấy TrainerID từ cột tương ứng
                int trainerID = Convert.ToInt32(row.Cells["TrainerID"].Value);

                // 5. Lấy số tiền đã format trong TextBox (bỏ " VND" và dấu phẩy)
                decimal luong = Convert.ToDecimal(
                    luongtextTrainer.Text
                        .Replace(" VND", "")
                        .Replace(",", "")
                        .Trim()
                );

                // 6. Gọi phương thức cập nhật
                string err = string.Empty;
                bool updated = trainerServices.CapNhatTrainer(
                    trainerID,
                    textBoxNameTrainer.Text,
                    textSDTTrainer.Text,
                    luong,
                    ref err


                );

                // 7. Kiểm tra kết quả
                if (updated)
                {
                    LoadTrainers();
                    // Giữ lại editingRowIndex nếu bạn muốn tiếp tục sửa dòng này
                    ResetFormTrainer(clearEditingRow: false);

                    MessageBox.Show("Cập nhật thông tin huấn luyện viên thành công!");
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật. Lỗi: " + err);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật huấn luyện viên: " + ex.Message);
            }

        }

        private void editTrainerButton_Click(object sender, EventArgs e)
        {
            if (editTrainerButton.Text == "Chỉnh sửa")
            {
                editTrainerButton.Text = "Lưu";
                luuButtonTrainer.Visible = true;
                EnableTextBoxesTrainer();
            }
            else
            {
                //ẩn nút chỉnh sửa hiển thị nút save
                editTrainerButton.Visible = false;
                luuButtonTrainer.Visible = true;
            }

        }



        #endregion

        private void textNameCustomer_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
