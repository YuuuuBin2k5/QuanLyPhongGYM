using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BussinessAccessLayer;
namespace QuanLyPhongGYMv1
{
    public partial class nhapLichTap : Form
    {
        private readonly CustomersService customersServices = new CustomersService();
        private readonly TrainerServices trainerServices = new TrainerServices();
        private readonly ScheduleServices scheduleServices = new ScheduleServices();

        private readonly DateTime trainingDate;
        private readonly int scheduleId; // 0 nếu thêm mới, khác nếu sửa
        private readonly int defaultCustomerId; // Khách hàng mặc định

        // Constructor cho thêm mới lịch tập
        public nhapLichTap(DateTime defaultTime, int defaultCustomerId)
        {
            InitializeComponent();
            this.trainingDate = defaultTime;
            this.defaultCustomerId = defaultCustomerId;
            this.scheduleId = 0; // Thêm mới
            InitializeForm();
            LoadScheduleData();
        }


        private void InitializeForm()
        {
            // Thiết lập DateTimePicker mặc định:
            // Nếu trainingDate không phải DateTime.MinValue (đã được tính toán từ cell click), thì sử dụng nó,
            // ngược lại sử dụng thời gian hiện tại.
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd MMM yyyy HH:mm";
            dateTimePicker1.Value = (trainingDate != DateTime.MinValue) ? trainingDate : DateTime.Now;

            // Nạp danh sách khách hàng
            DataSet dsCus = customersServices.LayKhachHang();
            if (dsCus != null && dsCus.Tables.Count > 0 && dsCus.Tables[0].Rows.Count > 0)
            {
                DataTable dtCus = dsCus.Tables[0];

                comboBox1.DataSource = dtCus;
                comboBox1.DisplayMember = "FullName";
                comboBox1.ValueMember = "CustomerID";

                // Tự động chọn khách hàng mặc định nếu có
                bool hasDefaultCustomer = dtCus.AsEnumerable()
                    .Any(row => row.Field<int>("CustomerID") == defaultCustomerId);
                if (hasDefaultCustomer)
                {
                    comboBox1.SelectedValue = defaultCustomerId;
                }
                else
                {
                    comboBox1.SelectedIndex = 0;
                }
            }
            else
            {
                comboBox1.DataSource = null;
                MessageBox.Show("Không có khách hàng nào được nạp!");
            }


            // Nạp danh sách huấn luyện viên
            DataTable dtHLV = trainerServices.LayTatCaTrainer();
            if (dtHLV != null && dtHLV.Rows.Count > 0)
            {
                comboBox2.DataSource = dtHLV;
                comboBox2.DisplayMember = "FullName";
                comboBox2.ValueMember = "TrainerID";
                comboBox2.SelectedIndex = 0; // Mặc định chọn HLV đầu tiên
            }
            else
            {
                comboBox2.DataSource = null;
                MessageBox.Show("Không có huấn luyện viên nào được nạp!");
            }

            // Xóa ghi chú
            ghiChu.Text = "";
        }

        private void LoadScheduleData()
        {
            if (scheduleId == 0) return; // Nếu đang thêm mới, không cần tải dữ liệu

            // Truy vấn database để lấy thông tin lịch tập
            DataTable dt = scheduleServices.LayLichTapTheoID(scheduleId);
            if (dt.Rows.Count > 0)
            {
                // Lấy dữ liệu từ bảng
                DataRow row = dt.Rows[0];
                dateTimePicker1.Value = Convert.ToDateTime(row["TrainingTime"]);
                comboBox1.SelectedValue = Convert.ToInt32(row["CustomerID"]);
                comboBox2.SelectedValue = Convert.ToInt32(row["TrainerID"]);
                ghiChu.Text = row["Notes"].ToString();
            }
        }


        private void saveLichTapButton_Click(object sender, EventArgs e)
        {
            try
            {
                int customerId = Convert.ToInt32(comboBox1.SelectedValue);
                int trainerId = Convert.ToInt32(comboBox2.SelectedValue);
                // Thời gian lấy từ DateTimePicker có định dạng "dd MMM yyyy HH:mm"
                DateTime dt = dateTimePicker1.Value;

                string loi = "";

                if (scheduleId == 0)
                {
                    // Thêm lịch tập mới
                    bool success = scheduleServices.ThemLichTap(customerId, trainerId, dt, ref loi);
                    if (success)
                    {
                        MessageBox.Show("Thêm lịch tập thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm lịch tập!\nLỗi: " + loi);
                    }
                }
                else
                {
                    // Nếu sửa, bạn cần tạo và gọi một stored procedure sp_UpdateWorkoutSchedule (không được trình bày ở đây)
                    // Ví dụ: db.UpdateWorkoutSchedule(scheduleId, customerId, trainerId, dt);
                    MessageBox.Show("Sửa lịch tập thành công!");
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void huyLichTap_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void nhapLichTap_Load(object sender, EventArgs e)
        {

        }
        private void saveLichTap_Click(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void saveTrainer_Click(object sender, EventArgs e)
        {

        }

        
    }
}
