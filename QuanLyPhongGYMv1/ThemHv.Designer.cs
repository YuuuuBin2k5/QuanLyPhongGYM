namespace QuanLyPhongGYMv1
{
    partial class ThemHv
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThemHv));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimeHv = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.textGoiTapHv = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveCustomer = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.textSDTHv = new Guna.UI2.WinForms.Guna2TextBox();
            this.textnameHv = new Guna.UI2.WinForms.Guna2TextBox();
            this.huyCustomer = new Guna.UI2.WinForms.Guna2GradientButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.huyCustomer);
            this.panel1.Controls.Add(this.dateTimeHv);
            this.panel1.Controls.Add(this.textGoiTapHv);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.saveCustomer);
            this.panel1.Controls.Add(this.guna2Panel1);
            this.panel1.Controls.Add(this.textSDTHv);
            this.panel1.Controls.Add(this.textnameHv);
            this.panel1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Location = new System.Drawing.Point(247, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 601);
            this.panel1.TabIndex = 31;
            // 
            // dateTimeHv
            // 
            this.dateTimeHv.Checked = true;
            this.dateTimeHv.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dateTimeHv.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dateTimeHv.Location = new System.Drawing.Point(27, 478);
            this.dateTimeHv.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dateTimeHv.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateTimeHv.Name = "dateTimeHv";
            this.dateTimeHv.Size = new System.Drawing.Size(185, 36);
            this.dateTimeHv.TabIndex = 37;
            this.dateTimeHv.Value = new System.DateTime(2025, 4, 18, 17, 1, 47, 261);
            // 
            // textGoiTapHv
            // 
            this.textGoiTapHv.BackColor = System.Drawing.Color.Transparent;
            this.textGoiTapHv.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.textGoiTapHv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.textGoiTapHv.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textGoiTapHv.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textGoiTapHv.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textGoiTapHv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.textGoiTapHv.ItemHeight = 30;
            this.textGoiTapHv.Location = new System.Drawing.Point(235, 478);
            this.textGoiTapHv.Name = "textGoiTapHv";
            this.textGoiTapHv.Size = new System.Drawing.Size(269, 36);
            this.textGoiTapHv.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(198, 329);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 26);
            this.label1.TabIndex = 35;
            this.label1.Text = "Thêm hội viên";
            // 
            // saveCustomer
            // 
            this.saveCustomer.Animated = true;
            this.saveCustomer.AutoRoundedCorners = true;
            this.saveCustomer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.saveCustomer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.saveCustomer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.saveCustomer.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.saveCustomer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.saveCustomer.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.saveCustomer.ForeColor = System.Drawing.Color.White;
            this.saveCustomer.Location = new System.Drawing.Point(74, 530);
            this.saveCustomer.Name = "saveCustomer";
            this.saveCustomer.Size = new System.Drawing.Size(180, 45);
            this.saveCustomer.TabIndex = 34;
            this.saveCustomer.Text = "Xác nhận thêm";
            this.saveCustomer.Click += new System.EventHandler(this.saveCustomer_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackgroundImage = global::QuanLyPhongGYMv1.Properties.Resources._313dcca7f22b5bce15523235329bc5621;
            this.guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2Panel1.Location = new System.Drawing.Point(-2, -2);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(532, 328);
            this.guna2Panel1.TabIndex = 30;
            // 
            // textSDTHv
            // 
            this.textSDTHv.Animated = true;
            this.textSDTHv.AutoRoundedCorners = true;
            this.textSDTHv.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textSDTHv.DefaultText = "";
            this.textSDTHv.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textSDTHv.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textSDTHv.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textSDTHv.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textSDTHv.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textSDTHv.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textSDTHv.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textSDTHv.IconLeft = global::QuanLyPhongGYMv1.Properties.Resources.mobile_icon_png_23741;
            this.textSDTHv.Location = new System.Drawing.Point(142, 425);
            this.textSDTHv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textSDTHv.Name = "textSDTHv";
            this.textSDTHv.PlaceholderText = "SĐT hội viên";
            this.textSDTHv.SelectedText = "";
            this.textSDTHv.Size = new System.Drawing.Size(259, 33);
            this.textSDTHv.TabIndex = 32;
            // 
            // textnameHv
            // 
            this.textnameHv.Animated = true;
            this.textnameHv.AutoRoundedCorners = true;
            this.textnameHv.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textnameHv.DefaultText = "";
            this.textnameHv.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textnameHv.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textnameHv.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textnameHv.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textnameHv.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textnameHv.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textnameHv.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textnameHv.IconLeft = global::QuanLyPhongGYMv1.Properties.Resources.head_icon_65221;
            this.textnameHv.Location = new System.Drawing.Point(142, 370);
            this.textnameHv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textnameHv.Name = "textnameHv";
            this.textnameHv.PlaceholderText = "Tên hội viên";
            this.textnameHv.SelectedText = "";
            this.textnameHv.Size = new System.Drawing.Size(259, 33);
            this.textnameHv.TabIndex = 31;
            // 
            // huyCustomer
            // 
            this.huyCustomer.Animated = true;
            this.huyCustomer.AutoRoundedCorners = true;
            this.huyCustomer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.huyCustomer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.huyCustomer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.huyCustomer.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.huyCustomer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.huyCustomer.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.huyCustomer.ForeColor = System.Drawing.Color.White;
            this.huyCustomer.Location = new System.Drawing.Point(288, 530);
            this.huyCustomer.Name = "huyCustomer";
            this.huyCustomer.Size = new System.Drawing.Size(180, 45);
            this.huyCustomer.TabIndex = 38;
            this.huyCustomer.Text = "Hủy";
            this.huyCustomer.Click += new System.EventHandler(this.huyCustomer_Click);
            // 
            // ThemHv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::QuanLyPhongGYMv1.Properties.Resources._53e801fcbab23aaae1158b81bfe64a943;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1027, 633);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ThemHv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm Khách Hàng";
            this.Load += new System.EventHandler(this.ThemHLV_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2GradientButton saveCustomer;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2TextBox textSDTHv;
        private Guna.UI2.WinForms.Guna2TextBox textnameHv;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateTimeHv;
        private Guna.UI2.WinForms.Guna2ComboBox textGoiTapHv;
        private Guna.UI2.WinForms.Guna2GradientButton huyCustomer;
    }
}