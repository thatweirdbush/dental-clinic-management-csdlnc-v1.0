using DentalClinicManagement.Account.Class;
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

namespace DentalClinicManagement.Employee
{
    /// <summary>
    /// Interaction logic for ViewPaymentList.xaml
    /// </summary>
    public partial class ViewPaymentList : Page
    {
        StaffClass staff;
        public ObservableCollection<Payment> paymentList { get; set; } = new ObservableCollection<Payment>();
        public ObservableCollection<PaymentDetail> paymentDetailList { get; set; } = new ObservableCollection<PaymentDetail>();

        public ViewPaymentList(StaffClass staff)
        {
            InitializeComponent();
            this.staff = new StaffClass(staff);
            LoadPayment();
            LoadPaymentDetailList();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Employee.Dashboard(staff));
            }
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Employee.Dashboard(staff));
            }
        }

        private void AddNewPaymentButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PaymentList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is DataGrid dataGrid && dataGrid.SelectedItem is PaymentDetail paymentDetail)
            {
                MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

                if (mainWindow != null && mainWindow.MainFrame != null)
                {
                    mainWindow.MainFrame.Navigate(new DentalClinicManagement.Employee.ViewPaymentDetail(staff, paymentDetail));
                }
            }
        }

        private void LoadPayment()
        {
            try
            {
                // Câu truy vấn SQL để lấy thông tin AppointmentRequest từ database
                string query = "SELECT * FROM [Payment]";

                // Tạo và mở kết nối
                DB dB = new DB();
                using (SqlConnection connection = dB.Connection)
                {
                    // Tạo đối tượng SqlCommand
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
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

        //private void LoadPaymentDetailList()
        //{
        //    foreach (Payment payment in paymentList)
        //    {
        //        int? paymentID = payment.PaymentID;
        //        try
        //        {
        //            // Câu truy vấn SQL để lấy thông tin AppointmentRequest từ database
        //            string query = "SELECT * FROM [Payment Detail] " +
        //                "WHERE @PaymentID = PaymentID";

        //            // Tạo và mở kết nối
        //            DB dB = new DB();
        //            using (SqlConnection connection = dB.Connection)
        //            {
        //                // Tạo đối tượng SqlCommand
        //                using (SqlCommand command = new SqlCommand(query, connection))
        //                {
        //                    // Thêm tham số cho câu truy vấn
        //                    command.Parameters.AddWithValue("@PaymentID", paymentID);

        //                    // Thực hiện truy vấn SQL và lấy dữ liệu
        //                    using (SqlDataReader reader = command.ExecuteReader())
        //                    {
        //                        while (reader.Read())
        //                        {
        //                            PaymentDetail paymentDetail = new PaymentDetail(reader);
        //                            paymentDetailList.Add(paymentDetail);
        //                        }
        //                        // Gán ObservableCollection làm nguồn dữ liệu cho DataGrid
        //                        PaymentListDataGrid.ItemsSource = paymentDetailList;
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Error: {ex.Message}");
        //        }
        //    }
        //}


        private void LoadPaymentDetailList()
        {
            try
            {
                // Câu truy vấn SQL để lấy thông tin AppointmentRequest từ database
                string query = "SELECT * FROM [Payment Detail]";

                // Tạo và mở kết nối
                DB dB = new DB();
                using (SqlConnection connection = dB.Connection)
                {
                    // Tạo đối tượng SqlCommand
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        // Thực hiện truy vấn SQL và lấy dữ liệu
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PaymentDetail paymentDetail = new PaymentDetail(reader);
                                paymentDetailList.Add(paymentDetail);
                            }
                            // Gán ObservableCollection làm nguồn dữ liệu cho DataGrid
                            PaymentListDataGrid.ItemsSource = paymentDetailList;
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
