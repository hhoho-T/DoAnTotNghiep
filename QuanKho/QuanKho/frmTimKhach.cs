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
    public partial class frmTimKhach : Form
    {

        DataTable tblHH; //Hoá đơn bán

        public frmTimKhach()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmTimKhach_Load(object sender, EventArgs e)
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
            txtMaMay.Text = "";
            txtTenMay.Text = "";
            txtHang.Text = "";
            mtbDienThoai.Text = "";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM tblKhach WHERE 1=1";

            // Kiểm tra từng trường dữ liệu và thêm điều kiện vào câu truy vấn SQL chỉ khi trường đó được nhập
            if (!string.IsNullOrWhiteSpace(txtMaMay.Text))
                sql += " AND MaKhach LIKE N'%" + txtMaMay.Text + "%'";
            else if (!string.IsNullOrWhiteSpace(txtTenMay.Text))
                sql += " AND TenKhach LIKE N'%" + txtTenMay.Text + "%'";
            else if (!string.IsNullOrWhiteSpace(txtHang.Text))
                sql += " AND DiaChi LIKE N'%" + txtHang.Text + "%'";
            else if (!string.IsNullOrWhiteSpace(mtbDienThoai.Text))
            {
                string dienThoai = new string(mtbDienThoai.Text.Where(char.IsDigit).ToArray());
                int soDienThoai;
                if (int.TryParse(dienThoai, out soDienThoai))
                    sql += " AND DienThoai <= " + soDienThoai;
                else
                {
                    MessageBox.Show("Số điện thoại không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            tblHH = Functions.GetDataToTable(sql);
            if (tblHH.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Có " + tblHH.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgvTKHoaDon.DataSource = tblHH;
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            dgvTKHoaDon.Columns[0].HeaderText = "Mã Khách";
            dgvTKHoaDon.Columns[1].HeaderText = "Tên Khách";
            dgvTKHoaDon.Columns[2].HeaderText = "Địa Chỉ";
            dgvTKHoaDon.Columns[3].HeaderText = "Số Điện Thoại";

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
      
      

       

        private void mtbDienThoai_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnTimLai_Click_1(object sender, EventArgs e)
        {
            
            ResetValues();
            dgvTKHoaDon.DataSource = null;
        }

        private void btnDong_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvTKHoaDon_Click_1(object sender, EventArgs e)
        {
            if (dgvTKHoaDon.CurrentRow != null)
            {
                txtMaMay.Text = dgvTKHoaDon.CurrentRow.Cells["MaKhach"].Value.ToString();
                txtTenMay.Text = dgvTKHoaDon.CurrentRow.Cells["TenKhach"].Value.ToString();
                txtHang.Text = dgvTKHoaDon.CurrentRow.Cells["DiaChi"].Value.ToString();
                mtbDienThoai.Text = dgvTKHoaDon.CurrentRow.Cells["DienThoai"].Value.ToString();

            }

        }

        private void dgvTKHoaDon_DoubleClick_1(object sender, EventArgs e)
        {

            string mahh;
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                mahh = dgvTKHoaDon.CurrentRow.Cells["MaKhach"].Value.ToString();
                frmDMKhachHang frm = new frmDMKhachHang();
                frm.txtMaKhach.Text = mahh;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }
    }
}

    