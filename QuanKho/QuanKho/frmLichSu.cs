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
    public partial class frmLichSu : Form
    {
        public frmLichSu()
        {
            InitializeComponent();
        }
        DataTable tblHH;
        private void frmLichSu_Load(object sender, EventArgs e)
        {
            Functions.Connect();
            LoadDataGridView();
            LoadDataGridView2();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void LoadDataGridView()
        {
            string sql;
            sql = @"
SELECT 
    m.MaMay,
    m.TenMay,
    m.MaHang,
    m.SoLuong AS SoLuongHienTai,
    0 AS SoLuongDuocThem, 
    m.SoLuong AS SoLuongSauKhiThem, 
    m.DonGiaNhap,
    m.DonGiaBan,
    m.Anh,
    m.GhiChu,
    m.Ngaynhap AS NgayThayDoi
FROM tblMay m

UNION ALL

-- Hiển thị dữ liệu từ bảng tblMayHistory 
SELECT 
    mh.MaMay,
    m.TenMay,
    m.MaHang,
    mh.OldSoLuong AS SoLuongHienTai, 
    mh.OldSoLuong + mh.NewSoLuong AS SoLuongDuocThem, 
    mh.NewSoLuong AS SoLuongSauKhiThem, 
    m.DonGiaNhap,
    m.DonGiaBan,
    m.Anh,
    m.GhiChu,
    mh.NgayThayDoi
FROM tblMayHistory mh
JOIN tblMay m ON mh.MaMay = m.MaMay

ORDER BY MaMay, NgayThayDoi;
";
            tblHH = Functions.GetDataToTable(sql);
            dataGridView1.DataSource = tblHH;
            dataGridView1.Columns[0].HeaderText = "Mã hàng";
            dataGridView1.Columns[1].HeaderText = "Tên hàng";
            dataGridView1.Columns[2].HeaderText = "Mã hãng";
            dataGridView1.Columns[3].HeaderText = "Số lượng hiện tại";
            dataGridView1.Columns[4].HeaderText = "Số lượng được thêm vào";
            dataGridView1.Columns[5].HeaderText = "Số lượng sau khi thêm";
            dataGridView1.Columns[6].HeaderText = "Đơn giá nhập";
            dataGridView1.Columns[7].HeaderText = "Đơn giá bán";
            dataGridView1.Columns[8].HeaderText = "Ảnh";
            dataGridView1.Columns[9].HeaderText = "Ghi chú";
            dataGridView1.Columns[10].HeaderText = "Ngày nhập hoặc thêm số lượng";
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Width = 200;
            dataGridView1.Columns[7].Width = 200;
            dataGridView1.Columns[8].Width = 200;
            dataGridView1.Columns[9].Width = 200;
            dataGridView1.Columns[10].Width = 200;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void LoadDataGridView2()
        {
            string sql;
            sql = @"
SELECT 
    cthd.MaHDBan,
    h.NgayBan,
    nv.TenNhanVien,
    kh.TenKhach,
    m.TenMay,
    hang.TenHang,
    cthd.SoLuong,
    cthd.DonGia,
    cthd.GiamGia,
    cthd.ThanhTien
FROM 
    tblChiTietHDBan AS cthd
INNER JOIN 
    tblMay AS m ON cthd.MaMay = m.MaMay
INNER JOIN 
    tblHDBan AS h ON cthd.MaHDBan = h.MaHDBan
INNER JOIN 
    tblKhach AS kh ON h.MaKhach = kh.MaKhach
INNER JOIN 
    tblNhanVien AS nv ON h.MaNhanVien = nv.MaNhanVien
INNER JOIN 
    tblHang AS hang ON m.MaHang = hang.MaHang;";
            tblHH = Functions.GetDataToTable(sql);
            dataGridView2.DataSource = tblHH;
            dataGridView2.Columns[0].HeaderText = "Mã hóa đơn bán";
            dataGridView2.Columns[1].HeaderText = "Ngày bán";
            dataGridView2.Columns[2].HeaderText = "Tên nhân viên";
            dataGridView2.Columns[3].HeaderText = "Tên khách";
            dataGridView2.Columns[4].HeaderText = "Tên Máy";
            dataGridView2.Columns[5].HeaderText = "Tên Hãng";
            dataGridView2.Columns[6].HeaderText = "Số lượng";
            dataGridView2.Columns[7].HeaderText = "Đơn giá";
            dataGridView2.Columns[8].HeaderText = "Giảm giá(%)";
            dataGridView2.Columns[9].HeaderText = "Thành tiền";
            dataGridView2.Columns[0].Width = 80;
            dataGridView2.Columns[1].Width = 140;
            dataGridView2.Columns[2].Width = 80;
            dataGridView2.Columns[3].Width = 80;
            dataGridView2.Columns[4].Width = 100;
            dataGridView2.Columns[5].Width = 100;
            dataGridView2.Columns[6].Width = 100;
            dataGridView2.Columns[7].Width = 100;
            dataGridView2.Columns[8].Width = 100;
            dataGridView2.Columns[9].Width = 100;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
    }
}
