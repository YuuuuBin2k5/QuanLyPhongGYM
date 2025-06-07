using BussinessAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongGYMv1
{
    public partial class themTrainer : Form
    {
        private readonly TrainerServices trainerServices = new TrainerServices();
        public themTrainer()
        {
            InitializeComponent();
        }

        private void saveTrainer_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Lấy dữ liệu từ các TextBox
                string trainerFullName = textnameTrainer.Text.Trim();
                string trainerPhoneNumber = textSDTTrainer.Text.Trim();

                if (!decimal.TryParse(textLuongTrainer.Text.Trim(), out decimal trainerSalary))
                {
                    MessageBox.Show("Mức lương không hợp lệ.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Gọi DAL với ref error
                
                string error = "";
                bool isAdded = trainerServices.ThemTrainer(
                    trainerFullName,
                    trainerPhoneNumber,
                    trainerSalary,
                    ref error
                );

                // 3. Kiểm tra kết quả
                if (isAdded)
                {
                    MessageBox.Show("Huấn luyện viên đã được thêm thành công!", "Thành công",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi thêm huấn luyện viên: " + error, "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
