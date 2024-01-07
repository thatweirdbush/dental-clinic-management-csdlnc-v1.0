using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DentalClinicManagement.Admin
{
    /// <summary>
    /// Interaction logic for ViewRecord.xaml
    /// </summary>
    public partial class ViewRecord : Page
    {
        public ObservableCollection<KhamBenh> KhamBenhList { get; set; }

        public ViewRecord()
        {
            InitializeComponent();

            // Khởi tạo danh sách và thêm dữ liệu mẫu
            KhamBenhList = new ObservableCollection<KhamBenh>
            {
                new KhamBenh { NgayKham = DateTime.Now, TinhTrang = "Bình thường", Thuoc = "Paracetamol", NgayTaiKham = DateTime.Now.AddDays(7), BacSi = "Dr. Nguyen", ThanhToan = 10000 },
                new KhamBenh { NgayKham = DateTime.Now.AddDays(-1), TinhTrang = "Cần theo dõi", Thuoc = "Amoxicillin", NgayTaiKham = DateTime.Now.AddDays(10), BacSi = "Dr. Tran", ThanhToan = 15000 },
                new KhamBenh { NgayKham = DateTime.Now.AddDays(-3), TinhTrang = "Khẩn cấp", Thuoc = "Ibuprofen", NgayTaiKham = DateTime.Now.AddDays(5), BacSi = "Dr. Pham", ThanhToan = 20000 },
                new KhamBenh { NgayKham = DateTime.Now.AddDays(-5), TinhTrang = "Đã khỏi", Thuoc = "Vitamin C", NgayTaiKham = DateTime.Now.AddDays(15), BacSi = "Dr. Le", ThanhToan = 12000 },
                new KhamBenh { NgayKham = DateTime.Now.AddDays(-7), TinhTrang = "Cần thêm xét nghiệm", Thuoc = "Aspirin", NgayTaiKham = DateTime.Now.AddDays(12), BacSi = "Dr. Hoang", ThanhToan = 18000 },
                new KhamBenh { NgayKham = DateTime.Now.AddDays(-10), TinhTrang = "Bình thường", Thuoc = "Paracetamol", NgayTaiKham = DateTime.Now.AddDays(8), BacSi = "Dr. Nguyen", ThanhToan = 9000 },
                new KhamBenh { NgayKham = DateTime.Now.AddDays(-12), TinhTrang = "Cần theo dõi", Thuoc = "Amoxicillin", NgayTaiKham = DateTime.Now.AddDays(11), BacSi = "Dr. Tran", ThanhToan = 13000 },
                new KhamBenh { NgayKham = DateTime.Now.AddDays(-15), TinhTrang = "Khẩn cấp", Thuoc = "Ibuprofen", NgayTaiKham = DateTime.Now.AddDays(6), BacSi = "Dr. Pham", ThanhToan = 18000 },
                new KhamBenh { NgayKham = DateTime.Now.AddDays(-18), TinhTrang = "Đã khỏi", Thuoc = "Vitamin C", NgayTaiKham = DateTime.Now.AddDays(14), BacSi = "Dr. Le", ThanhToan = 11000 },
                new KhamBenh { NgayKham = DateTime.Now.AddDays(-20), TinhTrang = "Cần thêm xét nghiệm", Thuoc = "Aspirin", NgayTaiKham = DateTime.Now.AddDays(13), BacSi = "Dr. Hoang", ThanhToan = 17000 },
                new KhamBenh { NgayKham = DateTime.Now.AddDays(-25), TinhTrang = "Bình thường", Thuoc = "Paracetamol", NgayTaiKham = DateTime.Now.AddDays(9), BacSi = "Dr. Nguyen", ThanhToan = 11000 },
                new KhamBenh { NgayKham = DateTime.Now.AddDays(-28), TinhTrang = "Cần theo dõi", Thuoc = "Amoxicillin", NgayTaiKham = DateTime.Now.AddDays(12), BacSi = "Dr. Tran", ThanhToan = 14000 },
                new KhamBenh { NgayKham = DateTime.Now.AddDays(-30), TinhTrang = "Khẩn cấp", Thuoc = "Ibuprofen", NgayTaiKham = DateTime.Now.AddDays(7), BacSi = "Dr. Pham", ThanhToan = 19000 },
                new KhamBenh { NgayKham = DateTime.Now.AddDays(-35), TinhTrang = "Đã khỏi", Thuoc = "Vitamin C", NgayTaiKham = DateTime.Now.AddDays(16), BacSi = "Dr. Le", ThanhToan = 13000 },
                new KhamBenh { NgayKham = DateTime.Now.AddDays(-40), TinhTrang = "Cần thêm xét nghiệm", Thuoc = "Aspirin", NgayTaiKham = DateTime.Now.AddDays(14), BacSi = "Dr. Hoang", ThanhToan = 16000 }
            };
            dataGrid.ItemsSource = KhamBenhList;
        }
        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;


            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Admin.DashBoard());
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    public class KhamBenh
    {
        public DateTime NgayKham { get; set; }
        public string TinhTrang { get; set; }
        public string Thuoc { get; set; }
        public DateTime NgayTaiKham { get; set; }
        public string BacSi { get; set; }
        public decimal ThanhToan { get; set; }
    }
}
