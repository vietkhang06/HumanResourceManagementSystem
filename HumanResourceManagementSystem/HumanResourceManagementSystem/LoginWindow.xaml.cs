using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HumanResourceManagementSystem
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        // Sự kiện khi Window tải xong
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetRandomBackgroundImage();
        }

        // Hàm Random ảnh nền (Đã sửa để tương thích với Border bo góc)
        private void SetRandomBackgroundImage()
        {
            try
            {
                List<string> imagePaths = new List<string>()
                {
                    "Images/png1.png",
                    "Images/png2.png",
                    // Thêm ảnh khác vào đây nếu muốn
                };

                Random rnd = new Random();
                int index = rnd.Next(imagePaths.Count);

                // 1. Tạo BitmapImage từ đường dẫn
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                // Lưu ý: Đảm bảo Build Action của ảnh là "Resource"
                bitmap.UriSource = new Uri($"pack://application:,,,/{imagePaths[index]}", UriKind.Absolute);
                bitmap.EndInit();

                // 2. Tạo ImageBrush (Bút vẽ bằng ảnh)
                ImageBrush imgBrush = new ImageBrush();
                imgBrush.ImageSource = bitmap;
                imgBrush.Stretch = Stretch.UniformToFill;
                imgBrush.Opacity = 0.9;

                // 3. Gán Brush này làm nền cho Border bên phải
                RightBorder.Background = imgBrush;
            }
            catch (Exception ex)
            {
                // Nếu lỗi (ví dụ không tìm thấy ảnh), set màu nền mặc định để không bị trắng bệch
                RightBorder.Background = new SolidColorBrush(Color.FromRgb(240, 240, 240));
                MessageBox.Show("Không thể tải ảnh nền: " + ex.Message);
            }
        }

        // Kéo thả cửa sổ
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        // Nút Login
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Logic đăng nhập của bạn
            MessageBox.Show("Đang đăng nhập...");
        }

        // Nút Tắt
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}