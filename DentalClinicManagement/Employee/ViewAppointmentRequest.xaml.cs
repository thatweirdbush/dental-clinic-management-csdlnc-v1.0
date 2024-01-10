using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using DentalClinicManagement.Employee.Class;

namespace DentalClinicManagement.Employee
{
    /// <summary>
    /// Interaction logic for ViewAppointmentRequest.xaml
    /// </summary>
    public partial class ViewAppointmentRequest : Page
    {
        StaffClass staff;

        public ObservableCollection<AppointmentRequest> appointments { get; set; } = new ObservableCollection<AppointmentRequest>();

        public ViewAppointmentRequest(StaffClass staff)
        {
            InitializeComponent();
            this.staff = new StaffClass(staff);
            LoadAppointmentRequests();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Employee.ManageSchedule(staff));
            }
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Employee.Dashboard(staff));
            }
        }

        private void LoadAppointmentRequests()
        {
            try
            {
                // Câu truy vấn SQL để lấy thông tin AppointmentRequest từ database
                string query = "SELECT * FROM [Appointment Request]";

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
                                AppointmentRequest appointment = new AppointmentRequest(reader);
                                appointments.Add(appointment);
                            }
                            // Gán ObservableCollection làm nguồn dữ liệu cho DataGrid
                            AppointmentRequestDataGrid.ItemsSource = appointments;
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
