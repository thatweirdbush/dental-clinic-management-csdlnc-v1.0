using DentalClinicManagement.Account;
using System;
using System.Collections.Generic;
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
using DentalClinicManagement.Employee.Class;

namespace DentalClinicManagement.Employee
{
    /// <summary>
    /// Interaction logic for AddNewAppointment.xaml
    /// </summary>
    public partial class AddNewAppointment : Page
    {
        public AddNewAppointment()
        {
            InitializeComponent();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Employee.Dashboard());
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Employee.ManageSchedule());
            }
        }

        private void FinishButton_Click(object sender, RoutedEventArgs e)
        {
            // Tạo đối tượng AppointmentRequest
            AppointmentRequest newAppointmentRequest = new AppointmentRequest
            {
                // Lấy thông tin từ giao diện người dùng
                PatientID = int.TryParse(PatientIDTextBox.Text, out int patientID) ? patientID : null,
                DentistID = int.TryParse(DentistIDTextBox.Text, out int dentistID) ? dentistID : null,
                ScheduleID = int.TryParse(ScheduleIDTextBox.Text, out int scheduleID) ? scheduleID : null,
                TimeOfRequest = ExaminationDatePicker.SelectedDate ?? DateTime.Now,
                Status = (StatusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "N/A",
                Note = NoteTextBox.Text
            };

            // Thực hiện đăng ký và lưu vào database
            RegistryHelpers regist = new RegistryHelpers();
            if (regist.RegisterAppointmentRequest(newAppointmentRequest))
            {
                MessageBox.Show("Thêm cuộc hẹn thành công.");
                MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

                if (mainWindow != null && mainWindow.MainFrame != null)
                {
                    // Chuyển qua cửa sổ PasswordSignUp và chuyển số điện thoại từ SignUp qua
                    mainWindow.MainFrame.Navigate(new DentalClinicManagement.Employee.ManageSchedule());
                }
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại. Vui lòng thử lại.");
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
