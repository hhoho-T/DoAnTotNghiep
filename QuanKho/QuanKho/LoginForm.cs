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
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace QuanKho
{
    public partial class LoginForm : Form
    {
        public String mnv;

       
        public LoginForm()
        {
            InitializeComponent();
        
        }
        
        private void LoginForm_Load(object sender, EventArgs e)
        {
                Functions.Connect();
            

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string pr = @"[!@#$%^&*(),.?\:{ }|<>]";
            Regex rex = new Regex(pr);

            if (txtuser.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập thông tin tài khoản");
                return;
                if (rex.IsMatch(txtuser.Text))
                {
                    MessageBox.Show("Thông tin bạn nhập chứa kí tự đặc biệt");

                }
            }
            if (txtpass.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập thông tin mật khẩu");
                if (rex.IsMatch(txtpass.Text))
                {
                    MessageBox.Show("Thông tin bạn nhập chứa kí tự đặc biệt");
                    return;
                }
            }

            try

            {
                string sql = "SELECT * FROM tblNhanVien WHERE MaNhanVien = @MaNhanVien AND MatKhau = @MatKhau";
                SqlCommand cmd = new SqlCommand(sql, Functions.Con);
               
                // Thêm các tham số và giá trị tương ứng vào câu truy vấn
                cmd.Parameters.AddWithValue("@MaNhanVien", txtuser.Text);
                cmd.Parameters.AddWithValue("@MatKhau", txtpass.Text);


                // Mở kết nối và thực hiện truy vấn
                Functions.Connect();
                SqlDataReader reader = cmd.ExecuteReader();
              
                if (reader.Read()==true)
                {
                    mnv = txtuser.Text;


                    // Nếu có kết quả, tức là thông tin tài khoản hợp lệ  
                    Functions.Disconnect();

                    // Ẩn form hiện tại và mở form chính
                    this.Hide();
                    frmMain fpc = new frmMain();
                    fpc.ChucVu = mnv;
                     // Truyền giá trị mnv sang frmMain
                    fpc.ShowDialog();
                    this.Close();
                }
                else
                {
                    // Nếu không có kết quả, thông tin tài khoản không hợp lệ
                    MessageBox.Show("Thông tin tài khoản không hợp lệ");
                }

                // Đóng kết nối và đóng đối tượng SqlDataReader
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
