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
using BussinessAccessLayer;
using ClosedXML.Excel;
using DataAccessLayer;

namespace QuanLyPhongGYMv1
{
    public partial class LichTap : UserControl
    {
        private readonly CustomersService customersServices = new CustomersService();
        private readonly TrainerServices trainerServices = new TrainerServices();
        private readonly ScheduleServices scheduleServices = new ScheduleServices();

        // Để lưu ScheduleID của ô được chọn (nếu có)
        private int selectedScheduleId = 0;
        // Để lưu thời gian của ô được chọn (để dùng cho Edit)
        private DateTime selectedDateTime = DateTime.MinValue;
        private int selectedCustomerId;
        public LichTap()
        {
            InitializeComponent();
        }

        public void LichTap_Load(object sender, EventArgs e)
        {
            // 1. Tạo các hàng: từ 5:00 đến 20:00
            dgvSchedule.Rows.Clear();

            for (int hour = 5; hour <= 20; hour++)
            {
                int rowIndex = dgvSchedule.Rows.Add();
                dgvSchedule.Rows[rowIndex].HeaderCell.Value = hour + ":00";
            }
            dgvSchedule.RowHeadersWidth = 100;

            // 2. Tạo các cột nếu chưa có: 7 cột cho các ngày trong tuần (Monday -> Sunday)
            if (dgvSchedule.Columns.Count == 0)
            {
                string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
                foreach (string day in days)
                {
                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    col.HeaderText = day;
                    dgvSchedule.Columns.Add(col);
                }
            }



            // 3. Xác định thứ Hai của tuần hiện tại
            DateTime today = DateTime.Today;
            // Tính toán: nếu hôm nay là Chủ Nhật (0) thì muốn lấy thứ Hai của tuần trước hoặc xử lý riêng;
            // Ở đây, giả sử tuần bắt đầu từ Thứ Hai (DayOfWeek.Monday = 1)
            int diff = (int)today.DayOfWeek - (int)DayOfWeek.Monday;
            if (diff < 0) diff = 6; // Nếu hôm nay là Chủ Nhật (0), diff = -1 -> 6
            DateTime mondayOfWeek = today.AddDays(-diff);

            DataSet ds = customersServices.LayKhachHang();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];

                listKhachHang.DataSource = dt;
                listKhachHang.DisplayMember = "FullName";
                listKhachHang.ValueMember = "CustomerID";

                if (listKhachHang.SelectedIndex == -1 && listKhachHang.Items.Count > 0)
                    listKhachHang.SelectedIndex = 0;

