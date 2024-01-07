using DentalClinicManagement.Dentist.Class;
using DentalClinicManagement.Employee.Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace DentalClinicManagement.Dentist
{
    /// <summary>
    /// Interaction logic for ViewPaymentDetail.xaml
    /// </summary>
    public partial class ViewPaymentDetail : Page
    {
        PaymentDetail paymentDetail;
        Patient patient;
        public ViewPaymentDetail(Patient patient, PaymentDetail paymentDetail)
        {
            InitializeComponent();
            this.patient = new Patient(patient);
            this.paymentDetail = new PaymentDetail(paymentDetail);

            // Thiết lập DataContext cho Canvas, tất cả các TextBlock con sẽ kế thừa DataContext này
            MainCanvas.DataContext = this.paymentDetail;
        }

        private void TreatingToothListButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.DashBoard());
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.ViewPatientRecord(patient));
            }
        }

        private PaymentDetail LoadPaymentDetail()
        {
            try
            {
                // Câu truy vấn SQL để lấy thông tin Payment Detail từ database dựa trên PaymentID
                string query = "SELECT TOP 1* FROM [Payment Detail] WHERE PaymentID = @PaymentID";

                // Tạo và mở kết nối
                DB dB = new DB();
                using (SqlConnection connection = dB.Connection)
                {
                    // Tạo đối tượng SqlCommand
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số cho câu truy vấn
                        command.Parameters.AddWithValue("@PaymentID", paymentDetail.PaymentID);

                        // Sử dụng SqlDataReader để đọc dữ liệu từ database
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Kiểm tra xem có dữ liệu hay không
                            if (reader.Read())
                            {
                                // Tạo đối tượng PatientRecord từ SqlDataReader
                                PaymentDetail paymentDetail = new PaymentDetail(reader);
                                return paymentDetail;
                            }
                            else
                            {
                                // Trường hợp không tìm thấy thông tin paymentDetail
                                return null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
