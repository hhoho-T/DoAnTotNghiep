using System;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace QuanKho
{
    public partial class frmcam : Form
    {
        public frmcam()
        {
            InitializeComponent();
        }

        public delegate void QRCodeScannedEventHandler(string qrCode);
        public event QRCodeScannedEventHandler QRCodeScanned;

        FilterInfoCollection filterInfoCollection; // Biến lưu thông tin vào các thiết bị video
        VideoCaptureDevice videoCaptureDevice; // Biến tương tác với các thiết bị video
        private bool isQRCodeDetected = false; // Biến kiểm tra xem mã QR đã được phát hiện hay chưa

        private void frmcam_Load(object sender, EventArgs e)
        {
            // Lấy ra tất cả danh sách thiết bị video kết nối máy tính
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            // Thêm tên của thiết bị mới
            foreach (FilterInfo device in filterInfoCollection)
            {
                cbm.Items.Add(device.Name);
                cbm.SelectedIndex = 0; // Chọn thiết bị có số đầu tiên trong danh sách
            }
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Nhận frame hình ảnh từ camera
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            BarcodeReader reader = new BarcodeReader(); // Tạo đối tượng đọc qr
            var result = reader.Decode(bitmap); // Đọc mã qr từ hình ảnh
            if (result != null && !isQRCodeDetected)
            {
                isQRCodeDetected = true; // Đánh dấu là đã phát hiện mã QR

                // Dừng camera ngay lập tức
                videoCaptureDevice.SignalToStop();

                // Sử dụng Invoke để cập nhật giao diện người dùng
                this.Invoke(new MethodInvoker(delegate ()
                {
                    txtcode.Text = result.ToString(); // Hiển thị
                    // Kích hoạt sự kiện truyền mã QR
                    QRCodeScanned?.Invoke(result.ToString());
                    // Đóng form sau khi quét xong
                    this.Close();
                }));
            }
            pictureBox1.Image = bitmap; // Hiển thị hình ảnh lên picturebox
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            // Khởi tạo các thiết bị video dựa trên các thiết bị từ combobox
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cbm.SelectedIndex].MonikerString);
            // Đăng ký nhận sự kiện từ frame camera
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
        }

        private void btnstop_Click(object sender, EventArgs e)
        {
            if (videoCaptureDevice != null)
            {
                if (videoCaptureDevice.IsRunning)
                {
                    videoCaptureDevice.SignalToStop();
                    pictureBox1.Image = null;
                }
            }
        }

        private void frmcam_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoCaptureDevice != null)
            {
                if (videoCaptureDevice.IsRunning)
                {
                    videoCaptureDevice.SignalToStop();
                    pictureBox1.Image = null;
                }
            }
        }
    }
}
