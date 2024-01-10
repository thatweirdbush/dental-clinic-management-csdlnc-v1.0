using DentalClinicManagement.Dentist.Class;
using DentalClinicManagement.Employee.Class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DentalClinicManagement.Admin
{
    /// <summary>
    /// Interaction logic for ViewNeedPaymentList.xaml
    /// </summary>
    public partial class ViewNeedPaymentList : Page
    {
        PaymentDetail paymentDetail;
        Payment payment;
        Patient patient;
        public ObservableCollection<Payment> needPaymentList { get; set; } = new ObservableCollection<Payment>();

        public ViewNeedPaymentList(Patient patient, Payment payment, PaymentDetail paymentDetail)
        {
            InitializeComponent();
            this.patient = new Patient(patient);
            this.payment = new Payment(payment);
            this.paymentDetail = new PaymentDetail(paymentDetail);
            LoadNeedPaymentList();
        }
        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Admin.DashBoard());
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Admin.ViewPaymentDetail(patient, payment, paymentDetail));
            }
        }

        private void NeedPaymentList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is DataGrid dataGrid && dataGrid.SelectedItem is Payment thisPayment)
            {
                PaymentDetail thispaymentDetail = LoadPaymentDetailByPayment(thisPayment);

                MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

                if (mainWindow != null && mainWindow.MainFrame != null)
                {
                    mainWindow.MainFrame.Navigate(new DentalClinicManagement.Admin.MakePayment(patient, thisPayment, thispaymentDetail));
                }
            }
        }

        private PaymentDetail LoadPaymentDetailByPayment(Payment payment)
        {
            try
            {
                // Câu truy vấn SQL để lấy thông tin Payment từ database
                string query = "SELECT TOP 1* FROM [Payment Detail] " +
                    "WHERE @PaymentID = PaymentID";

                // Tạo và mở kết nối
                DB dB = new DB();
                using (SqlConnection connection = dB.Connection)
                {
                    // Tạo đối tượng SqlCommand
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số cho câu truy vấn
                        command.Parameters.AddWithValue("@PaymentID", payment.PaymentID);

                        // Sử dụng SqlDataReader để đọc dữ liệu từ database
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Kiểm tra xem có dữ liệu hay không
                            if (reader.Read())
                            {
                                // Tạo đối tượng Patient từ SqlDataReader
                                PaymentDetail paymentDetail = new PaymentDetail(reader);
                                return paymentDetail;
                            }
                            else
                            {
                                // Trường hợp không tìm thấy thông tin payment
                                return null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return null;
            }
        }

        private void LoadNeedPaymentList()
        {
            try
            {
                // Câu truy vấn SQL để lấy thông tin AppointmentRequest từ database
                string query = "SELECT * FROM [Payment] " +
                    "WHERE @PatientID = PatientID AND Status = N'Cần thanh toán'";

                // Tạo và mở kết nối
                DB dB = new DB();
                using (SqlConnection connection = dB.Connection)
                {
                    // Tạo đối tượng SqlCommand
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số cho câu truy vấn
                        command.Parameters.AddWithValue("@PatientID", patient.PatientID);

                        // Thực hiện truy vấn SQL và lấy dữ liệu
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Payment payment = new Payment(reader);
                                needPaymentList.Add(payment);
                            }
                            // Gán ObservableCollection làm nguồn dữ liệu cho DataGrid
                            NeedPaymentListDataGrid.ItemsSource = needPaymentList;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
