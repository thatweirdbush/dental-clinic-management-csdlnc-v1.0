using DentalClinicManagement.Account;
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

namespace DentalClinicManagement.Customer
{
    /// <summary>
    /// Interaction logic for ViewProfile.xaml
    /// </summary>
    public partial class ViewProfile : Page
    {
        // Biến lưu User từ cửa sổ Sign In
        private CustomerClass user;

        public ViewProfile(CustomerClass user)
        {
            InitializeComponent();
            this.user = new CustomerClass(user);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Customer.DashBoard(user));
            }
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Tạo đối tượng CustomerClass từ thông tin người dùng cũ
                CustomerClass updatedUser = new CustomerClass(user);

                // Biến để kiểm tra xem có sự thay đổi hay không
                bool dataChanged = false;

                // Kiểm tra và cập nhật thông tin từ TextBox, nếu không nhập dữ liệu thì không thay đổi thông tin
                if (!string.IsNullOrWhiteSpace(FullNameTextBox.Text) && FullNameTextBox.Text != user.Name)
                {
                    updatedUser.Name = FullNameTextBox.Text;
                    dataChanged = true;
                }

                if (!string.IsNullOrWhiteSpace(PhoneNumberTextBox.Text) && PhoneNumberTextBox.Text != user.PhoneNo)
                {
                    updatedUser.PhoneNo = PhoneNumberTextBox.Text;
                    dataChanged = true;
                }

                if (!string.IsNullOrWhiteSpace(EmailTextBox.Text) && EmailTextBox.Text != user.Email)
                {
                    updatedUser.Email = EmailTextBox.Text;
                    dataChanged = true;
                }

                if (!string.IsNullOrWhiteSpace(AddressTextBox.Text) && AddressTextBox.Text != user.Address)
                {
                    updatedUser.Address = AddressTextBox.Text;
                    dataChanged = true;
                }

                // Kiểm tra và cập nhật giới tính từ CheckBox
                bool newSex = MaleCheckBox.IsChecked ?? false;
                if (newSex != user.Sex)
                {
                    updatedUser.Sex = newSex;
                    dataChanged = true;
                }

                // Kiểm tra xem có dữ liệu thay đổi hay không
                if (dataChanged)
                {
                    // Gọi hàm lưu thông tin vào database
                    if (UpdateCustomerInfo(updatedUser))
                    {
                        MessageBox.Show("Thông tin đã được cập nhật thành công. Vui lòng đăng nhập lại!");
                        MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

                        if (mainWindow != null && mainWindow.MainFrame != null)
                        {
                            mainWindow.MainFrame.Navigate(new DentalClinicManagement.Account.SignIn());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi cập nhật thông tin. Vui lòng thử lại.");
                    }
                }
                else
                {
                    MessageBox.Show("Dữ liệu không thay đổi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private bool UpdateCustomerInfo(CustomerClass updatedCustomer)
        {
            DB dB = new DB();
            using (SqlConnection connection = dB.Connection)
            {
                // Bắt đầu giao dịch
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Câu truy vấn SQL để cập nhật thông tin của Customer
                        string queryForCustomer = "UPDATE Customer SET Name = @Name, PhoneNo = @PhoneNo, Address = @Address " +
                                                   "WHERE PhoneNo = @OldPhoneNo";

                        string queryForAccount = "UPDATE Account SET PhoneNo = @PhoneNo " +
                                                 "WHERE PhoneNo = @OldPhoneNo";

                        // Tạo đối tượng SqlCommand và liên kết với giao dịch
                        using (SqlCommand commandForCustomer = new SqlCommand(queryForCustomer, connection, transaction))
                        {
                            commandForCustomer.Parameters.AddWithValue("@Name", updatedCustomer.Name);
                            commandForCustomer.Parameters.AddWithValue("@PhoneNo", updatedCustomer.PhoneNo);
                            commandForCustomer.Parameters.AddWithValue("@OldPhoneNo", user.PhoneNo);
                            commandForCustomer.Parameters.AddWithValue("@Address", updatedCustomer.Address);

                            // Thực hiện truy vấn
                            commandForCustomer.ExecuteNonQuery();
                        }

                        using (SqlCommand commandForAccount = new SqlCommand(queryForAccount, connection, transaction))
                        {
                            commandForAccount.Parameters.AddWithValue("@PhoneNo", updatedCustomer.PhoneNo);
                            commandForAccount.Parameters.AddWithValue("@OldPhoneNo", user.PhoneNo);

                            // Thực hiện truy vấn
                            commandForAccount.ExecuteNonQuery();
                        }

                        // Nếu mọi thứ đều OK, commit giao dịch
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        // Xử lý lỗi và rollback giao dịch
                        Console.WriteLine($"Error: {ex.Message}");
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }
    }
}
