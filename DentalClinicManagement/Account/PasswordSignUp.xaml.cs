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
using DentalClinicManagement.Account.Class;

namespace DentalClinicManagement.Account
{
    /// <summary>
    /// Interaction logic for PasswordSignUp.xaml
    /// </summary>
    public partial class PasswordSignUp : Page
    {
        // Biến lưu PhoneNo từ bảng Customer
        private string customerPhoneNo;

        public PasswordSignUp(string phoneNoFromCustomer)
        {
            InitializeComponent();
            customerPhoneNo = phoneNoFromCustomer;
        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;


            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Account.SignUp());
            }
        }

        private void FinishSignUpButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Lấy thông tin từ giao diện người dùng
                string password = PasswordTextBox.Text;
                string confirmPassword = ConfirmPasswordTextBox.Text;

                // Kiểm tra mật khẩu và xác nhận mật khẩu
                if (password == confirmPassword)
                {
                    // Tạo đối tượng AccountClass
                    AccountClass newAccount = new AccountClass
                    {
                        Password = password,
                        PhoneNo = customerPhoneNo
                        //Status = status
                    };

                    // Mật khẩu khớp, tiến hành ghi vào bảng Account
                    if (RegisterAccount(newAccount))
                    {
                        MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

                        if (mainWindow != null && mainWindow.MainFrame != null)
                        {
                            mainWindow.MainFrame.Navigate(new DentalClinicManagement.Account.SignUpSuccess());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đăng ký tài khoản thất bại. Vui lòng thử lại.");
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private bool RegisterAccount(AccountClass account)
        {
            try
            {
                // Tạo và mở kết nối
                DB dB = new DB();
                using (SqlConnection connection = dB.Connection)
                {
                    // Câu truy vấn SQL để thêm dữ liệu vào bảng Account
                    string query = "INSERT INTO Account (PhoneNo, Password) " +
                                   "VALUES (@PhoneNo, @Password)";

                    // Tạo đối tượng SqlCommand
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm các tham số
                        command.Parameters.AddWithValue("@PhoneNo", account.PhoneNo);
                        command.Parameters.AddWithValue("@Password", account.Password);

                        // Thực hiện truy vấn
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
