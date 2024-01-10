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
using DentalClinicManagement.Dentist.Class;

namespace DentalClinicManagement.Account
{
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : Page
    {
        const string ADMIN = "Admin";
        const string STAFF = "Staff";
        const string DENTIST = "Dentist";

        private AdminClass? admin;
        private StaffClass? staff;
        private DentistClass? dentist;
        private AccountClass? account;

        public SignIn()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
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
                account = new AccountClass
                {
                    // Lấy thông tin từ giao diện người dùng
                    PhoneNo = UsernameTextBox.Text,
                    Password = PasswordTextBox.Text
                };

                // Kiểm tra đăng nhập
                if (AuthenticateUser(account) == false)
                {
                    MessageBox.Show("Đăng nhập thất bại. Vui lòng kiểm tra tên người dùng và mật khẩu.");
                    return;
                }
                else
                {
                    // Load user's account information
                    account = LoadAccountInformation(account.PhoneNo);
                }

                if (CheckUserRole(ADMIN))
                {
                    // Allocate memory
                    admin = new AdminClass();

                    // Load user to Admin object 
                    admin = admin.LoadUser(account);
                    if (admin != null)
                    {
                        MessageBox.Show($"Đăng nhập thành công! Chào mừng Admin {admin.Name}!");
                        MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

                        if (mainWindow != null && mainWindow.MainFrame != null)
                        {
                            mainWindow.MainFrame.Navigate(new DentalClinicManagement.Admin.DashBoard(admin));
                            return;
                        }
                    }
                }
                if (CheckUserRole(STAFF))
                {
                    // Allocate memory
                    staff = new StaffClass();

                    // Load user to Staff object 
                    staff = staff.LoadUser(account);
                    if (staff != null)
                    {
                        MessageBox.Show($"Đăng nhập thành công. Chào mừng nhân viên {staff.Name}!");
                        MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

                        if (mainWindow != null && mainWindow.MainFrame != null)
                        {
                            mainWindow.MainFrame.Navigate(new DentalClinicManagement.Employee.Dashboard(staff));
                            return;
                        }
                    }
                }
                if (CheckUserRole(DENTIST))
                {
                    // Allocate memory
                    dentist = new DentistClass();

                    // Load user to Dentist object 
                    dentist = dentist.LoadUser(account);
                    if (dentist != null)
                    {
                        MessageBox.Show($"Đăng nhập thành công. Chào mừng nha sĩ {dentist.Name}!");
                        MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

                        if (mainWindow != null && mainWindow.MainFrame != null)
                        {
                            mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.DashBoard(dentist));
                        }
                    }
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
                string query = "SELECT TOP 1 * FROM [Account] WHERE PhoneNo = @Username AND Password = @Password";

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

        private AccountClass? LoadAccountInformation(string? phoneNo)
        {
            try
            {
                // Câu truy vấn SQL để lấy thông tin Account từ database dựa trên PhoneNo
                string query = "SELECT TOP 1* FROM [Account] WHERE PhoneNo = @PhoneNo";

                // Tạo và mở kết nối
                DB dB = new DB();
                using (SqlConnection connection = dB.Connection)
                {
                    // Tạo đối tượng SqlCommand
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số cho câu truy vấn
                        command.Parameters.AddWithValue("@PhoneNo", phoneNo);

                        // Sử dụng SqlDataReader để đọc dữ liệu từ database
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Kiểm tra xem có dữ liệu hay không
                            if (reader.Read())
                            {
                                // Tạo đối tượng AccountClass từ SqlDataReader
                                AccountClass account = new AccountClass(reader);
                                return account;
                            }
                            else
                            {
                                // Trường hợp không tìm thấy thông tin AccountClass
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

        private bool CheckUserRole(string ROLE)
        {
            try
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("SELECT COUNT(*) FROM [");
                builder.Append(ROLE);
                builder.Append("] WHERE PhoneNo = @PhoneNo");
                string query = builder.ToString();

                // Tạo và mở kết nối
                DB dB = new DB();
                using (SqlConnection connection = dB.Connection)
                {
                    // Tạo đối tượng SqlCommand
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số cho câu truy vấn
                        command.Parameters.AddWithValue("@PhoneNo", account.PhoneNo);
                        int count = (int)command.ExecuteScalar();

                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show($"Error: {ex.Message}");
                return false;
            }
        }
     
        private void signInAdmin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;


            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Admin.DashBoard(admin));
            }
        }

        private void signInDentist_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;


            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.DashBoard(dentist));
            }
        }

        private void signInEmployee_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;


            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Employee.Dashboard(staff));
            }
        }

        private void signInCustomer_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Đăng nhập để vào giao diện Customer.");
        }
    }
}
