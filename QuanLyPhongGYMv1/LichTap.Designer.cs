namespace QuanLyPhongGYMv1
{
    partial class LichTap
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
            this.dgvSchedule = new System.Windows.Forms.DataGridView();
            this.Monday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tuesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wednesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thursday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Friday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saturday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sunday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteLichTap = new System.Windows.Forms.Button();
            this.addLichTap = new System.Windows.Forms.Button();
            this.listKhachHang = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.excelSchedule = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSchedule
            // 
            this.dgvSchedule.AllowUserToAddRows = false;
            this.dgvSchedule.AllowUserToDeleteRows = false;
            this.dgvSchedule.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSchedule.ColumnHeadersHeight = 29;
            this.dgvSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Monday,
            this.Tuesday,
            this.Wednesday,
            this.Thursday,
            this.Friday,
            this.Saturday,
            this.Sunday});
            this.dgvSchedule.Location = new System.Drawing.Point(0, 80);
            this.dgvSchedule.Name = "dgvSchedule";
            this.dgvSchedule.ReadOnly = true;
            this.dgvSchedule.RowHeadersWidth = 51;
            this.dgvSchedule.RowTemplate.Height = 24;
            this.dgvSchedule.Size = new System.Drawing.Size(1150, 435);
            this.dgvSchedule.TabIndex = 0;
            this.dgvSchedule.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSchedule_CellClick);
            // 
            // Monday
            // 
            this.Monday.HeaderText = "Monday";
            this.Monday.MinimumWidth = 6;
            this.Monday.Name = "Monday";
            this.Monday.ReadOnly = true;
            // 
            // Tuesday
            // 
            this.Tuesday.HeaderText = "Tuesday";
            this.Tuesday.MinimumWidth = 6;
            this.Tuesday.Name = "Tuesday";
            this.Tuesday.ReadOnly = true;
            // 
            // Wednesday
            // 
            this.Wednesday.HeaderText = "Wednesday";
            this.Wednesday.MinimumWidth = 6;
            this.Wednesday.Name = "Wednesday";
            this.Wednesday.ReadOnly = true;
            // 
            // Thursday
            // 
            this.Thursday.HeaderText = "Thursday";
            this.Thursday.MinimumWidth = 6;
            this.Thursday.Name = "Thursday";
            this.Thursday.ReadOnly = true;
            // 
            // Friday
            // 
            this.Friday.HeaderText = "Friday";
            this.Friday.MinimumWidth = 6;
            this.Friday.Name = "Friday";
            this.Friday.ReadOnly = true;
            // 
            // Saturday
            // 
            this.Saturday.HeaderText = "Saturday";
            this.Saturday.MinimumWidth = 6;
            this.Saturday.Name = "Saturday";
            this.Saturday.ReadOnly = true;
            // 
            // Sunday
            // 
            this.Sunday.HeaderText = "Sunday";
            this.Sunday.MinimumWidth = 6;
            this.Sunday.Name = "Sunday";
            this.Sunday.ReadOnly = true;
            // 
            // deleteLichTap
            // 
            this.deleteLichTap.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteLichTap.Location = new System.Drawing.Point(832, 19);
            this.deleteLichTap.Name = "deleteLichTap";
            this.deleteLichTap.Size = new System.Drawing.Size(130, 42);
            this.deleteLichTap.TabIndex = 1;
            this.deleteLichTap.Text = "Xóa";
            this.deleteLichTap.UseVisualStyleBackColor = true;
            this.deleteLichTap.Click += new System.EventHandler(this.deleteLichTap_Click);
            // 
            // addLichTap
            // 
            this.addLichTap.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addLichTap.Location = new System.Drawing.Point(666, 19);
            this.addLichTap.Name = "addLichTap";
            this.addLichTap.Size = new System.Drawing.Size(130, 42);
            this.addLichTap.TabIndex = 2;
            this.addLichTap.Text = "Thêm";
            this.addLichTap.UseVisualStyleBackColor = true;
            this.addLichTap.Click += new System.EventHandler(this.addLichTap_Click);
            // 
            // listKhachHang
            // 
            this.listKhachHang.FormattingEnabled = true;
            this.listKhachHang.Location = new System.Drawing.Point(252, 19);
            this.listKhachHang.Name = "listKhachHang";
            this.listKhachHang.Size = new System.Drawing.Size(379, 24);
            this.listKhachHang.TabIndex = 5;
            this.listKhachHang.SelectedIndexChanged += new System.EventHandler(this.listKhachHang_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Khách hàng";
            // 
            // excelSchedule
            // 
            this.excelSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.excelSchedule.Location = new System.Drawing.Point(994, 19);
            this.excelSchedule.Name = "excelSchedule";
            this.excelSchedule.Size = new System.Drawing.Size(130, 42);
            this.excelSchedule.TabIndex = 7;
            this.excelSchedule.Text = "Xuất Excel";
            this.excelSchedule.UseVisualStyleBackColor = true;
            this.excelSchedule.Click += new System.EventHandler(this.excelSchedule_Click);
            // 
            // LichTap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.BackgroundImage = global::QuanLyPhongGYMv1.Properties.Resources._333b704f5d130b6a3152f5a07e79c899;
            this.Controls.Add(this.excelSchedule);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listKhachHang);
            this.Controls.Add(this.addLichTap);
            this.Controls.Add(this.deleteLichTap);
            this.Controls.Add(this.dgvSchedule);
            this.Name = "LichTap";
            this.Size = new System.Drawing.Size(1150, 538);
            this.Load += new System.EventHandler(this.LichTap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSchedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tuesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wednesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thursday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Friday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saturday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sunday;
        private System.Windows.Forms.Button deleteLichTap;
        private System.Windows.Forms.Button addLichTap;
        private System.Windows.Forms.ComboBox listKhachHang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button excelSchedule;
    }
}