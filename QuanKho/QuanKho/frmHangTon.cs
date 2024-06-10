using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanKho.Class;


namespace QuanKho
{
    public partial class frmHangTon : Form
    {
        public frmHangTon()
        {
            InitializeComponent();
        }
        DataTable tblH; 
        private void frmHangTon_Load(object sender, EventArgs e)
        {
            Functions.Connect();
            
        }
       /* string str;
            if (cboMaMay.Text == "")
            {
                txtTenMay.Text = "";
                txtDonGiaBan.Text = "";
            }
    // Khi chọn mã hàng thì các thông tin về hàng hiện ra
    str = "SELECT TenMay FROM tblMay WHERE MaMay =N'" + cboMaMay.SelectedValue + "'";
            txtTenMay.Text = Functions.GetFieldValues(str);
            str = "SELECT DonGiaBan FROM tblMay WHERE MaMay =N'" + cboMaMay.SelectedValue + "'";
            txtDonGiaBan.Text = Functions.GetFieldValues(str);*/
        private void LoadDataGridView()
        {
           
          
        }

        private void cboMaMay_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT * FROM tblMay WHERE DATEDIFF(day, Ngaynhap, GETDATE()) >= '" + (cboMaMay.SelectedValue) + "'";
            tblH = Functions.GetDataToTable(sql);
            dgvMay.DataSource = tblH;
            dgvMay.Columns[0].HeaderText = "Mã hàng";
            dgvMay.Columns[1].HeaderText = "Tên hàng";
            dgvMay.Columns[2].HeaderText = "Mã hãng";
            dgvMay.Columns[3].HeaderText = "Số lượng";
            dgvMay.Columns[4].HeaderText = "Đơn giá nhập";
            dgvMay.Columns[5].HeaderText = "Đơn giá bán";
            dgvMay.Columns[6].HeaderText = "Ảnh";
            dgvMay.Columns[7].HeaderText = "Ghi chú";
            dgvMay.Columns[8].HeaderText = "Ngày nhập";
            dgvMay.Columns[0].Width = 80;
            dgvMay.Columns[1].Width = 140;
            dgvMay.Columns[2].Width = 80;
            dgvMay.Columns[3].Width = 80;
            dgvMay.Columns[4].Width = 100;
            dgvMay.Columns[5].Width = 100;
            dgvMay.Columns[6].Width = 200;
            dgvMay.Columns[7].Width = 200;
            dgvMay.Columns[8].Width = 300;
            dgvMay.AllowUserToAddRows = false;
            dgvMay.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
    }
}
