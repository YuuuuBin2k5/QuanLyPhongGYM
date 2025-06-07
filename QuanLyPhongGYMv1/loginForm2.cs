using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyPhongGYMv1
{
    public partial class loginForm2 : Form
    {
        public loginForm2()
        {
            InitializeComponent();

            // Placeholder text

            guna2TextBox1.ForeColor = Color.Gray;


            guna2TextBox2.ForeColor = Color.Gray;
            guna2TextBox2.UseSystemPasswordChar = false;
        }

        private void loginForm2_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.RememberMe)
            {
                guna2TextBox1.Text = Properties.Settings.Default.Username;
                guna2TextBox1.ForeColor = Color.Black;

                guna2TextBox2.Text = Properties.Settings.Default.Password;
                guna2TextBox2.ForeColor = Color.Black;
                guna2TextBox2.UseSystemPasswordChar = true;

                guna2ToggleSwitch1.Checked = true;
            }
            else
            {
                guna2TextBox1.Text = "username";
                guna2TextBox1.ForeColor = Color.Gray;

                guna2TextBox2.Text = "password";
                guna2TextBox2.ForeColor = Color.Gray;
                guna2TextBox2.UseSystemPasswordChar = false;

                guna2ToggleSwitch1.Checked = false;
            }
        }

        // Đăng nhập
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string username = guna2TextBox1.Text.Trim();
            string password = guna2TextBox2.Text;

            if (username == "admin" && password == "admin")
            {
                if (guna2ToggleSwitch1.Checked)
                {
                    Properties.Settings.Default.Username = username;
                    Properties.Settings.Default.Password = password;
                    Properties.Settings.Default.RememberMe = true;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.Username = "";
                    Properties.Settings.Default.Password = "";
                    Properties.Settings.Default.RememberMe = false;
                    Properties.Settings.Default.Save();
                }

                Form1 mainForm = new Form1();
                this.Hide();
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Username textbox click
        private void guna2TextBox1_Enter(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "username")
            {
                guna2TextBox1.Text = "";
                guna2TextBox1.ForeColor = Color.Black;
            }
        }

        private void guna2TextBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guna2TextBox1.Text))
            {
                guna2TextBox1.Text = "username";
                guna2TextBox1.ForeColor = Color.Gray;
            }
        }

        // Password textbox click
        private void guna2TextBox2_Enter(object sender, EventArgs e)
        {
            if (guna2TextBox2.Text == "password")
            {
                guna2TextBox2.Text = "";
                guna2TextBox2.ForeColor = Color.Black;
                guna2TextBox2.UseSystemPasswordChar = !guna2ToggleSwitch1.Checked;
            }
        }

        private void guna2TextBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guna2TextBox2.Text))
            {
                guna2TextBox2.Text = "password";
                guna2TextBox2.ForeColor = Color.Gray;
                guna2TextBox2.UseSystemPasswordChar = false;
            }
        }

        // Toggle hiện/ẩn mật khẩu
        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2TextBox2.Text != "password")
            {
                guna2TextBox2.UseSystemPasswordChar = !guna2ToggleSwitch1.Checked;
            }
        }
        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            // Nếu chưa cần xử lý gì thì để trống cũng được
        }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            // Nếu chưa cần xử lý gì thì để trống cũng được
        }

        private void loginForm2_Load_1(object sender, EventArgs e)
        {

        }

        //tài khoản khách
        private void label3_Click(object sender, EventArgs e)
        {
            Form1 mainForm = new Form1();
            this.Hide();
            mainForm.ShowDialog();
            this.Close();
        }
    }
}
