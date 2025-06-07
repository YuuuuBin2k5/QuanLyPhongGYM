namespace QuanLyPhongGYMv1
{
    partial class themInvoices
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(themInvoices));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewHoaDontest = new System.Windows.Forms.DataGridView();
            this.huyInvoices = new Guna.UI2.WinForms.Guna2GradientButton();
            this.saveInvoices = new Guna.UI2.WinForms.Guna2GradientButton();
            this.tongHoaDon = new Guna.UI2.WinForms.Guna2TextBox();
            this.textSDTHoaDon = new Guna.UI2.WinForms.Guna2TextBox();
            this.comboBoxKhachHang = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHoaDontest)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dataGridViewHoaDontest);
            this.panel1.Controls.Add(this.huyInvoices);
            this.panel1.Controls.Add(this.saveInvoices);
            this.panel1.Controls.Add(this.tongHoaDon);
            this.panel1.Controls.Add(this.textSDTHoaDon);
            this.panel1.Controls.Add(this.comboBoxKhachHang);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.guna2Panel1);
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(247, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 601);
            this.panel1.TabIndex = 31;
            // 
            // dataGridViewHoaDontest
            // 
            this.dataGridViewHoaDontest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewHoaDontest.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewHoaDontest.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewHoaDontest.ColumnHeadersHeight = 29;
            this.dataGridViewHoaDontest.Location = new System.Drawing.Point(5, 468);
            this.dataGridViewHoaDontest.Name = "dataGridViewHoaDontest";
            this.dataGridViewHoaDontest.RowHeadersWidth = 51;
            this.dataGridViewHoaDontest.RowTemplate.Height = 24;
            this.dataGridViewHoaDontest.Size = new System.Drawing.Size(263, 108);
            this.dataGridViewHoaDontest.TabIndex = 42;
            // 
            // huyInvoices
            // 
            this.huyInvoices.Animated = true;
            this.huyInvoices.AutoRoundedCorners = true;
            this.huyInvoices.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.huyInvoices.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.huyInvoices.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.huyInvoices.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.huyInvoices.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.huyInvoices.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.huyInvoices.ForeColor = System.Drawing.Color.White;
            this.huyInvoices.Location = new System.Drawing.Point(405, 488);
            this.huyInvoices.Name = "huyInvoices";
            this.huyInvoices.Size = new System.Drawing.Size(120, 72);
            this.huyInvoices.TabIndex = 41;
            this.huyInvoices.Text = "Hủy";
            this.huyInvoices.Click += new System.EventHandler(this.huyInvoices_Click);
            // 
            // saveInvoices
            // 
            this.saveInvoices.Animated = true;
            this.saveInvoices.AutoRoundedCorners = true;
            this.saveInvoices.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.saveInvoices.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.saveInvoices.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.saveInvoices.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.saveInvoices.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.saveInvoices.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.saveInvoices.ForeColor = System.Drawing.Color.White;
            this.saveInvoices.Location = new System.Drawing.Point(279, 488);
            this.saveInvoices.Name = "saveInvoices";
            this.saveInvoices.Size = new System.Drawing.Size(120, 72);
            this.saveInvoices.TabIndex = 40;
            this.saveInvoices.Text = "Xác nhận thanh toán";
            this.saveInvoices.Click += new System.EventHandler(this.saveInvoices_Click);
            // 
            // tongHoaDon
            // 
            this.tongHoaDon.Animated = true;
            this.tongHoaDon.AutoRoundedCorners = true;
            this.tongHoaDon.BackgroundImage = global::QuanLyPhongGYMv1.Properties.Resources.money_icons_61232;
            this.tongHoaDon.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tongHoaDon.DefaultText = "";
            this.tongHoaDon.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tongHoaDon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tongHoaDon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tongHoaDon.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tongHoaDon.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tongHoaDon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tongHoaDon.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tongHoaDon.Location = new System.Drawing.Point(286, 422);
            this.tongHoaDon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tongHoaDon.Name = "tongHoaDon";
            this.tongHoaDon.PlaceholderText = "Tổng tiền";
            this.tongHoaDon.SelectedText = "";
            this.tongHoaDon.Size = new System.Drawing.Size(164, 39);
            this.tongHoaDon.TabIndex = 39;
            // 
            // textSDTHoaDon
            // 
            this.textSDTHoaDon.Animated = true;
            this.textSDTHoaDon.AutoRoundedCorners = true;
            this.textSDTHoaDon.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textSDTHoaDon.DefaultText = "";
            this.textSDTHoaDon.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textSDTHoaDon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textSDTHoaDon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textSDTHoaDon.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textSDTHoaDon.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textSDTHoaDon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textSDTHoaDon.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textSDTHoaDon.IconLeft = global::QuanLyPhongGYMv1.Properties.Resources.mobile_icon_png_23742;
            this.textSDTHoaDon.Location = new System.Drawing.Point(70, 422);
            this.textSDTHoaDon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textSDTHoaDon.Name = "textSDTHoaDon";
            this.textSDTHoaDon.PlaceholderText = "SĐT khách hàng";
            this.textSDTHoaDon.SelectedText = "";
            this.textSDTHoaDon.Size = new System.Drawing.Size(198, 39);
            this.textSDTHoaDon.TabIndex = 37;
            // 
            // comboBoxKhachHang
            // 
            this.comboBoxKhachHang.AutoRoundedCorners = true;
            this.comboBoxKhachHang.BackColor = System.Drawing.Color.Transparent;
            this.comboBoxKhachHang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxKhachHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKhachHang.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBoxKhachHang.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBoxKhachHang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxKhachHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboBoxKhachHang.ItemHeight = 30;
            this.comboBoxKhachHang.Location = new System.Drawing.Point(70, 370);
            this.comboBoxKhachHang.Name = "comboBoxKhachHang";
            this.comboBoxKhachHang.Size = new System.Drawing.Size(380, 36);
            this.comboBoxKhachHang.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(150, 341);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 26);
            this.label1.TabIndex = 35;
            this.label1.Text = "Thanh toán hóa đơn";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackgroundImage = global::QuanLyPhongGYMv1.Properties.Resources.f226d572737a4b4a071b6808bbd6add6__1_;
            this.guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2Panel1.Location = new System.Drawing.Point(-2, -2);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(532, 328);
            this.guna2Panel1.TabIndex = 30;
            // 
            // themInvoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = global::QuanLyPhongGYMv1.Properties.Resources._53e801fcbab23aaae1158b81bfe64a942;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1027, 633);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "themInvoices";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm Hóa Đơn";
            this.Load += new System.EventHandler(this.themInvoices_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHoaDontest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2ComboBox comboBoxKhachHang;
        private Guna.UI2.WinForms.Guna2TextBox tongHoaDon;
        private Guna.UI2.WinForms.Guna2TextBox textSDTHoaDon;
        private Guna.UI2.WinForms.Guna2GradientButton saveInvoices;
        private Guna.UI2.WinForms.Guna2GradientButton huyInvoices;
        private System.Windows.Forms.DataGridView dataGridViewHoaDontest;
    }
}