                if (listKhachHang.SelectedValue != null && int.TryParse(listKhachHang.SelectedValue.ToString(), out int customerId))
                {
                    FillSchedule(customerId, mondayOfWeek);
                }
            }
            else
            {
                // Trường hợp không có khách hàng
                listKhachHang.DataSource = null;
            }
        }

        // Hàm này sẽ lấy lịch tập của khách hàng trong tuần và điền vào DataGridView
        private void FillSchedule(int customerId, DateTime mondayOfWeek)
        {
            // Xác định ngày Chủ Nhật của tuần (mondayOfWeek + 6)
            DateTime sundayOfWeek = mondayOfWeek.AddDays(6);

            // Lấy dữ liệu lịch tập của khách hàng trong tuần
            DataTable dt = scheduleServices.LayLichTapTheoTuan(customerId, mondayOfWeek, sundayOfWeek);

            // Duyệt qua từng ô trong DataGridView
            for (int row = 0; row < dgvSchedule.Rows.Count; row++)
            {
                // Lấy giờ từ Header (vd: "5:00" -> 5)
                string hourString = dgvSchedule.Rows[row].HeaderCell.Value.ToString();
                int hour = int.Parse(hourString.Split(':')[0]);

                for (int col = 0; col < dgvSchedule.Columns.Count; col++)
                {
                    // Tính ngày của cột hiện tại: thứ Hai + col (0->Monday, 1->Tuesday, ...)
                    DateTime cellDate = mondayOfWeek.AddDays(col).AddHours(hour);

                    // Tìm dòng tương ứng trong DataTable
                    DataRow[] foundRows = dt.Select($"TrainingDate >= '{cellDate:yyyy-MM-dd HH:mm:ss}' AND TrainingDate < '{cellDate.AddHours(1):yyyy-MM-dd HH:mm:ss}'");

                    if (foundRows.Length > 0)
                    {
                        string trainerId = foundRows[0]["TrainerID"].ToString();
                        int scheduleId = Convert.ToInt32(foundRows[0]["ScheduleID"]);

                        // Lấy thông tin Trainer theo ID
                        DataTable trainerInfo = trainerServices.LayTrainerTheoID(trainerId);

                        string trainerFullName = (trainerInfo.Rows.Count > 0)
                            ? trainerInfo.Rows[0]["FullName"].ToString()
                            : "Không rõ";

                        dgvSchedule[col, row].Value = $"{trainerFullName}";
                        dgvSchedule[col, row].Tag = scheduleId; // Gán ScheduleID vào ô
                    }
                    else
                    {
                        // Nếu không có lịch, ô trống
                        dgvSchedule[col, row].Value = "";
                        dgvSchedule[col, row].Tag = null;
                    }
                }
            }
        }



        private void dgvSchedule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra chỉ số hàng và cột hợp lệ
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                try
                {
                    // Kiểm tra xem row header có chứa giá trị giờ không
                    if (dgvSchedule.Rows[e.RowIndex].HeaderCell.Value == null)
                    {
                        MessageBox.Show("Không tìm thấy thông tin giờ của hàng.");
                        return;
                    }
                    // Lấy giờ từ header của hàng (ví dụ: "9:00")
                    string hourStr = dgvSchedule.Rows[e.RowIndex].HeaderCell.Value.ToString();
                    int hour = int.Parse(hourStr.Split(':')[0]);

                    // Mapping từ tên cột sang offset ngày (Monday = 0, Tuesday = 1, ...)
                    Dictionary<string, int> dayMapping = new Dictionary<string, int>()
                    {
                        { "Monday", 0 },
                        { "Tuesday", 1 },
                        { "Wednesday", 2 },
                        { "Thursday", 3 },
                        { "Friday", 4 },
                        { "Saturday", 5 },
                        { "Sunday", 6 }
                    };

                    // Kiểm tra cột có header không
                    if (string.IsNullOrEmpty(dgvSchedule.Columns[e.ColumnIndex].HeaderText))
                    {
                        MessageBox.Show("Không tìm thấy thông tin ngày của cột.");
                        return;
                    }

                    // Lấy tên của cột hiện tại (ví dụ: "Monday")
                    string dayText = dgvSchedule.Columns[e.ColumnIndex].HeaderText;
                    int dayOffset = dayMapping.ContainsKey(dayText) ? dayMapping[dayText] : 0;

                    // Tính ngày thứ Hai của tuần hiện tại (bạn cần định nghĩa hàm GetMondayOfCurrentWeek() theo logic của bạn)
                    DateTime mondayOfWeek = GetMondayOfCurrentWeek();

                    // Tính thời gian dựa trên ngày và giờ
                    DateTime selectedTime = mondayOfWeek.AddDays(dayOffset).AddHours(hour);
                    this.selectedDateTime = selectedTime;


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi chọn lịch: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                DataGridViewCell selectedCell = dgvSchedule.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (selectedCell.Tag != null)
                {
                    selectedScheduleId = Convert.ToInt32(selectedCell.Tag);
                }

            }
        }

        // Hàm tính thứ Hai của tuần hiện tại
        private DateTime GetMondayOfCurrentWeek()
        {
            DateTime today = DateTime.Today;
            int diff = (int)today.DayOfWeek - (int)DayOfWeek.Monday;
            if (diff < 0) diff = 6;
            return today.AddDays(-diff);
        }
        private void addLichTap_Click(object sender, EventArgs e)
        {
            // Nếu selectedDateTime đã được thiết lập (khác DateTime.MinValue) thì dùng nó, ngược lại dùng DateTime.Now
            DateTime defaultTime = (this.selectedDateTime != DateTime.MinValue) ? this.selectedDateTime : DateTime.Now;

            // Lấy CustomerID từ listKhachHang
            int defaultCustomerId = Convert.ToInt32(listKhachHang.SelectedValue);

            // Khởi tạo form nhập lịch tập với thời gian và khách hàng mặc định
            nhapLichTap form = new nhapLichTap(defaultTime, defaultCustomerId);
            form.ShowDialog();

            // Cập nhật lại lịch tập sau khi thêm xong
            FillSchedule(defaultCustomerId, GetMondayOfCurrentWeek());

            // (Tùy chọn) Reset lại selectedDateTime sau khi thêm
            this.selectedDateTime = DateTime.MinValue;
        }

        private void deleteLichTap_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có ô nào được chọn không
            if (dgvSchedule.SelectedCells.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ô có lịch tập để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy ô đầu tiên được chọn
            DataGridViewCell selectedCell = dgvSchedule.SelectedCells[0];

            // Kiểm tra nếu ô có Tag chứa ScheduleID
            if (selectedCell.Tag == null)
            {
                MessageBox.Show("Ô được chọn không có lịch tập nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy ScheduleID từ Tag của ô
            int scheduleId;
            if (!int.TryParse(selectedCell.Tag.ToString(), out scheduleId) || scheduleId == 0)
            {
                MessageBox.Show("Lịch tập không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hiển thị xác nhận xóa
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa lịch tập này?", "Xác nhận xóa",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    string loi = "";
                    bool result = scheduleServices.XoaLichTap(scheduleId, ref loi);

                    if (result)
                    {
                        MessageBox.Show("Xóa lịch tập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        int defaultCustomerId = Convert.ToInt32(listKhachHang.SelectedValue);
                        FillSchedule(defaultCustomerId, GetMondayOfCurrentWeek());
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa lịch tập!\nLỗi: " + loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa lịch: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void listKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listKhachHang.SelectedValue != null)
            {
                if (int.TryParse(listKhachHang.SelectedValue.ToString(), out selectedCustomerId))
                {
                    // Xác định thứ Hai của tuần hiện tại
                    DateTime today = DateTime.Today;
                    int diff = (int)today.DayOfWeek - (int)DayOfWeek.Monday;
                    if (diff < 0) diff = 6;
                    DateTime mondayOfWeek = today.AddDays(-diff);

                    // Cập nhật lịch tập cho khách hàng được chọn
                    FillSchedule(selectedCustomerId, mondayOfWeek);
                }
            }
        }



        private void excelSchedule_Click(object sender, EventArgs e)
        {
            if (dgvSchedule.Rows.Count > 0)
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            var ws = wb.Worksheets.Add("LichTap");

                            // --- Ghi tiêu đề: cột đầu tiên là "Giờ", sau đó là các thứ ---
                            ws.Cell(1, 1).Value = "Giờ";
                            ws.Cell(1, 1).Style.Font.Bold = true;

                            for (int col = 0; col < dgvSchedule.Columns.Count; col++)
                            {
                                ws.Cell(1, col + 2).Value = dgvSchedule.Columns[col].HeaderText;
                                ws.Cell(1, col + 2).Style.Font.Bold = true;
                            }

                            // --- Ghi dữ liệu từng hàng ---
                            for (int row = 0; row < dgvSchedule.Rows.Count; row++)
                            {
                                // Ghi giờ vào cột đầu tiên
                                var timeHeader = dgvSchedule.Rows[row].HeaderCell.Value?.ToString();
                                ws.Cell(row + 2, 1).Value = timeHeader ?? string.Empty;

                                for (int col = 0; col < dgvSchedule.Columns.Count; col++)
                                {
                                    var value = dgvSchedule.Rows[row].Cells[col].Value;
                                    var cell = ws.Cell(row + 2, col + 2);

                                    if (value != null)
                                    {
                                        if (value is DateTime)
                                            cell.Value = (DateTime)value;
                                        else if (value is double || value is int)
                                            cell.Value = Convert.ToDouble(value);
                                        else
                                            cell.Value = value.ToString();
                                    }
                                    else
                                    {
                                        cell.Value = string.Empty;
                                    }
                                }
                            }

                            // Tự chỉnh kích thước cột và hàng cho đẹp
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

    }
}
