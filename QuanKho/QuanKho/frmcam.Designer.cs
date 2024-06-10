
namespace QuanKho
{
    partial class frmcam
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnstart = new System.Windows.Forms.Button();
            this.txtcode = new System.Windows.Forms.TextBox();
            this.cbm = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(132, 110);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(939, 498);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnstart
            // 
            this.btnstart.BackColor = System.Drawing.Color.Lime;
            this.btnstart.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnstart.Location = new System.Drawing.Point(25, 296);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(101, 42);
            this.btnstart.TabIndex = 2;
            this.btnstart.Text = "Bắt đầu";
            this.btnstart.UseVisualStyleBackColor = false;
            this.btnstart.Click += new System.EventHandler(this.btnstart_Click);
            // 
            // txtcode
            // 
            this.txtcode.Location = new System.Drawing.Point(316, 614);
            this.txtcode.Name = "txtcode";
            this.txtcode.Size = new System.Drawing.Size(520, 22);
            this.txtcode.TabIndex = 4;
            // 
            // cbm
            // 
            this.cbm.FormattingEnabled = true;
            this.cbm.Location = new System.Drawing.Point(327, 67);
            this.cbm.Name = "cbm";
            this.cbm.Size = new System.Drawing.Size(416, 24);
            this.cbm.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(128, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Chọn loại camera";
            // 
            // frmcam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 783);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbm);
            this.Controls.Add(this.txtcode);
            this.Controls.Add(this.btnstart);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmcam";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmcam_FormClosing);
            this.Load += new System.EventHandler(this.frmcam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnstart;
        private System.Windows.Forms.TextBox txtcode;
        private System.Windows.Forms.ComboBox cbm;
        private System.Windows.Forms.Label label1;
    }
}