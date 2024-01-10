using DentalClinicManagement.Account;
using DentalClinicManagement.Dentist;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
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
    /// Interaction logic for Schedule.xaml
    /// </summary>

    public partial class ManageSchedule : Page
    {
        public ObservableCollection<Schedule> schedules { get; set; } = new ObservableCollection<Schedule>();

        public ManageSchedule()
        {
            InitializeComponent();
            LoadSchedules();
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
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Employee.Dashboard());
            }
        }
        private void AddNewScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Employee.AddNewAppointment());
            }
        }

        private void AppointmentRequestButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Employee.ViewAppointmentRequest());
            }
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Lọc danh sách.");

        }

        private void Schedule_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // For later

        }
        private void LoadSchedules()
        {
            try
            {
                // Câu truy vấn SQL để lấy thông tin AppointmentRequest từ database
                string query = "SELECT * FROM [Schedule]";

                // Tạo và mở kết nối
                DB dB = new DB();
                using (SqlConnection connection = dB.Connection)
                {
                    // Tạo đối tượng SqlCommand
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thực hiện truy vấn SQL và lấy dữ liệu
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Schedule schedule = new Schedule(reader);
                                schedules.Add(schedule);
                            }
                            // Gán ObservableCollection làm nguồn dữ liệu cho DataGrid
                            ScheduleDataGrid.ItemsSource = schedules;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }

}
