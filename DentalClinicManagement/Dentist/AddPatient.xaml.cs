using DentalClinicManagement.Account.Class;
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
    /// Interaction logic for AddPatient.xaml
    /// </summary>
    public partial class AddPatient : Page
    {
        DentistClass dentist;
        public AddPatient(DentistClass dentist)
        {
            InitializeComponent();
            this.dentist = new DentistClass(dentist);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.ViewPatientList(dentist));
            }
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.DashBoard(dentist));
            }
        }

        private void SaveRecordButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Tạo đối tượng PatientRecord
                PatientRecord newRecord = new PatientRecord
                {
                    // Lấy thông tin từ giao diện người dùng
                    Name = FullnameTextBox.Text,
                    Age = int.TryParse(AgeTextBox.Text, out int age) ? age : null,
                    Sex = SexTextBox.Text,
                    GeneralInformation = GeneralInformationTextBox.Text,
                    AllergyStatus = AllergyStatusTextBox.Text,
                    TotalPaid = decimal.TryParse(TotalPaymentTextBox.Text, out decimal paid) ? paid : null,
                    TotalTreatmentFee = decimal.TryParse(TotalTreatmentFeeTextBox.Text, out decimal fee) ? fee : null
                };

                // Thực hiện đăng ký và lưu vào database
                RegistryHelpers regist = new RegistryHelpers();
                if (regist.RegisterPatientRecord(newRecord))
                {
                    MessageBox.Show("Thêm hồ sơ bệnh án thành công!");
                    MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

                    if (mainWindow != null && mainWindow.MainFrame != null)
                    {
                        mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.AddPatient(dentist));
                    }
                }
                else
                {
                    MessageBox.Show("Thêm hồ sơ thất bại. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void AddPatientButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Tạo đối tượng Patient
                Patient newPatient = new Patient
                {
                    // Lấy thông tin từ giao diện người dùng
                    Name = PatientNameTextBox.Text,
                    PhoneNo = PhoneNoTextBox.Text,
                };

                // Thực hiện đăng ký và lưu vào database
                RegistryHelpers regist = new RegistryHelpers();
                if (regist.RegisterPatient(newPatient))
                {
                    MessageBox.Show("Thêm bệnh nhân thành công!");
                    MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

                    if (mainWindow != null && mainWindow.MainFrame != null)
                    {
                        mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.AddPatient(dentist));
                    }
                }
                else
                {
                    MessageBox.Show("Thêm hồ sơ thất bại. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

    }
}
