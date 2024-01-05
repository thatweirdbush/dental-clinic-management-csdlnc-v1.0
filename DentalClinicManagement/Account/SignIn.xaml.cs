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

namespace DentalClinicManagement.Account
{
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : Page
    {
        private CustomerClass user;

        public SignIn()
        {
            InitializeComponent();
        }
        private void OnBackButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;


            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Account.Home());
            }
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Tạo đối tượng Account
                AccountClass account = new AccountClass
                {
                    // Lấy thông tin từ giao diện người dùng
                    PhoneNo = UsernameTextBox.Text,
                    Password = PasswordTextBox.Text
                };

                // Kiểm tra đăng nhập
                if (AuthenticateUser(account))
                {
                    user = LoadCustomerInfo(account.PhoneNo);
                    MessageBox.Show("Đăng nhập thành công!");
                    MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

                    if (mainWindow != null && mainWindow.MainFrame != null)
                    {
                        mainWindow.MainFrame.Navigate(new DentalClinicManagement.Customer.DashBoard(user));
                    }
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại. Vui lòng kiểm tra tên người dùng và mật khẩu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private bool AuthenticateUser(AccountClass user)
        {
            try
            {
                // Câu truy vấn SQL để kiểm tra đăng nhập
                string query = "SELECT TOP 1 * FROM Account WHERE PhoneNo = @Username AND Password = @Password";

                DB dB = new DB();
                using (SqlConnection connection = dB.Connection)
                {
                    // Tạo đối tượng SqlCommand
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm các tham số
                        command.Parameters.AddWithValue("@Username", user.PhoneNo);
                        command.Parameters.AddWithValue("@Password", user.Password);

                        // Thực hiện truy vấn
                        int count = (int)command.ExecuteScalar();

                        // Nếu có ít nhất một bản ghi khớp, đăng nhập thành công
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        private CustomerClass LoadCustomerInfo(string username)
        {
            try
            {
                // Câu truy vấn SQL để lấy thông tin Customer từ database dựa trên username
                string query = "SELECT * FROM Customer WHERE PhoneNo = @Username";

                // Tạo và mở kết nối
                DB dB = new DB();
                using (SqlConnection connection = dB.Connection)
                {
                    // Tạo đối tượng SqlCommand
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số cho câu truy vấn
                        command.Parameters.AddWithValue("@Username", username);

                        // Sử dụng SqlDataReader để đọc dữ liệu từ database
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Kiểm tra xem có dữ liệu hay không
                            if (reader.Read())
                            {
                                // Tạo đối tượng Customer từ SqlDataReader
                                CustomerClass customer = new CustomerClass(reader);
                                return customer;
                            }
                            else
                            {
                                // Trường hợp không tìm thấy thông tin Customer
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

        private void signInAdmin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;


            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Admin.DashBoard());
            }
        }

        private void signInDentist_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;


            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.DashBoard());
            }
        }

        private void signInEmployee_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;


            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Employee.Dashboard());
            }
        }

        private void signInCustomer_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Đăng nhập để vào giao diện Customer.");
        }
    }
}
