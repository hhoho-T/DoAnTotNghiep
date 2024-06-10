
namespace QuanKho
{
    partial class frmDMDoanhThu
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtSoluong = new System.Windows.Forms.TextBox();
            this.txtDoanhThu = new System.Windows.Forms.TextBox();
            this.cboMaHang = new System.Windows.Forms.ComboBox();
            this.txtMaHang = new System.Windows.Forms.Label();
            this.txtDTTong = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpickBD = new System.Windows.Forms.DateTimePicker();
            this.dtpickKT = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.btnkq = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbonv = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtnhap = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbNV = new System.Windows.Forms.CheckBox();
            this.cbN = new System.Windows.Forms.CheckBox();
            this.cbCH = new System.Windows.Forms.CheckBox();
            this.txtslTong = new System.Windows.Forms.TextBox();
            this.dgvMay = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnct = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMay)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(566, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "DOANH THU";
            // 
            // txtSoluong
            // 
            this.txtSoluong.Location = new System.Drawing.Point(171, 163);
            this.txtSoluong.Margin = new System.Windows.Forms.Padding(4);
            this.txtSoluong.Name = "txtSoluong";
            this.txtSoluong.ReadOnly = true;
            this.txtSoluong.Size = new System.Drawing.Size(303, 22);
            this.txtSoluong.TabIndex = 12;
            this.txtSoluong.TextChanged += new System.EventHandler(this.txtSoluong_TextChanged);
            // 
            // txtDoanhThu
            // 
            this.txtDoanhThu.Location = new System.Drawing.Point(171, 204);
            this.txtDoanhThu.Margin = new System.Windows.Forms.Padding(4);
            this.txtDoanhThu.Name = "txtDoanhThu";
            this.txtDoanhThu.ReadOnly = true;
            this.txtDoanhThu.Size = new System.Drawing.Size(303, 22);
            this.txtDoanhThu.TabIndex = 11;
            this.txtDoanhThu.TextChanged += new System.EventHandler(this.txtDoanhThu_TextChanged);
            // 
            // cboMaHang
            // 
            this.cboMaHang.FormattingEnabled = true;
            this.cboMaHang.Location = new System.Drawing.Point(171, 75);
            this.cboMaHang.Margin = new System.Windows.Forms.Padding(4);
            this.cboMaHang.Name = "cboMaHang";
            this.cboMaHang.Size = new System.Drawing.Size(303, 24);
            this.cboMaHang.TabIndex = 14;
            this.cboMaHang.SelectedIndexChanged += new System.EventHandler(this.cboMaHang_SelectedIndexChanged);
            // 
            // txtMaHang
            // 
            this.txtMaHang.AutoSize = true;
            this.txtMaHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaHang.Location = new System.Drawing.Point(56, 78);
            this.txtMaHang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtMaHang.Name = "txtMaHang";
            this.txtMaHang.Size = new System.Drawing.Size(79, 17);
            this.txtMaHang.TabIndex = 13;
            this.txtMaHang.Text = "Chọn Hãng";
            this.txtMaHang.Click += new System.EventHandler(this.txtMaHang_Click);
            // 
            // txtDTTong
            // 
            this.txtDTTong.Location = new System.Drawing.Point(75, 212);
            this.txtDTTong.Margin = new System.Windows.Forms.Padding(4);
            this.txtDTTong.Name = "txtDTTong";
            this.txtDTTong.ReadOnly = true;
            this.txtDTTong.Size = new System.Drawing.Size(320, 22);
            this.txtDTTong.TabIndex = 17;
            this.txtDTTong.TextChanged += new System.EventHandler(this.txtDTTong_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(71, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(252, 22);
            this.label5.TabIndex = 15;
            this.label5.Text = "Tổng số lượng đã xuất ra kho";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(71, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(204, 22);
            this.label4.TabIndex = 19;
            this.label4.Text = "Tổng doanh thu  đã bán";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // dtpickBD
            // 
            this.dtpickBD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpickBD.Location = new System.Drawing.Point(171, 121);
            this.dtpickBD.Name = "dtpickBD";
            this.dtpickBD.Size = new System.Drawing.Size(129, 22);
            this.dtpickBD.TabIndex = 22;
            this.dtpickBD.Value = new System.DateTime(1999, 1, 1, 20, 37, 0, 0);
            // 
            // dtpickKT
            // 
            this.dtpickKT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpickKT.Location = new System.Drawing.Point(348, 121);
            this.dtpickKT.Name = "dtpickKT";
            this.dtpickKT.Size = new System.Drawing.Size(126, 22);
            this.dtpickKT.TabIndex = 23;
            this.dtpickKT.Value = new System.DateTime(2024, 6, 5, 0, 0, 0, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(310, 125);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 17);
            this.label7.TabIndex = 24;
            this.label7.Text = "Đến";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // btnkq
            // 
            this.btnkq.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnkq.Location = new System.Drawing.Point(171, 245);
            this.btnkq.Name = "btnkq";
            this.btnkq.Size = new System.Drawing.Size(99, 32);
            this.btnkq.TabIndex = 26;
            this.btnkq.Text = "Kết quả";
            this.btnkq.UseVisualStyleBackColor = true;
            this.btnkq.Click += new System.EventHandler(this.btnkq_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(56, 204);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 17);
            this.label10.TabIndex = 29;
            this.label10.Text = "Doanh thu";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(56, 162);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 17);
            this.label11.TabIndex = 30;
            this.label11.Text = "Số lượng";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(56, 125);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 17);
            this.label12.TabIndex = 31;
            this.label12.Text = "Chọn ngày";
            // 
            // cbonv
            // 
            this.cbonv.FormattingEnabled = true;
            this.cbonv.Location = new System.Drawing.Point(171, 35);
            this.cbonv.Margin = new System.Windows.Forms.Padding(4);
            this.cbonv.Name = "cbonv";
            this.cbonv.Size = new System.Drawing.Size(303, 24);
            this.cbonv.TabIndex = 34;
            this.cbonv.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 33;
            this.label1.Text = "Chọn nhân viên";
            // 
            // txtnhap
            // 
            this.txtnhap.Location = new System.Drawing.Point(75, 81);
            this.txtnhap.Margin = new System.Windows.Forms.Padding(4);
            this.txtnhap.Name = "txtnhap";
            this.txtnhap.ReadOnly = true;
            this.txtnhap.Size = new System.Drawing.Size(320, 22);
            this.txtnhap.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(71, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(268, 22);
            this.label3.TabIndex = 35;
            this.label3.Text = "Tổng số lượng đã nhập vào kho";
            // 
            // cbNV
            // 
            this.cbNV.AutoSize = true;
            this.cbNV.Location = new System.Drawing.Point(485, 36);
            this.cbNV.Name = "cbNV";
            this.cbNV.Size = new System.Drawing.Size(18, 17);
            this.cbNV.TabIndex = 37;
            this.cbNV.UseVisualStyleBackColor = true;
            this.cbNV.Click += new System.EventHandler(this.cbNV_Click);
            // 
            // cbN
            // 
            this.cbN.AutoSize = true;
            this.cbN.Location = new System.Drawing.Point(485, 125);
            this.cbN.Name = "cbN";
            this.cbN.Size = new System.Drawing.Size(18, 17);
            this.cbN.TabIndex = 38;
            this.cbN.UseVisualStyleBackColor = true;
            this.cbN.Click += new System.EventHandler(this.cbN_Click);
            // 
            // cbCH
            // 
            this.cbCH.AutoSize = true;
            this.cbCH.Location = new System.Drawing.Point(485, 81);
            this.cbCH.Name = "cbCH";
            this.cbCH.Size = new System.Drawing.Size(18, 17);
            this.cbCH.TabIndex = 39;
            this.cbCH.UseVisualStyleBackColor = true;
            this.cbCH.Click += new System.EventHandler(this.cbCH_Click);
            // 
            // txtslTong
            // 
            this.txtslTong.Location = new System.Drawing.Point(75, 149);
            this.txtslTong.Margin = new System.Windows.Forms.Padding(4);
            this.txtslTong.Name = "txtslTong";
            this.txtslTong.ReadOnly = true;
            this.txtslTong.Size = new System.Drawing.Size(320, 22);
            this.txtslTong.TabIndex = 40;
            // 
            // dgvMay
            // 
            this.dgvMay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMay.Location = new System.Drawing.Point(12, 373);
            this.dgvMay.Name = "dgvMay";
            this.dgvMay.RowHeadersWidth = 51;
            this.dgvMay.RowTemplate.Height = 24;
            this.dgvMay.Size = new System.Drawing.Size(1253, 346);
            this.dgvMay.TabIndex = 41;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtDoanhThu);
            this.panel1.Controls.Add(this.cbonv);
            this.panel1.Controls.Add(this.txtSoluong);
            this.panel1.Controls.Add(this.txtMaHang);
            this.panel1.Controls.Add(this.cboMaHang);
            this.panel1.Controls.Add(this.cbCH);
            this.panel1.Controls.Add(this.dtpickBD);
            this.panel1.Controls.Add(this.cbN);
            this.panel1.Controls.Add(this.dtpickKT);
            this.panel1.Controls.Add(this.cbNV);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnkq);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Location = new System.Drawing.Point(12, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(612, 296);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnct);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtDTTong);
            this.panel2.Controls.Add(this.txtslTong);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtnhap);
            this.panel2.Location = new System.Drawing.Point(665, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 296);
            this.panel2.TabIndex = 42;
            // 
            // btnct
            // 
            this.btnct.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnct.Location = new System.Drawing.Point(75, 245);
            this.btnct.Name = "btnct";
            this.btnct.Size = new System.Drawing.Size(127, 32);
            this.btnct.TabIndex = 40;
            this.btnct.Text = "Xem chi tiết";
            this.btnct.UseVisualStyleBackColor = true;
            this.btnct.Click += new System.EventHandler(this.btnct_Click);
            // 
            // frmDMDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1277, 731);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvMay);
            this.Controls.Add(this.label2);
            this.Name = "frmDMDoanhThu";
            this.Load += new System.EventHandler(this.frmDMDoanhThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMay)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtSoluong;
        private System.Windows.Forms.TextBox txtDoanhThu;
        private System.Windows.Forms.ComboBox cboMaHang;
        private System.Windows.Forms.Label txtMaHang;
        private System.Windows.Forms.TextBox txtDTTong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpickBD;
        private System.Windows.Forms.DateTimePicker dtpickKT;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnkq;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbonv;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtnhap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbNV;
        private System.Windows.Forms.CheckBox cbN;
        private System.Windows.Forms.CheckBox cbCH;
        public System.Windows.Forms.TextBox txtslTong;
        private System.Windows.Forms.DataGridView dgvMay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnct;
    }
}