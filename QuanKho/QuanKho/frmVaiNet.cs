using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanKho
{
    public partial class frmVaiNet : Form
    {
        public frmVaiNet()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmVaiNet_Load(object sender, EventArgs e)
        {
            txtht.Text = "### Mục Tiêu\n\n" +
    "Phần mềm quản lý kho điện thoại, máy tính được thiết kế nhằm giúp các doanh nghiệp quản lý kho hàng một cách hiệu quả, chính xác và tiện lợi. \nHệ thống này giúp theo dõi và quản lý thông tin về sản phẩm, lượng hàng tồn kho, nhập xuất hàng, cũng như tạo báo cáo chi tiết theo thời gian thực.\n\n" +
    "### Tính Năng Chính\n\n" +
    "1. **Quản lý sản phẩm:**\n" +
    "- Thêm, sửa, xóa và tìm kiếm thông tin sản phẩm (điện thoại, máy tính).\n" +
    "- Hiển thị chi tiết thông tin sản phẩm bao gồm tên, mô tả, giá, số lượng, và vị trí lưu trữ.\n\n" +
    "2. **Quản lý kho hàng:**\n" +
    "- Theo dõi số lượng hàng tồn kho, cập nhật khi có thay đổi về số lượng.\n" +
    "- Quản lý các giao dịch nhập kho, xuất kho và kiểm kê hàng hóa.\n\n" +
    "3. **Quản lý nhập xuất hàng:**\n" +
    "- Ghi nhận các giao dịch nhập kho, xuất kho và kiểm kê hàng hóa.\n" +
    "- Cập nhật tự động số lượng tồn kho khi có giao dịch nhập hoặc xuất.\n\n" +
    "4. **Báo cáo:**\n" +
    "- Tạo báo cáo về tồn kho, nhập xuất hàng theo thời gian thực.\n" +
    "- Báo cáo chi tiết về sản phẩm bán chạy, hàng tồn kho lâu ngày, và doanh số bán hàng.\n\n" +
    "5. **Quản lý tài khoản:**\n" +
    "- Đăng nhập, đăng ký tài khoản và phân quyền người dùng.\n" +
    "- Bảo mật thông tin người dùng và phân quyền truy cập theo chức năng.\n\n" +
    "### Giao Diện Người Dùng\n\n" +
    "1. **Form Đăng Nhập:**\n" +
    "- Gồm các ô nhập tên đăng nhập, mật khẩu và các nút đăng nhập, đăng ký tài khoản.\n\n" +
    "2. **Form Quản Lý Sản Phẩm:**\n" +
    "- Hiển thị danh sách sản phẩm bằng DataGridView.\n" +
    "- Các ô nhập thông tin sản phẩm (tên, mô tả, giá, số lượng, vị trí) và các nút thêm, sửa, xóa sản phẩm.\n\n" +
    "3. **Form Quản Lý Kho:**\n" +
    "- Hiển thị danh sách sản phẩm trong kho bằng DataGridView.\n" +
    "- Các ô nhập số lượng nhập/xuất và các nút nhập hàng, xuất hàng, kiểm kê.\n\n" +
    "4. **Form Báo Cáo:**\n" +
    "- Cho phép người dùng nhập khoảng thời gian và xem báo cáo tồn kho, nhập xuất hàng.\n\n" +
    "### Công Nghệ Sử Dụng\n\n" +
    "- Ngôn ngữ lập trình: C# với WinForms.\n" +
    "- Framework: .NET Framework.\n" +
    "- Cơ sở dữ liệu: SQL Server.\n" +
    "- Thư viện và công cụ: Entity Framework, Visual Studio 2019, SQL Server Management Studio.\n\n" +
    "### Lợi Ích Của Phần Mềm\n\n" +
    "- Tăng hiệu quả quản lý: Giúp quản lý kho hàng nhanh chóng và chính xác hơn.\n" +
    "- Giảm thiểu sai sót: Hạn chế lỗi do con người trong quá trình nhập xuất hàng và kiểm kê.\n" +
    "- Tiết kiệm thời gian: Tự động hóa các quy trình quản lý kho, tạo báo cáo nhanh chóng.\n" +
    "- Nâng cao bảo mật: Bảo vệ dữ liệu kho hàng và thông tin sản phẩm, đảm bảo chỉ người dùng có quyền mới truy cập được.\n\n" +
    "### Hướng Phát Triển Trong Tương Lai\n\n" +
    "- Tích hợp thêm các tính năng phân tích dữ liệu: Đưa ra các dự báo về nhu cầu hàng hóa, xu hướng mua hàng.\n" +
    "- Mở rộng hệ thống lên nền tảng web và mobile: Giúp người dùng có thể quản lý kho hàng mọi lúc, mọi nơi.\n" +
    "- Tích hợp với các hệ thống khác: Như hệ thống kế toán, quản lý bán hàng để đồng bộ dữ liệu và quy trình làm việc.\n\n" +
    "### Hướng Dẫn Sử Dụng\n\n" +
    "1. **Đăng nhập vào hệ thống:** Sử dụng tài khoản và mật khẩu đã đăng ký để truy cập vào phần mềm.\n" +
    "2. **Quản lý sản phẩm:** Sử dụng các chức năng thêm, sửa, xóa để quản lý thông tin sản phẩm trong kho.\n" +
    "3. **Quản lý nhập xuất hàng:** Thực hiện các giao dịch nhập kho, xuất kho để cập nhật số lượng hàng hóa.\n" +
    "4. **Xem báo cáo:** Tạo các báo cáo theo nhu cầu để theo dõi tình trạng kho hàng và hiệu quả hoạt động.\n" +
    "5. **Đăng xuất:** Sau khi hoàn thành công việc, đăng xuất khỏi hệ thống để bảo mật thông tin.\n";
            ;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
          
        }
    }
}
