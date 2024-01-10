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
using DentalClinicManagement.Dentist.Class;

namespace DentalClinicManagement.Dentist
{
    /// <summary>
    /// Interaction logic for ViewPaymentList.xaml
    /// </summary>
    public partial class ViewPaymentList : Page
    {
        Patient patient;
        public ObservableCollection<Payment> paymentList { get; set; } = new ObservableCollection<Payment>();
        public ObservableCollection<PaymentDetail> paymentDetailList { get; set; } = new ObservableCollection<PaymentDetail>();

        public ViewPaymentList(Patient patient)
        {
            InitializeComponent();
            this.patient = new Patient(patient);
            LoadPaymentListByPatient(patient);
            LoadPaymentDetailList();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.ViewPatientRecord(patient));
            }
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.DashBoard());
            }
        }

        private void AddNewPaymentButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thêm mới.");

        }

        private void PaymentList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is DataGrid dataGrid && dataGrid.SelectedItem is PaymentDetail paymentDetail)
            {
                MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

                if (mainWindow != null && mainWindow.MainFrame != null)
                {
                    Payment payment = LoadPaymentByPaymentDetail(paymentDetail);
                    mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.ViewPaymentDetail(patient, payment, paymentDetail));
                }
            }
        }

        private Payment LoadPaymentByPaymentDetail(PaymentDetail paymentDetail)
        {
            try
            {
                // Câu truy vấn SQL để lấy thông tin Payment từ database
                string query = "SELECT TOP 1* FROM [Payment] " +
                    "WHERE @PaymentID = PaymentID";

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
                                // Tạo đối tượng Patient từ SqlDataReader
                                Payment payment = new Payment(reader);
                                return payment;
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

        private void LoadPaymentListByPatient(Patient patient)
        {
            try
            {
                // Câu truy vấn SQL để lấy thông tin AppointmentRequest từ database
                string query = "SELECT * FROM [Payment] " +
                    "WHERE @PatientID = PatientID";

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
                                paymentList.Add(payment);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void LoadPaymentDetailList()
        {
            foreach (Payment payment in paymentList)
            {
                int? paymentID = payment.PaymentID;
                try
                {
                    // Câu truy vấn SQL để lấy thông tin AppointmentRequest từ database
                    string query = "SELECT * FROM [Payment Detail] " +
                        "WHERE @PaymentID = PaymentID";

                    // Tạo và mở kết nối
                    DB dB = new DB();
                    using (SqlConnection connection = dB.Connection)
                    {
                        // Tạo đối tượng SqlCommand
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Thêm tham số cho câu truy vấn
                            command.Parameters.AddWithValue("@PaymentID", paymentID);

                            // Thực hiện truy vấn SQL và lấy dữ liệu
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    PaymentDetail paymentDetail = new PaymentDetail(reader);
                                    paymentDetailList.Add(paymentDetail);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            // Gán ObservableCollection làm nguồn dữ liệu cho DataGrid
            PaymentListDataGrid.ItemsSource = paymentDetailList;
        }
    }
}
