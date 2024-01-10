using DentalClinicManagement.Account;
using System;
using System.Collections.Generic;
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

namespace DentalClinicManagement.Dentist
{
    /// <summary>
    /// Interaction logic for ReceivePatient.xaml
    /// </summary>
    public partial class ReceivePatient : Page
    {
        DentistClass dentist;

        public ReceivePatient(DentistClass dentist)
        {
            InitializeComponent();
            this.dentist = new DentistClass(dentist);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;


            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.DashBoard(dentist));
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
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
                MessageBox.Show("Thêm hồ sơ thành công!");
                MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

                if (mainWindow != null && mainWindow.MainFrame != null)
                {
                    mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.SearchCustomerRecord(dentist));
                }
            }
            else
            {
                MessageBox.Show("Thêm hồ sơ thất bại. Vui lòng thử lại.");
            }
        } 
    }
}
