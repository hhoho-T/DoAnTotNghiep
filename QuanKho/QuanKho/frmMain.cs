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
    public partial class frmMain : Form
    {
       
        public frmMain()
        {
            InitializeComponent();
           
        }
        private String mnv;
        private String Macv = "";


        public String ChucVu
        {
            get { return mnv; }
            set { mnv = value; }
        }

        

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Functions.Disconnect(); //Đóng kết nối
            Application.Exit(); //Thoát
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Functions.Connect();
            String sql;
            sql = "SELECT ChucVu FROM tblNhanVien WHERE MaNhanVien = '"+mnv+"'";
            Macv = Functions.GetFieldValues(sql);
            
            //Mở kết nối
            if(Macv != "Quản lý")
            {
                mnuNhanVien.Visible = false;
                mnuBCDoanhThu.Visible = false;
                mnuBCHangTon.Visible = false;
                nhậpHàngToolStripMenuItem.Visible = false;
            }

            nhậpHàngToolStripMenuItem.Visible = false;
        }
       
        private void mnuHang_Click(object sender, EventArgs e)
        {
            frmDMHang frmDMHang = new frmDMHang(); //Khởi tạo đối tượng
            frmDMHang.ChucVuhang = mnv;
            frmDMHang.ShowDialog(); //Hiển thị
            
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            frmDMNhanvien frmDMNhanvien = new frmDMNhanvien(); //Khởi tạo đối tượng
            frmDMNhanvien.ShowDialog(); //Hiển thị
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            frmDMKhachHang frmDMKhachHang = new frmDMKhachHang(); //Khởi tạo đối tượng
            frmDMKhachHang.ShowDialog(); //Hiển thị
        }

        private void mnuHangHoa_Click(object sender, EventArgs e)
        {
            frmDMHangHoa frmDMHangHoa = new frmDMHangHoa("");
            frmDMHangHoa.ChucVuhoa = mnv;//Khởi tạo đối tượng
            frmDMHangHoa.ShowDialog(); //Hiển thị
          
        }

        private void mnuHoaDonBan_Click(object sender, EventArgs e)
        {
            frmHoaDonBan frmHoaDonBan = new frmHoaDonBan(); //Khởi tạo đối tượng
            frmHoaDonBan.ChucVuhoadon = mnv;
            frmHoaDonBan.ShowDialog(); //Hiển thị
        }

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void mnuBCHangTon_Click(object sender, EventArgs e)
        {
            frmHangTon frmht = new frmHangTon(); //Khởi tạo đối tượng
            frmht.ShowDialog();

        }
      

        private void mnuBCDoanhThu_Click(object sender, EventArgs e)
        {

            frmDMDoanhThu frmDT = new frmDMDoanhThu(); //Khởi tạo đối tượng
            frmDT.ShowDialog(); //Hiển thị

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm f = new LoginForm();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void tìmĐơnĐãXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimHDBan frmTimHDBan = new frmTimHDBan(); //Khởi tạo đối tượng
            frmTimHDBan.ShowDialog(); //Hiển thị
        }

        private void tìmHàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimHH frmTimHH = new frmTimHH(); //Khởi tạo đối tượng
            frmTimHH.ShowDialog(); //Hiển thị
        }

        private void tìmKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmTimKhach frmTimKhach = new frmTimKhach(); //Khởi tạo đối tượng
            frmTimKhach.ShowDialog(); //Hiển thị
        }

        private void nhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuVaiNet_Click(object sender, EventArgs e)
        {
            frmVaiNet fr = new frmVaiNet();
            fr.ShowDialog();
        }

        private void mnuHienTroGiup_Click(object sender, EventArgs e)
        {
            frmTroGiup rm = new frmTroGiup();
            rm.ShowDialog();
        }

        private void Lichsu_Click(object sender, EventArgs e)
        {
            frmLichSu rm = new frmLichSu();
            rm.ShowDialog();
        }
    }
}
