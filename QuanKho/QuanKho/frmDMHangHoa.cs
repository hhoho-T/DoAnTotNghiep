using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using QuanKho.Class;


namespace QuanKho
{
    public partial class frmDMHangHoa : Form
    {
        DataTable tblH; //Bảng hàng
        private string qrCode;
        public frmDMHangHoa(string qrCode)
        {
            InitializeComponent();
            this.qrCode = qrCode;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private String mnv;

        public String ChucVuhoa
        {
            get { return mnv; }
            set { mnv = value; }
        }
        private void frmDMHangHoa_Load(object sender, EventArgs e)
        {
            
            cboMaMa.Visible = false;
            Functions.Connect();
            txtMaMay.Text = qrCode;
            string sql;
            sql = "SELECT * from tblHang";
            txtMaMay.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDataGridView();
            Functions.FillCombo(sql, cboMaHang, "MaHang", "TenHang");
            cboMaHang.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaMay, TenMay FROM tblMay",   cboMaMa  , "MaMay", "MaMay");
            cboMaMa.SelectedIndex = -1;
            //  ResetValues();

            Functions.Connect(); //Mở kết nối
            /* if (mnv != "admin")
             {
                 btnThem.Visible = false;
                 btnSua.Visible = false;
                 btnXoa.Visible = false;
                 btnLuu.Visible = false;
                 btnBoQua.Visible = false;
             } else
             {
                 btnThem.Visible = true;
                 btnSua.Visible = true;
                 btnXoa.Visible = true;
                 btnLuu.Visible = true;
                 btnBoQua.Visible = true;
             }*/
           
        }
        private void ResetValues()
        {
            datenhap.Text = DateTime.Now.ToShortDateString(); 
            txtMaMay.Text = "";
            txtTenMay.Text = "";
            cboMaHang.Text = "";
            txtSoLuong.Text = "";
            txtDonGiaNhap.Text = "";
            txtDonGiaBan.Text = "";
            txtSoLuong.Enabled = true;
            txtDonGiaNhap.Enabled = false;
            txtDonGiaBan.Enabled = false;
            txtAnh.Text = "";
            picAnh.Image = null;
            txtGhiChu.Text = "";
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * from tblMay";
            tblH = Functions.GetDataToTable(sql);
            dgvMay.DataSource = tblH;
            dgvMay.Columns[0].Visible = false;
            dgvMay.Columns[1].HeaderText = "Tên hàng";
            dgvMay.Columns[2].Visible = false;
            dgvMay.Columns[3].HeaderText = "Số lượng";
            dgvMay.Columns[4].HeaderText = "Đơn giá nhập";
            dgvMay.Columns[5].HeaderText = "Đơn giá bán";
            dgvMay.Columns[6].HeaderText = "Ảnh";
            dgvMay.Columns[7].HeaderText = "Ghi chú";
            dgvMay.Columns[8].HeaderText = "Ngày nhập";
            dgvMay.Columns[0].Visible = false;
            dgvMay.Columns[1].Visible = false;
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
        private void dgvMay_Click(object sender, EventArgs e)
        {
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaMay.Visible = true;
            cboMaMa.Visible = false;
            btnthemsoluong.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaMay.Enabled = true;
            txtMaMay.Focus();
            txtSoLuong.Enabled = true;
            txtDonGiaNhap.Enabled = true;
            txtDonGiaBan.Enabled = true;
            datenhap.Enabled = true;
            
            frmcam frm = new frmcam();
            frm.QRCodeScanned += Frm_QRCodeScanned; // Đăng ký sự kiện
            frm.ShowDialog();
        }
        private void Frm_QRCodeScanned(string qrCode)
        {
            // Xử lý khi nhận được mã QR
            txtMaMay.Text = qrCode;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (btnOpen.Enabled == false)
            {

                string kq, sql2;
                Functions.Connect();
                string sql1 = "SELECT COUNT(*)FROM tblMay WHERE MaMay = '" + cboMaMa.Text + "'";
                kq = Functions.GetFieldValues(sql1);

                if (cboMaMa.Text.Trim().Length == 0 || kq == "0")
                {

                    MessageBox.Show("Bạn phải nhập mã hàng hoặc sai mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMaMa.Focus();
                    return;
                }
                if (txtSoLuong.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập số lượng cần thêm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSoLuong.Focus();
                    return;
                }
                if (datenhap.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập ngày thêm số lương", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    datenhap.Focus();
                    return;
                }
                sql2 = "EXEC UpdateSoLuong @MaMay = '" + cboMaMa.Text + "', @SoLuongThem = " + txtSoLuong.Text + ", @NgayNhap = '" + datenhap.Text + "'";
                Functions.RunSQL(sql2);
                LoadDataGridView();
                ResetValues();
                cboMaMa.Text = "";
            }
            else
            {


                if (txtMaMay.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaMay.Focus();
                    return;
                }
                if (txtTenMay.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenMay.Focus();
                    return;
                }
                if (cboMaHang.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên hãng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMaHang.Focus();
                    return;
                }
                if (txtAnh.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn ảnh minh hoạ cho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnOpen.Focus();
                    return;
                }

                sql = "SELECT MaMay FROM tblMay WHERE MaMay=N'" + txtMaMay.Text.Trim() + "'";
                if (Functions.CheckKey(sql))
                {
                    MessageBox.Show("Mã hàng này đã tồn tại, bạn phải chọn mã hàng khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaMay.Focus();
                    return;
                }
                sql = "INSERT INTO tblMay(MaMay,TenMay,MaHang,SoLuong,DonGiaNhap, DonGiaBan,Anh,Ghichu,Ngaynhap) VALUES(N'"
                    + txtMaMay.Text.Trim() + "',N'" + txtTenMay.Text.Trim() +
                    "',N'" + cboMaHang.SelectedValue.ToString() +
                    "'," + txtSoLuong.Text.Trim() + "," + txtDonGiaNhap.Text +
                    "," + txtDonGiaBan.Text + ",'" + txtAnh.Text + "',N'" + txtGhiChu.Text.Trim() + "',N'" + datenhap.Text.Trim() + "')";

                Functions.RunSQL(sql);
                LoadDataGridView();
                //ResetValues();
                btnXoa.Enabled = true;
                btnThem.Enabled = true;
                btnthemsoluong.Enabled = true;
                btnSua.Enabled = true;
                btnBoQua.Enabled = false;
                btnLuu.Enabled = false;
                txtMaMay.Enabled = false;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaMay.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaMay.Focus();
                return;
            }
            if (txtTenMay.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenMay.Focus();
                return;
            }
            if (cboMaHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaHang.Focus();
                return;
            }
            if (txtAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải ảnh minh hoạ cho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAnh.Focus();
                return;
            }
            sql = "UPDATE tblMay SET TenMay=N'" + txtTenMay.Text.Trim().ToString() +
                "',MaHang=N'" + cboMaHang.SelectedValue.ToString() +
                "',SoLuong=" + txtSoLuong.Text +
                ",Anh='" + txtAnh.Text + "',Ghichu=N'" + txtGhiChu.Text + "',Ngaynhap=N'" + datenhap.Text + "' WHERE MaMay=N'" + txtMaMay.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnBoQua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaMay.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblMay WHERE MaMay=N'" + txtMaMay.Text + "'";
                Functions.RunSQL(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            cboMaMa.Visible = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaMay.Enabled = false;
            txtTenMay.Enabled = true;
            txtGhiChu.Enabled = true;
            btnOpen.Enabled = true;
            cboMaHang.Enabled = true;
            txtDonGiaBan.Enabled = true;
            txtDonGiaNhap.Enabled = true;
            btnthemsoluong.Enabled = true;
            btnTimKiem.Enabled = true;
            btnHienThi.Enabled = true;
           
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn ảnh minh hoạ cho sản phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgOpen.FileName);
                txtAnh.Text = dlgOpen.FileName;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;

            if ((txtMaMay.Text == "") && (txtTenMay.Text == "") && (cboMaHang.Text == ""))
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * from tblMay WHERE 1=1";
            if (txtMaMay.Text != "")
                sql += " AND MaMay LIKE N'%" + txtMaMay.Text + "%'";
            if (txtTenMay.Text != "")
                sql += " AND TenMay LIKE N'%" + txtTenMay.Text + "%'";
            if (cboMaHang.Text != "")
                sql += " AND MaHang LIKE N'%" + cboMaHang.SelectedValue + "%'";
            tblH = Functions.GetDataToTable(sql);
            if (tblH.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + tblH.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvMay.DataSource = tblH;
            ResetValues();
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaMay,TenMay,MaHang,SoLuong,DonGiaNhap,DonGiaBan,Anh,Ghichu,Ngaynhap FROM tblMay";
            tblH = Functions.GetDataToTable(sql);
            dgvMay.DataSource = tblH;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void dgvMay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string MaHang;
            string sql;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm không thể chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaMay.Focus();
                return;
            }
            if (tblH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaMay.Text = dgvMay.CurrentRow.Cells["MaMay"].Value.ToString();
            txtTenMay.Text = dgvMay.CurrentRow.Cells["TenMay"].Value.ToString();
            MaHang = dgvMay.CurrentRow.Cells["MaHang"].Value.ToString();
            sql = "SELECT TenHang FROM tblHang WHERE MaHang=N'" + MaHang + "'";
            cboMaHang.Text = Functions.GetFieldValues(sql);
            txtSoLuong.Text = dgvMay.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtDonGiaNhap.Text = dgvMay.CurrentRow.Cells["DonGiaNhap"].Value.ToString();
            txtDonGiaBan.Text = dgvMay.CurrentRow.Cells["DonGiaBan"].Value.ToString();
            datenhap.Text = dgvMay.CurrentRow.Cells["Ngaynhap"].Value.ToString();
            sql = "SELECT Anh FROM tblMay WHERE MaMay=N'" + txtMaMay.Text + "'";
            txtAnh.Text = Functions.GetFieldValues(sql);
            picAnh.Image = Image.FromFile(txtAnh.Text);
            sql = "SELECT Ghichu FROM tblMay WHERE MaMay = N'" + txtMaMay.Text + "'";
            txtGhiChu.Text = Functions.GetFieldValues(sql);
         


            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }

        private void cboMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvMay_Click_1(object sender, EventArgs e)
        {
            string MaHang;
            string sql;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm không thể chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaMay.Focus();
                return;
            }
            if (tblH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaMay.Text = dgvMay.CurrentRow.Cells["MaMay"].Value.ToString();
            txtTenMay.Text = dgvMay.CurrentRow.Cells["TenMay"].Value.ToString();
            MaHang = dgvMay.CurrentRow.Cells["MaHang"].Value.ToString();
            sql = "SELECT TenHang FROM tblHang WHERE MaHang=N'" + MaHang + "'";
            cboMaHang.Text = Functions.GetFieldValues(sql);
            txtSoLuong.Text = dgvMay.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtDonGiaNhap.Text = dgvMay.CurrentRow.Cells["DonGiaNhap"].Value.ToString();
            txtDonGiaBan.Text = dgvMay.CurrentRow.Cells["DonGiaBan"].Value.ToString();
            datenhap.Text = dgvMay.CurrentRow.Cells["Ngaynhap"].Value.ToString();
            sql = "SELECT Anh FROM tblMay WHERE MaMay=N'" + txtMaMay.Text + "'";
            txtAnh.Text = Functions.GetFieldValues(sql);
            picAnh.Image = Image.FromFile(txtAnh.Text);
            sql = "SELECT Ghichu FROM tblMay WHERE MaMay = N'" + txtMaMay.Text + "'";
            txtGhiChu.Text = Functions.GetFieldValues(sql);
         
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }

        private void txtMaMay_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDonGiaNhap_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnthemsoluong_Click(object sender, EventArgs e)
        {
            txtMaMay.Visible = false;
            cboMaMa.Visible = true;
            txtTenMay.Enabled = false;
            cboMaHang.Enabled = false;
            txtDonGiaBan.Enabled = false;
            txtDonGiaNhap.Enabled = false;
            btnOpen.Enabled = false;
            txtGhiChu.Enabled = false;
            btnBoQua.Enabled = true;
            txtMaMay.Enabled = true;
          
            btnHienThi.Enabled = false;
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnHienThi.Enabled = false;
            btnTimKiem.Enabled = false;
            
            btnLuu.Enabled = true;
            btnthemsoluong.Enabled = false;
            ResetValues();
        }

        private void cboMaMa_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaMa.Text == "")
            {
                txtTenMay.Text = "";
                txtDonGiaBan.Text = "";
            }
            // Khi chọn mã hàng thì các thông tin về hàng hiện ra
            str = "SELECT TenMay FROM tblMay WHERE MaMay =N'" + cboMaMa.SelectedValue + "'";
            txtTenMay.Text = Functions.GetFieldValues(str);
            str = "SELECT DonGiaBan FROM tblMay WHERE MaMay =N'" + cboMaMa.SelectedValue + "'";
            txtDonGiaBan.Text = Functions.GetFieldValues(str);
            str = "SELECT DonGiaNhap FROM tblMay WHERE MaMay =N'" + cboMaMa.SelectedValue + "'";
            txtDonGiaNhap.Text = Functions.GetFieldValues(str);
            str = "SELECT GhiChu FROM tblMay WHERE MaMay =N'" + cboMaMa.SelectedValue + "'";
            txtGhiChu.Text = Functions.GetFieldValues(str);
            str = "SELECT h.TenHang FROM tblMay m JOIN tblHang h ON m.MaHang = h.MaHang WHERE m.MaMay = N'" + cboMaMa.SelectedValue + "';";
            cboMaHang.Text = Functions.GetFieldValues(str);
            str = "SELECT Anh FROM tblMay WHERE MaMay=N'" + cboMaMa.SelectedValue + "'";
            string imagePath = Functions.GetFieldValues(str).Trim(); // Lấy đường dẫn và loại bỏ khoảng trắng thừa
            Functions.Connect();
            txtAnh.Text = imagePath;
            if (!string.IsNullOrEmpty(imagePath))
            {
                    try
                    {
                        picAnh.Image = Image.FromFile(imagePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while loading the image: " + ex.Message);
                    }
            }
        }

        /*   private void btnluusoluong_Click(object sender, EventArgs e)
           {
               string kq, sql2;
               Functions.Connect();
               string sql = "SELECT COUNT(*)FROM tblMay WHERE MaMay = '"+txtMaMay.Text+"'";
               kq = Functions.GetFieldValues(sql);

               if (txtMaMay.Text.Trim().Length == 0 || kq == "0")
               {

                   MessageBox.Show("Bạn phải nhập mã hàng hoặc sai mã hàng" , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   txtMaMay.Focus();
                   return;
               }
               if (txtSoLuong.Text.Trim().Length == 0)
               {
                   MessageBox.Show("Bạn phải nhập số lượng cần thêm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   txtSoLuong.Focus();
                   return;
               }
               if (datenhap.Text.Trim().Length == 0)
               {
                   MessageBox.Show("Bạn phải nhập ngày thêm số lương", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   datenhap.Focus();
                   return;
               }
               sql2 = "EXEC UpdateSoLuong @MaMay = '" + txtMaMay.Text + "', @SoLuongThem = " + txtSoLuong.Text + ", @NgayNhap = '" + datenhap.Text + "'";
               Functions.RunSQL(sql2);
               LoadDataGridView();
               ResetValues();
               txtTenMay.Enabled = true;
               txtMaMay.Enabled = false;
               cboMaHang.Enabled = true;
               txtDonGiaBan.Enabled = true;
               txtDonGiaNhap.Enabled = true;
               btnOpen.Enabled = true;
               txtGhiChu.Enabled = true;
               btnHienThi.Enabled = true;
               btnSua.Enabled = true;
               btnThem.Enabled = true;
               btnXoa.Enabled = true;
               btnHienThi.Enabled = true;
               btnTimKiem.Enabled = true;
               btnluusoluong.Visible = false;
               btnLuu.Visible = true;
           }*/
    }
}
