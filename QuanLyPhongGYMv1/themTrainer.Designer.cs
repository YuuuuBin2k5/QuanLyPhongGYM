namespace QuanLyPhongGYMv1
{
    partial class themTrainer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(themTrainer));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.saveTrainer = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.textLuongTrainer = new Guna.UI2.WinForms.Guna2TextBox();
            this.textSDTTrainer = new Guna.UI2.WinForms.Guna2TextBox();
            this.textnameTrainer = new Guna.UI2.WinForms.Guna2TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.saveTrainer);
            this.panel1.Controls.Add(this.guna2Panel1);
            this.panel1.Controls.Add(this.textLuongTrainer);
            this.panel1.Controls.Add(this.textSDTTrainer);
            this.panel1.Controls.Add(this.textnameTrainer);
            this.panel1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Location = new System.Drawing.Point(284, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 601);
            this.panel1.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(162, 329);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 26);
            this.label1.TabIndex = 35;
            this.label1.Text = "Thêm HLV";
            // 
            // saveTrainer
            // 
            this.saveTrainer.Animated = true;
            this.saveTrainer.AutoRoundedCorners = true;
            this.saveTrainer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.saveTrainer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.saveTrainer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.saveTrainer.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.saveTrainer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.saveTrainer.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.saveTrainer.ForeColor = System.Drawing.Color.White;
            this.saveTrainer.Location = new System.Drawing.Point(142, 539);
            this.saveTrainer.Name = "saveTrainer";
            this.saveTrainer.Size = new System.Drawing.Size(180, 45);
            this.saveTrainer.TabIndex = 34;
            this.saveTrainer.Text = "Xác nhận thêm";
            this.saveTrainer.Click += new System.EventHandler(this.saveTrainer_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackgroundImage = global::QuanLyPhongGYMv1.Properties.Resources.b68fb7dfe0636a8da1afad02f10e1e65;
            this.guna2Panel1.Location = new System.Drawing.Point(-2, -2);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(532, 328);
            this.guna2Panel1.TabIndex = 30;
            this.guna2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // textLuongTrainer
            // 
            this.textLuongTrainer.Animated = true;
            this.textLuongTrainer.AutoRoundedCorners = true;
            this.textLuongTrainer.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textLuongTrainer.DefaultText = "";
            this.textLuongTrainer.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textLuongTrainer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textLuongTrainer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textLuongTrainer.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textLuongTrainer.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textLuongTrainer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textLuongTrainer.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textLuongTrainer.IconLeft = global::QuanLyPhongGYMv1.Properties.Resources.money_icons_61231;
            this.textLuongTrainer.Location = new System.Drawing.Point(121, 487);
            this.textLuongTrainer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textLuongTrainer.Name = "textLuongTrainer";
            this.textLuongTrainer.PlaceholderText = "Mức Lương";
            this.textLuongTrainer.SelectedText = "";
            this.textLuongTrainer.Size = new System.Drawing.Size(229, 33);
            this.textLuongTrainer.TabIndex = 33;
            // 
            // textSDTTrainer
            // 
            this.textSDTTrainer.Animated = true;
            this.textSDTTrainer.AutoRoundedCorners = true;
            this.textSDTTrainer.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textSDTTrainer.DefaultText = "";
            this.textSDTTrainer.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textSDTTrainer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textSDTTrainer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textSDTTrainer.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textSDTTrainer.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textSDTTrainer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textSDTTrainer.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textSDTTrainer.IconLeft = global::QuanLyPhongGYMv1.Properties.Resources.mobile_icon_png_23741;
            this.textSDTTrainer.Location = new System.Drawing.Point(121, 429);
            this.textSDTTrainer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textSDTTrainer.Name = "textSDTTrainer";
            this.textSDTTrainer.PlaceholderText = "SĐT HLV";
            this.textSDTTrainer.SelectedText = "";
            this.textSDTTrainer.Size = new System.Drawing.Size(229, 33);
            this.textSDTTrainer.TabIndex = 32;
            // 
            // textnameTrainer
            // 
            this.textnameTrainer.Animated = true;
            this.textnameTrainer.AutoRoundedCorners = true;
            this.textnameTrainer.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textnameTrainer.DefaultText = "";
            this.textnameTrainer.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textnameTrainer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textnameTrainer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textnameTrainer.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textnameTrainer.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textnameTrainer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textnameTrainer.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textnameTrainer.IconLeft = global::QuanLyPhongGYMv1.Properties.Resources.head_icon_65221;
            this.textnameTrainer.Location = new System.Drawing.Point(121, 375);
            this.textnameTrainer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textnameTrainer.Name = "textnameTrainer";
            this.textnameTrainer.PlaceholderText = "Tên HLV";
            this.textnameTrainer.SelectedText = "";
            this.textnameTrainer.Size = new System.Drawing.Size(229, 33);
            this.textnameTrainer.TabIndex = 31;
            // 
            // themTrainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QuanLyPhongGYMv1.Properties.Resources._53e801fcbab23aaae1158b81bfe64a94;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1027, 633);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "themTrainer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm Huấn Luyện Viên";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2TextBox textLuongTrainer;
        private Guna.UI2.WinForms.Guna2TextBox textSDTTrainer;
        private Guna.UI2.WinForms.Guna2TextBox textnameTrainer;
        private Guna.UI2.WinForms.Guna2GradientButton saveTrainer;
        private System.Windows.Forms.Label label1;
    }
}