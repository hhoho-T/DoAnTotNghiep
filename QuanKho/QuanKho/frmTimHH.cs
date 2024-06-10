using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanKho.Class;


namespace QuanKho
{
    public partial class frmTimHH : Form
    {
        DataTable tblHH; //Hoá đơn bán

        public frmTimHH()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtTenMay_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaMay_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmTimHH_Load(object sender, EventArgs e)
        {
            ResetValues();
            dgvTKHoaDon.DataSource = null;
        }
        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            txtMaMay.Focus();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaMay.Text == "") && 
               (txtTenMay.Text == "") && (txtHang.Text == "") &&
               (txtSoLuong.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tblMay WHERE 1=1";
            if (txtMaMay.Text != "")
                sql = sql + " AND MaMay Like N'%" + txtMaMay.Text + "%'";
           
            if (txtTenMay.Text != "")
                sql = sql + " AND TenMay Like N'%" + txtTenMay.Text + "%'";
            if (txtHang.Text != "")
                sql = sql + " AND GhiChu Like N'%" + txtHang.Text + "%'";
            if (txtSoLuong.Text != "")
                sql = sql + " AND SoLuong <=" + txtSoLuong.Text;
            tblHH = Functions.GetDataToTable(sql);
            if (tblHH.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Có " + tblHH.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvTKHoaDon.DataSource = tblHH;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            dgvTKHoaDon.Columns[0].HeaderText = "Mã Hàng Hóa";
            dgvTKHoaDon.Columns[1].HeaderText = "Tên Máy";
            dgvTKHoaDon.Columns[2].HeaderText = "GhiChu";
            dgvTKHoaDon.Columns[3].HeaderText = "Số Lượng";
         
            dgvTKHoaDon.Columns[0].Width = 150;
            dgvTKHoaDon.Columns[1].Width = 100;
            dgvTKHoaDon.Columns[2].Width = 80;
            dgvTKHoaDon.Columns[3].Width = 80;
       
            dgvTKHoaDon.AllowUserToAddRows = false;
            dgvTKHoaDon.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void txtMaMay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void dgvTKHoaDon_DoubleClick(object sender, EventArgs e)
        {

            string mahh;
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                mahh = dgvTKHoaDon.CurrentRow.Cells["MaMay"].Value.ToString();
                frmDMHangHoa frm = new frmDMHangHoa("");
                frm.txtMaMay.Text = mahh;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }

        private void btnTimLai_Click(object sender, EventArgs e)
        {
            ResetValues();
            dgvTKHoaDon.DataSource = null;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvTKHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvTKHoaDon.CurrentRow != null)
            {
                txtMaMay.Text = dgvTKHoaDon.CurrentRow.Cells["MaMay"].Value.ToString();
                txtTenMay.Text = dgvTKHoaDon.CurrentRow.Cells["TenMay"].Value.ToString();
                txtHang.Text = dgvTKHoaDon.CurrentRow.Cells["GhiChu"].Value.ToString();
                txtSoLuong.Text = dgvTKHoaDon.CurrentRow.Cells["SoLuong"].Value.ToString();
              
            }
            }
        }
}
