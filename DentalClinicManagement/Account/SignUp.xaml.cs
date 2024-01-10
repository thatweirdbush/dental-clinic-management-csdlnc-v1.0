using DentalClinicManagement;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
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
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public class signUpImage
    {
        public string bg { get; set; }
        public string teethImage { get; set; }
    }

    public partial class SignUp : Page
    {
        public SignUp()
        {
            InitializeComponent();
        }
        signUpImage _s = new signUpImage();

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            _s.bg = "images\\recTeeth.PNG";
            _s.teethImage = "images\\teeth.jpg";
            this.DataContext = _s;
        }

        private void CompleteSignUpButton_Click(object sender, RoutedEventArgs e)
        {
            string dateStr = BirthDateTextBox.Text;
            DateTime birthDate;

            if (!DateTime.TryParseExact(dateStr, "dd/MM/yyyy", null, DateTimeStyles.None, out birthDate))
            {
                MessageBox.Show("Invalid date string format. Valid format is: dd/MM/yyyy");
            }

            // Tạo đối tượng Customer
            CustomerClass newCustomer = new CustomerClass
            {
                // Lấy thông tin từ giao diện người dùng
                Name = FullNameTextBox.Text,
                DayOfBirth = birthDate,
                Address = AddressTextBox.Text,
                PhoneNo = PhoneNumberTextBox.Text,
                Email = EmailTextBox.Text
            };

            // Thực hiện đăng ký và lưu vào database
            RegistryHelpers regist = new RegistryHelpers();
            if (regist.RegisterCustomer(newCustomer))
            {
                MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

                if (mainWindow != null && mainWindow.MainFrame != null)
                {
                    // Chuyển qua cửa sổ PasswordSignUp và chuyển số điện thoại từ SignUp qua
                    mainWindow.MainFrame.Navigate(new DentalClinicManagement.Account.PasswordSignUp(PhoneNumberTextBox.Text));
                }
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại. Vui lòng thử lại.");
            }
        }

        private void OnBackButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;


            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Account.Home());
            }
        }
    } 
}
