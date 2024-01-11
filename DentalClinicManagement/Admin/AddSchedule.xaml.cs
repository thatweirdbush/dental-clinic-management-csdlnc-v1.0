using DentalClinicManagement.Account.Class;
using DentalClinicManagement.Dentist.Class;
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

namespace DentalClinicManagement.Admin
{
    /// <summary>
    /// Interaction logic for AddSchedule.xaml
    /// </summary>
    public partial class AddSchedule : Page
    {
        AdminClass admin;

        private DentistSchedule dentistSchedule;
 
        public AddSchedule(AdminClass admin)
        {
            InitializeComponent();
            this.admin = new AdminClass(admin);
        }

        private void AddNewScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            if (InsertSchedule())
            {
                MessageBox.Show("Thêm thành công.");
            }
            else
            {
                MessageBox.Show("Thêm thất bại. Vui lòng thử lại.");
            }
        }

        public bool InsertSchedule()
        {
            if (DentistIDTextBox.Text == null && ShiftTextBox.Text == null && DayTextBox.Text == null && MonthTextBox.Text == null && YearTextBox.Text == null && StatusTextBox.Text == null)
            {
                MessageBox.Show("Xin vui lòng nhập đầy đủ thông tin.");
                return false;
            }
            try
            {
                dentistSchedule.DentistID = int.TryParse(DentistIDTextBox.Text, out int change) ? change : null;
                int? newDentistID = dentistSchedule.DentistID;
                dentistSchedule.Shift = ShiftTextBox.Text;
                string? newShift = dentistSchedule.Shift;
                dentistSchedule.Day = int.TryParse(DayTextBox.Text, out int change1) ? change1 : null;
                int? newDay = dentistSchedule.Day;
                dentistSchedule.Month = int.TryParse(MonthTextBox.Text, out int change2) ? change2 : null;
                int? newMonth = dentistSchedule.Month;
                dentistSchedule.Year = int.TryParse(YearTextBox.Text, out int change3) ? change3 : null;
                int? newYear = dentistSchedule.Year;
                dentistSchedule.Status = StatusTextBox.Text;
                string? newStatus = dentistSchedule.Status;

                DB dB = new DB();
                using (SqlConnection connection = dB.Connection)
                {
                    // Thực hiện cập nhật dữ liệu vào database
                    string query = "INSERT INTO [Schedule] (DentistID, Shift, Day, Month, Year, Status) VALUES (@DentistID, @Shift, @Day, @Month, @Year, @Status)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DentistID", newDentistID);
                        command.Parameters.AddWithValue("@Shift", newShift);
                        command.Parameters.AddWithValue("@Day", newDay);
                        command.Parameters.AddWithValue("@Month", newMonth);
                        command.Parameters.AddWithValue("@Year", newYear);
                        command.Parameters.AddWithValue("@Status", newStatus);

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

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Admin.DashBoard(admin));
            }
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Admin.DashBoard(admin));
            }
        }
    }

}
