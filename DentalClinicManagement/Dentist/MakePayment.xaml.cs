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
    /// Interaction logic for MakePayment.xaml
    /// </summary>
    public partial class MakePayment : Page
    {
        PaymentDetail paymentDetail;
        Payment payment;
        Patient patient;

        public MakePayment(Patient patient, Payment payment, PaymentDetail paymentDetail)
        {
            InitializeComponent();
            this.patient = new Patient(patient);
            this.payment = new Payment(payment);
            this.paymentDetail = new PaymentDetail(paymentDetail);

            // Thiết lập DataContext cho Canvas, tất cả các TextBlock con sẽ kế thừa DataContext này
            MainCanvas.DataContext = this.paymentDetail;
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
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.ViewNeedPaymentList(patient, payment, paymentDetail));
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            // Thực hiện cập nhật và lưu vào database
            if (UpdatePaymentDetail())
            {
                MessageBox.Show("Cập nhật thành công.");
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại. Vui lòng thử lại.");
            }
        }

        private PaymentDetail LoadPaymentDetail()
        {
            try
            {
                // Câu truy vấn SQL để lấy thông tin Payment Detail từ database dựa trên PayDetailID
                string query = "SELECT TOP 1* FROM [Payment Detail] WHERE PayDetailID = @PayDetailID";

                // Tạo và mở kết nối
                DB dB = new DB();
                using (SqlConnection connection = dB.Connection)
                {
                    // Tạo đối tượng SqlCommand
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số cho câu truy vấn
                        command.Parameters.AddWithValue("@PayDetailID", paymentDetail.PayDetailID);

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

        private bool UpdatePaymentDetail()
        {
            try
            {
                paymentDetail.Date = DatePicker.SelectedDate ?? DateTime.Now;
                paymentDetail.Payer = PayerTextBox.Text;
                paymentDetail.PaymentMethod = MethodTextBox.Text;
                paymentDetail.TotalPayment = decimal.TryParse(TotalPaymentTextBox.Text, out decimal total) ? total : null;
                paymentDetail.TotalPaid = decimal.TryParse(TotalPaidTextBox.Text, out decimal paid) ? paid : null;
                paymentDetail.Change = decimal.TryParse(ChangeTextBox.Text, out decimal change) ? change : null;
                paymentDetail.Note = NoteTextBox.Text;

                DB dB = new DB();
                using (SqlConnection connection = dB.Connection)
                {
                    // Thực hiện cập nhật dữ liệu vào database
                    string query = "UPDATE [Payment Detail] SET Date = @Date, Payer = @Payer, PaymentMethod = @PaymentMethod, TotalPayment = @TotalPayment, TotalPaid = @TotalPaid, Change = @Change, Note = @Note " +
                                   "WHERE @PayDetailID = PayDetailID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Date", paymentDetail.Date);
                        command.Parameters.AddWithValue("@Payer", paymentDetail.Payer);
                        command.Parameters.AddWithValue("@PaymentMethod", paymentDetail.PaymentMethod);
                        command.Parameters.AddWithValue("@TotalPayment", paymentDetail.TotalPayment);
                        command.Parameters.AddWithValue("@TotalPaid", paymentDetail.TotalPaid);
                        command.Parameters.AddWithValue("@Change", paymentDetail.Change);
                        command.Parameters.AddWithValue("@Note", paymentDetail.Note);
                        command.Parameters.AddWithValue("@PayDetailID", paymentDetail.PayDetailID);

                        command.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
    }
}
