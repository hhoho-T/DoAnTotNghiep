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
    public partial class frmDMDoanhThu : Form
    {
        public frmDMDoanhThu()
        {
            InitializeComponent();
        }
        DataTable tblH;
        private void frmDMDoanhThu_Load(object sender, EventArgs e)
        {
            DateTime ngayBatDau = dtpickBD.Value.Date;
            DateTime ngayKetThuc = dtpickKT.Value.Date;
            Functions.Connect();
            LoadDataGridView();
            String sql, sql1, sql2;
            sql = "SELECT SUM(SoLuong) AS tong FROM tblChiTietHDBan";
            sql1 = "SELECT SUM(ThanhTien) AS tong FROM tblChiTietHDBan";
            sql2 = "SELECT SUM(SoLuong) AS tong FROM tblMay";
            txtnhap.Text = Functions.GetFieldValues(sql2);
            txtslTong.Text = Functions.GetFieldValues(sql);
            txtDTTong.Text = Functions.GetFieldValues(sql1);
            Functions.FillCombo("SELECT TenHang FROM tblHang", cboMaHang, "TenHang", "TenHang");
            cboMaHang.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaNhanVien FROM tblNhanVien", cbonv, "MaNhanVien", "MaNhanVien");
            cbonv.SelectedIndex = -1;
            cbonv.Enabled = false;
            cboMaHang.Enabled = false;
            dtpickBD.Enabled = false;
            dtpickKT.Enabled = false;

        }
        private void LoadDataGridView()
        {

        }
        private void cboMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtMaHang_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDoanhThu_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnkq_Click(object sender, EventArgs e)
        {
            Functions.Connect();
            DateTime ngayBatDau = dtpickBD.Value.Date;
            DateTime ngayKetThuc = dtpickKT.Value.Date;
            string sql, sql2, sql3;
            if (cbNV.Checked == true && cbCH.Checked == true && cbN.Checked == true)
            {
                if (cbonv.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbonv.Focus();
                    return;
                }

                if (cboMaHang.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn Hãng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMaHang.Focus();
                    return;
                }

                sql = "SELECT SUM(cthd.SoLuong) AS TongSoLuong FROM tblNhanVien nv JOIN tblHDBan h ON nv.MaNhanVien = h.MaNhanVien JOIN tblChiTietHDBan cthd ON h.MaHDBan = cthd.MaHDBan JOIN tblMay m ON cthd.MaMay = m.MaMay JOIN tblHang hang ON m.MaHang = hang.MaHang WHERE nv.MaNhanVien = '" + cbonv.SelectedValue + "' AND hang.TenHang = '" + cboMaHang.SelectedValue + "' AND h.NgayBan BETWEEN '" + ngayBatDau + "' AND '" + ngayKetThuc + "'";
                sql2 = "SELECT SUM(cthd.ThanhTien) AS TongDoanhThu FROM tblNhanVien nv JOIN tblHDBan h ON nv.MaNhanVien = h.MaNhanVien JOIN tblChiTietHDBan cthd ON h.MaHDBan = cthd.MaHDBan JOIN tblMay m ON cthd.MaMay = m.MaMay JOIN tblHang hang ON m.MaHang = hang.MaHang WHERE nv.MaNhanVien = '" + cbonv.SelectedValue + "' AND hang.TenHang = '" + cboMaHang.SelectedValue + "' AND h.NgayBan BETWEEN '" + ngayBatDau + "' AND '" + ngayKetThuc + "'";
                sql3 = @"SELECT 
    nv.MaNhanVien,
    nv.TenNhanVien,
    khach.TenKhach,
    h.MaHDBan,
    h.NgayBan,
    may.TenMay, 
    hang.TenHang,
    cthd.SoLuong,
    cthd.DonGia,
    cthd.GiamGia,
    cthd.ThanhTien
FROM tblNhanVien nv
JOIN tblHDBan h ON nv.MaNhanVien = h.MaNhanVien
JOIN tblKhach khach ON h.MaKhach = khach.MaKhach
JOIN tblChiTietHDBan cthd ON h.MaHDBan = cthd.MaHDBan
JOIN tblMay may ON cthd.MaMay = may.MaMay -- Thay đổi từ MaMay thành TenMay
JOIN tblHang hang ON may.MaHang = hang.MaHang
WHERE nv.MaNhanVien = '" + cbonv.SelectedValue + "' AND hang.TenHang = '" + cboMaHang.SelectedValue + "' AND h.NgayBan BETWEEN '" + ngayBatDau + "' AND '" + ngayKetThuc + "'";
                txtSoluong.Text = Functions.GetFieldValues(sql);
                txtDoanhThu.Text = Functions.GetFieldValues(sql2);
                tblH = Functions.GetDataToTable(sql3);
                dgvMay.DataSource = tblH;
                dgvMay.Columns[0].Visible = false;
                dgvMay.Columns[1].HeaderText = "Tên nhân viên";
                dgvMay.Columns[2].HeaderText = "Tên khách";
                dgvMay.Columns[3].HeaderText = "Mã hóa đơn";
                dgvMay.Columns[4].HeaderText = "Ngày bán";
                dgvMay.Columns[5].HeaderText = "Sản phẩm";
                dgvMay.Columns[6].HeaderText = "Hãng";
                dgvMay.Columns[7].HeaderText = "Số lương";
                dgvMay.Columns[8].HeaderText = "Đơn giá";
                dgvMay.Columns[9].HeaderText = "Giảm giá";
                dgvMay.Columns[10].HeaderText = "Thành tiền";

                dgvMay.Columns[0].Visible = false;
                dgvMay.Columns[1].Width = 100;
                dgvMay.Columns[2].Width = 100;
                dgvMay.Columns[3].Width = 100;
                dgvMay.Columns[4].Width = 80;
                dgvMay.Columns[5].Width = 80;
                dgvMay.Columns[6].Width = 80;
                dgvMay.Columns[7].Width = 80;
                dgvMay.Columns[8].Width = 80;
                dgvMay.Columns[9].Width = 80;
                dgvMay.Columns[10].Width = 100;

                dgvMay.AllowUserToAddRows = false;
                dgvMay.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            else if (cbNV.Checked == true && cbN.Checked == true)
            {
                if (cbonv.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbonv.Focus();
                    return;
                }

                sql = "SELECT SUM(cthd.SoLuong) AS TongSoLuong FROM tblNhanVien nv JOIN tblHDBan h ON nv.MaNhanVien = h.MaNhanVien JOIN tblChiTietHDBan cthd ON h.MaHDBan = cthd.MaHDBan WHERE nv.MaNhanVien = '" + cbonv.SelectedValue + "' AND h.NgayBan BETWEEN '" + ngayBatDau + "' AND '" + ngayKetThuc + "'";
                sql2 = "SELECT SUM(cthd.ThanhTien) AS TongDoanhThu FROM tblNhanVien nv JOIN tblHDBan h ON nv.MaNhanVien = h.MaNhanVien JOIN tblChiTietHDBan cthd ON h.MaHDBan = cthd.MaHDBan WHERE nv.MaNhanVien = '" + cbonv.SelectedValue + "' AND h.NgayBan BETWEEN '" + ngayBatDau + "' AND '" + ngayKetThuc + "'";
                sql3 = @"SELECT 
    nv.MaNhanVien,
    nv.TenNhanVien,
    khach.TenKhach,
    h.MaHDBan,
    h.NgayBan,
    may.TenMay,
    hang.TenHang,
    cthd.SoLuong,
    cthd.DonGia,
    cthd.GiamGia,
    cthd.ThanhTien
FROM tblNhanVien nv
JOIN tblHDBan h ON nv.MaNhanVien = h.MaNhanVien
JOIN tblKhach khach ON h.MaKhach = khach.MaKhach
JOIN tblChiTietHDBan cthd ON h.MaHDBan = cthd.MaHDBan
JOIN tblMay may ON cthd.MaMay = may.MaMay
JOIN tblHang hang ON may.MaHang = hang.MaHang
WHERE nv.MaNhanVien = '" + cbonv.SelectedValue + "' AND h.NgayBan BETWEEN '" + ngayBatDau + "' AND '" + ngayKetThuc + "'";
                txtSoluong.Text = Functions.GetFieldValues(sql);
                txtDoanhThu.Text = Functions.GetFieldValues(sql2);
                tblH = Functions.GetDataToTable(sql3);
                dgvMay.DataSource = tblH;
                dgvMay.Columns[0].HeaderText = "Mã nhân viên";
                dgvMay.Columns[1].HeaderText = "Tên nhân viên";
                dgvMay.Columns[2].HeaderText = "Tên khách";
                dgvMay.Columns[3].HeaderText = "Mã hóa đơn";
                dgvMay.Columns[4].HeaderText = "Ngày bán";
                dgvMay.Columns[5].HeaderText = "Sản phẩm";
                dgvMay.Columns[6].HeaderText = "Hãng";
                dgvMay.Columns[7].HeaderText = "Số lương";
                dgvMay.Columns[8].HeaderText = "Đơn giá";
                dgvMay.Columns[9].HeaderText = "Giảm giá";
                dgvMay.Columns[10].HeaderText = "Thành tiền";

                dgvMay.Columns[0].Width = 100;
                dgvMay.Columns[1].Width = 100;
                dgvMay.Columns[2].Width = 100;
                dgvMay.Columns[3].Width = 100;
                dgvMay.Columns[4].Width = 80;
                dgvMay.Columns[5].Width = 80;
                dgvMay.Columns[6].Width = 80;
                dgvMay.Columns[7].Width = 80;
                dgvMay.Columns[8].Width = 80;
                dgvMay.Columns[9].Width = 80;
                dgvMay.Columns[10].Width = 100;

                dgvMay.AllowUserToAddRows = false;
                dgvMay.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            else if (cbNV.Checked == true && cbCH.Checked == true)
            {
                if (cbonv.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbonv.Focus();
                    return;
                }

                if (cboMaHang.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn Hãng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMaHang.Focus();
                    return;
                }
                sql = "SELECT SUM(cthd.SoLuong) AS TongSoLuong FROM tblChiTietHDBan AS cthd INNER JOIN  tblMay AS m ON cthd.MaMay = m.MaMay INNER JOIN  tblHang AS h ON m.MaHang = h.MaHang INNER JOIN tblHDBan AS hdb ON cthd.MaHDBan = hdb.MaHDBan INNER JOIN  tblNhanVien AS nv ON hdb.MaNhanVien = nv.MaNhanVien WHERE nv.MaNhanVien = '" + cbonv.SelectedValue + "' AND h.TenHang = '" + cboMaHang.SelectedValue + "'";
                sql2 = "SELECT SUM(cthd.ThanhTien) AS TongDoanhThu FROM tblChiTietHDBan AS cthd INNER JOIN  tblMay AS m ON cthd.MaMay = m.MaMay INNER JOIN  tblHang AS h ON m.MaHang = h.MaHang INNER JOIN tblHDBan AS hdb ON cthd.MaHDBan = hdb.MaHDBan INNER JOIN  tblNhanVien AS nv ON hdb.MaNhanVien = nv.MaNhanVien WHERE nv.MaNhanVien = '" + cbonv.SelectedValue + "' AND h.TenHang = '" + cboMaHang.SelectedValue + "'";
                sql3 = @"SELECT 
    nv.MaNhanVien,
    nv.TenNhanVien,
    khach.TenKhach,
    h.MaHDBan,
    h.NgayBan,
    may.TenMay,
    hang.TenHang,
    cthd.SoLuong,
    cthd.DonGia,
    cthd.GiamGia,
    cthd.ThanhTien
FROM tblNhanVien nv
JOIN tblHDBan h ON nv.MaNhanVien = h.MaNhanVien
JOIN tblKhach khach ON h.MaKhach = khach.MaKhach
JOIN tblChiTietHDBan cthd ON h.MaHDBan = cthd.MaHDBan
JOIN tblMay may ON cthd.MaMay = may.MaMay
JOIN tblHang hang ON may.MaHang = hang.MaHang
WHERE nv.MaNhanVien = '" + cbonv.SelectedValue + "' AND hang.TenHang = '" + cboMaHang.SelectedValue + "'";
                txtSoluong.Text = Functions.GetFieldValues(sql);
                txtDoanhThu.Text = Functions.GetFieldValues(sql2);
                tblH = Functions.GetDataToTable(sql3);
                dgvMay.DataSource = tblH;
                dgvMay.Columns[0].Visible = false;
                dgvMay.Columns[1].HeaderText = "Tên nhân viên";
                dgvMay.Columns[2].HeaderText = "Mã hóa đơn";
                dgvMay.Columns[3].HeaderText = "Ngày bán";
                dgvMay.Columns[4].HeaderText = "Tên Khách";
                dgvMay.Columns[5].HeaderText = "Sản phẩm";
                dgvMay.Columns[6].HeaderText = "Hãng";
                dgvMay.Columns[7].HeaderText = "Số lương";
                dgvMay.Columns[8].HeaderText = "Đơn giá";
                dgvMay.Columns[9].HeaderText = "Giảm giá";
                dgvMay.Columns[10].HeaderText = "Thành tiền";

                dgvMay.Columns[0].Visible = false;
                dgvMay.Columns[1].Width = 100;
                dgvMay.Columns[2].Width = 100;
                dgvMay.Columns[3].Width = 100;
                dgvMay.Columns[4].Width = 80;
                dgvMay.Columns[5].Width = 80;
                dgvMay.Columns[6].Width = 80;
                dgvMay.Columns[7].Width = 80;
                dgvMay.Columns[8].Width = 80;
                dgvMay.Columns[9].Width = 80;
                dgvMay.Columns[10].Width = 100;
                dgvMay.AllowUserToAddRows = false;
                dgvMay.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            else if (cbCH.Checked == true && cbN.Checked == true)
            {
                if (cboMaHang.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn Hãng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMaHang.Focus();
                    return;
                }

                sql = "SELECT SUM(tblChiTietHDBan.SoLuong) AS TongSoLuong FROM tblHang JOIN tblMay ON tblHang.MaHang = tblMay.MaHang JOIN tblChiTietHDBan ON tblMay.MaMay = tblChiTietHDBan.MaMay WHERE tblHang.TenHang = '" + cboMaHang.SelectedValue + "' AND tblChiTietHDBan.MaHDBan IN( SELECT MaHDBan FROM tblHDBan WHERE NgayBan BETWEEN '" + ngayBatDau + "' AND '" + ngayKetThuc + "' )";
                sql2 = "SELECT SUM(tblChiTietHDBan.ThanhTien) AS TongSoLuong FROM tblHang JOIN tblMay ON tblHang.MaHang = tblMay.MaHang JOIN tblChiTietHDBan ON tblMay.MaMay = tblChiTietHDBan.MaMay WHERE tblHang.TenHang = '" + cboMaHang.SelectedValue + "' AND tblChiTietHDBan.MaHDBan IN( SELECT MaHDBan FROM tblHDBan WHERE NgayBan BETWEEN '" + ngayBatDau + "' AND '" + ngayKetThuc + "' )";
                sql3 = @"SELECT h.MaNhanVien, nv.TenNhanVien, h.MaHDBan, h.NgayBan, khach.TenKhach, may.TenMay, '" + cboMaHang.SelectedValue + "' AS TenHang, cthd.SoLuong, cthd.DonGia, cthd.GiamGia, cthd.ThanhTien FROM tblHDBan h JOIN tblNhanVien nv ON h.MaNhanVien = nv.MaNhanVien JOIN tblKhach khach ON h.MaKhach = khach.MaKhach JOIN tblChiTietHDBan cthd ON h.MaHDBan = cthd.MaHDBan JOIN tblMay may ON cthd.MaMay = may.MaMay JOIN tblHang hang ON may.MaHang = hang.MaHang WHERE hang.TenHang = '" + cboMaHang.SelectedValue + "' AND h.NgayBan BETWEEN  '" + ngayBatDau + "' AND '" + ngayKetThuc + "'";
                txtSoluong.Text = Functions.GetFieldValues(sql);
                txtDoanhThu.Text = Functions.GetFieldValues(sql2);
                tblH = Functions.GetDataToTable(sql3);
                dgvMay.DataSource = tblH;
                dgvMay.Columns[0].HeaderText = "Mã nhân viên";
                dgvMay.Columns[1].HeaderText = "Tên nhân viên";
                dgvMay.Columns[2].HeaderText = "Mã hóa đơn";
                dgvMay.Columns[3].HeaderText = "Ngày bán";
                dgvMay.Columns[4].HeaderText = "Tên Khách";
                dgvMay.Columns[5].HeaderText = "Sản phẩm";
                dgvMay.Columns[6].HeaderText = "Hãng";
                dgvMay.Columns[7].HeaderText = "Số lương";
                dgvMay.Columns[8].HeaderText = "Đơn giá";
                dgvMay.Columns[9].HeaderText = "Giảm giá";
                dgvMay.Columns[10].HeaderText = "Thành tiền";

                dgvMay.Columns[0].Width = 100;
                dgvMay.Columns[1].Width = 100;
                dgvMay.Columns[2].Width = 100;
                dgvMay.Columns[3].Width = 100;
                dgvMay.Columns[4].Width = 80;
                dgvMay.Columns[5].Width = 80;
                dgvMay.Columns[6].Width = 80;
                dgvMay.Columns[7].Width = 80;
                dgvMay.Columns[8].Width = 80;
                dgvMay.Columns[9].Width = 80;
                dgvMay.Columns[10].Width = 100;

                dgvMay.AllowUserToAddRows = false;
                dgvMay.EditMode = DataGridViewEditMode.EditProgrammatically;

            }
            else if (cbN.Checked == true)
            {


                sql = "SELECT SUM(cthd.SoLuong) AS TongSoLuong FROM tblHDBan h JOIN tblChiTietHDBan cthd ON h.MaHDBan = cthd.MaHDBan WHERE h.NgayBan BETWEEN '" + ngayBatDau + "' AND '" + ngayKetThuc + "'";
                sql2 = "SELECT SUM(cthd.ThanhTien) AS TongDoanhThu FROM tblHDBan h JOIN tblChiTietHDBan cthd ON h.MaHDBan = cthd.MaHDBan WHERE h.NgayBan BETWEEN '" + ngayBatDau + "' AND '" + ngayKetThuc + "'";
                sql3 = @"SELECT 
    nv.MaNhanVien,
    nv.TenNhanVien,
    khach.TenKhach,
    h.MaHDBan,
    h.NgayBan,
    may.TenMay,
    hang.TenHang,
    cthd.SoLuong,
    cthd.DonGia,
    cthd.GiamGia,
    cthd.ThanhTien
FROM tblNhanVien nv
JOIN tblHDBan h ON nv.MaNhanVien = h.MaNhanVien
JOIN tblKhach khach ON h.MaKhach = khach.MaKhach
JOIN tblChiTietHDBan cthd ON h.MaHDBan = cthd.MaHDBan
JOIN tblMay may ON cthd.MaMay = may.MaMay
JOIN tblHang hang ON may.MaHang = hang.MaHang
WHERE h.NgayBan BETWEEN '" + ngayBatDau + "' AND '" + ngayKetThuc + "'";
                txtSoluong.Text = Functions.GetFieldValues(sql);
                txtDoanhThu.Text = Functions.GetFieldValues(sql2);
                tblH = Functions.GetDataToTable(sql3);
                dgvMay.DataSource = tblH;
                dgvMay.Columns[0].Visible = false;
                dgvMay.Columns[1].HeaderText = "Tên nhân viên";
                dgvMay.Columns[2].HeaderText = "Tên khách";
                dgvMay.Columns[3].HeaderText = "Mã hóa đơn";
                dgvMay.Columns[4].HeaderText = "Ngày bán";
                dgvMay.Columns[5].HeaderText = "Sản phẩm";
                dgvMay.Columns[6].HeaderText = "Hãng";
                dgvMay.Columns[7].HeaderText = "Số lương";
                dgvMay.Columns[8].HeaderText = "Đơn giá";
                dgvMay.Columns[9].HeaderText = "Giảm giá";
                dgvMay.Columns[10].HeaderText = "Thành tiền";

                dgvMay.Columns[0].Visible = false;
                dgvMay.Columns[1].Width = 100;
                dgvMay.Columns[2].Width = 100;
                dgvMay.Columns[3].Width = 100;
                dgvMay.Columns[4].Width = 80;
                dgvMay.Columns[5].Width = 80;
                dgvMay.Columns[6].Width = 80;
                dgvMay.Columns[7].Width = 80;
                dgvMay.Columns[8].Width = 80;
                dgvMay.Columns[9].Width = 80;
                dgvMay.Columns[10].Width = 100;

                dgvMay.AllowUserToAddRows = false;
                dgvMay.EditMode = DataGridViewEditMode.EditProgrammatically;

            }
            else if (cbNV.Checked == true)
            {

                if (cbonv.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbonv.Focus();
                    return;
                }
                sql = "SELECT  SUM(cthd.SoLuong) AS TongSoLuong FROM tblChiTietHDBan AS cthd INNER JOIN  tblHDBan AS hdb ON cthd.MaHDBan = hdb.MaHDBan WHERE  hdb.MaNhanVien = '" + cbonv.SelectedValue + "'";
                sql2 = "SELECT  SUM(cthd.ThanhTien) AS TongDoanhThu FROM tblChiTietHDBan AS cthd INNER JOIN  tblHDBan AS hdb ON cthd.MaHDBan = hdb.MaHDBan WHERE  hdb.MaNhanVien = '" + cbonv.SelectedValue + "'";
                sql3 = @"SELECT 
    nv.MaNhanVien,
    nv.TenNhanVien,
    khach.TenKhach,
    h.MaHDBan,
    h.NgayBan,
    may.TenMay,
    hang.TenHang,
    cthd.SoLuong,
    cthd.DonGia,
    cthd.GiamGia,
    cthd.ThanhTien
FROM tblNhanVien nv
JOIN tblHDBan h ON nv.MaNhanVien = h.MaNhanVien
JOIN tblKhach khach ON h.MaKhach = khach.MaKhach
JOIN tblChiTietHDBan cthd ON h.MaHDBan = cthd.MaHDBan
JOIN tblMay may ON cthd.MaMay = may.MaMay
JOIN tblHang hang ON may.MaHang = hang.MaHang
WHERE nv.MaNhanVien = '" + cbonv.SelectedValue + "'";
                txtSoluong.Text = Functions.GetFieldValues(sql);
                txtDoanhThu.Text = Functions.GetFieldValues(sql2);
                tblH = Functions.GetDataToTable(sql3);
                dgvMay.DataSource = tblH;
                dgvMay.Columns[0].Visible = false;
                dgvMay.Columns[1].HeaderText = "Tên nhân viên";
                dgvMay.Columns[2].HeaderText = "Tên khách";
                dgvMay.Columns[3].HeaderText = "Mã hóa đơn";
                dgvMay.Columns[4].HeaderText = "Ngày bán";
                dgvMay.Columns[5].HeaderText = "Sản phẩm";
                dgvMay.Columns[6].HeaderText = "Hãng";
                dgvMay.Columns[7].HeaderText = "Số lương";
                dgvMay.Columns[8].HeaderText = "Đơn giá";
                dgvMay.Columns[9].HeaderText = "Giảm giá";
                dgvMay.Columns[10].HeaderText = "Thành tiền";

                dgvMay.Columns[0].Visible = false;
                dgvMay.Columns[1].Width = 100;
                dgvMay.Columns[2].Width = 100;
                dgvMay.Columns[3].Width = 100;
                dgvMay.Columns[4].Width = 80;
                dgvMay.Columns[5].Width = 80;
                dgvMay.Columns[6].Width = 80;
                dgvMay.Columns[7].Width = 80;
                dgvMay.Columns[8].Width = 80;
                dgvMay.Columns[9].Width = 80;
                dgvMay.Columns[10].Width = 100;

                dgvMay.AllowUserToAddRows = false;
                dgvMay.EditMode = DataGridViewEditMode.EditProgrammatically;


            }
            else if (cbCH.Checked == true)
            {

                if (cboMaHang.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn hãng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMaHang.Focus();
                    return;
                }
                sql = "SELECT SUM(cthd.SoLuong) AS TongSoLuong FROM tblChiTietHDBan AS cthd INNER JOIN tblMay AS m ON cthd.MaMay = m.MaMay INNER JOIN tblHang AS h ON m.MaHang = h.MaHang WHERE h.TenHang = '" + cboMaHang.SelectedValue + "' ";
                sql2 = "SELECT SUM(cthd.ThanhTien) AS TongDoanhThu FROM tblChiTietHDBan AS cthd INNER JOIN tblMay AS m ON cthd.MaMay = m.MaMay INNER JOIN tblHang AS h ON m.MaHang = h.MaHang WHERE h.TenHang = '" + cboMaHang.SelectedValue + "' ";
                sql3 = @"SELECT 
    nv.MaNhanVien,
    nv.TenNhanVien,
    khach.TenKhach,
    h.MaHDBan,
    h.NgayBan,
    may.TenMay,
    hang.TenHang,
    cthd.SoLuong,
    cthd.DonGia,
    cthd.GiamGia,
    cthd.ThanhTien
FROM tblNhanVien nv
JOIN tblHDBan h ON nv.MaNhanVien = h.MaNhanVien
JOIN tblKhach khach ON h.MaKhach = khach.MaKhach
JOIN tblChiTietHDBan cthd ON h.MaHDBan = cthd.MaHDBan
JOIN tblMay may ON cthd.MaMay = may.MaMay
JOIN tblHang hang ON may.MaHang = hang.MaHang
WHERE hang.TenHang = '" + cboMaHang.SelectedValue + "'";
                txtSoluong.Text = Functions.GetFieldValues(sql);
                txtDoanhThu.Text = Functions.GetFieldValues(sql2);
                tblH = Functions.GetDataToTable(sql3);
                dgvMay.DataSource = tblH;
                dgvMay.Columns[0].Visible = false;
                dgvMay.Columns[1].HeaderText = "Tên nhân viên";
                dgvMay.Columns[2].HeaderText = "Tên khách";
                dgvMay.Columns[3].HeaderText = "Mã hóa đơn";
                dgvMay.Columns[4].HeaderText = "Ngày bán";
                dgvMay.Columns[5].HeaderText = "Sản phẩm";
                dgvMay.Columns[6].HeaderText = "Hãng";
                dgvMay.Columns[7].HeaderText = "Số lương";
                dgvMay.Columns[8].HeaderText = "Đơn giá";
                dgvMay.Columns[9].HeaderText = "Giảm giá";
                dgvMay.Columns[10].HeaderText = "Thành tiền";

                dgvMay.Columns[0].Visible = false;
                dgvMay.Columns[1].Width = 100;
                dgvMay.Columns[2].Width = 100;
                dgvMay.Columns[3].Width = 100;
                dgvMay.Columns[4].Width = 80;
                dgvMay.Columns[5].Width = 80;
                dgvMay.Columns[6].Width = 80;
                dgvMay.Columns[7].Width = 80;
                dgvMay.Columns[8].Width = 80;
                dgvMay.Columns[9].Width = 80;
                dgvMay.Columns[10].Width = 100;

                dgvMay.AllowUserToAddRows = false;
                dgvMay.EditMode = DataGridViewEditMode.EditProgrammatically;


            }
            else if (cbNV.Checked == false && cbCH.Checked == false && cbN.Checked == false)
            {
                txtSoluong.Text = "";
                txtDoanhThu.Text = "";
                dgvMay.DataSource = false;
                MessageBox.Show("Bạn phải chọn phương thức hiển thị doanh số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaHang.Focus();
                return;
            }
            }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtSLTong_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            str = "SELECT TenMay FROM tblMay WHERE MaMay =N'" + cbonv.SelectedValue + "'";
            cbonv.Text = Functions.GetFieldValues(str);
        }

        private void cbNV_Click(object sender, EventArgs e)
        {
            if (cbNV.Checked == true)
            {
                cbonv.Enabled = true;
            }
            else
            {
                cbonv.Enabled = false;
                cbonv.Text = "";
            }
        }

        private void cbCH_Click(object sender, EventArgs e)
        {
            if (cbCH.Checked == true)
            {
                cboMaHang.Enabled = true;
            }
            else
            {
                cboMaHang.Enabled = false;
                cboMaHang.Text = "";
            }
        }

        private void txtDTTong_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbN_Click(object sender, EventArgs e)
        {
            if (cbN.Checked == true)
            {
                dtpickBD.Enabled = true;
                dtpickKT.Enabled = true;
            }
            else
            {
                dtpickBD.Enabled = false;
                dtpickKT.Enabled = false;
            }
        }

        private void btnct_Click(object sender, EventArgs e)
        {
            frmChiTietTong fr = new frmChiTietTong();
            fr.ShowDialog();
        }
    }
}
