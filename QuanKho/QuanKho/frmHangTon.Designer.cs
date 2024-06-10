
namespace QuanKho
{
    partial class frmHangTon
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
            this.dgvMay = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.cboMaMay = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMay)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(505, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "HÀNG TỒN KHO";
            // 
            // dgvMay
            // 
            this.dgvMay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMay.Location = new System.Drawing.Point(3, 172);
            this.dgvMay.Name = "dgvMay";
            this.dgvMay.RowHeadersWidth = 51;
            this.dgvMay.RowTemplate.Height = 24;
            this.dgvMay.Size = new System.Drawing.Size(1230, 575);
            this.dgvMay.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.LimeGreen;
            this.label8.Location = new System.Drawing.Point(-1, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 22);
            this.label8.TabIndex = 28;
            this.label8.Text = "Chọn số tháng";
            // 
            // cboMaMay
            // 
            this.cboMaMay.FormattingEnabled = true;
            this.cboMaMay.Items.AddRange(new object[] {
            "1",
            "6",
            "12"});
            this.cboMaMay.Location = new System.Drawing.Point(3, 141);
            this.cboMaMay.Margin = new System.Windows.Forms.Padding(4);
            this.cboMaMay.Name = "cboMaMay";
            this.cboMaMay.Size = new System.Drawing.Size(232, 24);
            this.cboMaMay.TabIndex = 12;
            this.cboMaMay.SelectedIndexChanged += new System.EventHandler(this.cboMaMay_SelectedIndexChanged);
            // 
            // frmHangTon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 749);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboMaMay);
            this.Controls.Add(this.dgvMay);
            this.Controls.Add(this.label2);
            this.Name = "frmHangTon";
            this.Load += new System.EventHandler(this.frmHangTon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvMay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboMaMay;
    }
}