using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using DentalClinicManagement.Admin.Class;
using DentalClinicManagement.Dentist.Class;

namespace DentalClinicManagement.Admin
{
    /// <summary>
    /// Interaction logic for ReportAppointment.xaml
    /// </summary>

    public partial class ReportAppointment : Page
    {

        public ObservableCollection<ReportAppoint> reportAppointList { get; set; } = new ObservableCollection<ReportAppoint>();

        public ReportAppointment()
        {
            InitializeComponent();
            LoadReportAppoint();
        }

        private void viewHome(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;


            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Admin.DashBoard());
            }
        }


        private void LoadReportAppoint()
        {

            try
            {
                // Câu truy vấn SQL để lấy thông tin AppointmentRequest từ database
                string query = "SELECT TimeOfRequest,[Schedule].Shift, [Patient].Name, [Dentist].Name as DentistName, [Appointment Request].Room, [Appointment Request].Status\r\nFROM [Appointment Request], [Patient],[Schedule], [Dentist]\r\nWHERE [Schedule].ScheduleID = [Appointment Request].ScheduleID\r\nAND [Schedule].DentistID = [Appointment Request].DentistID\r\nAND [Appointment Request].PatientID = [Patient].PatientID\r\nAND [Schedule].DentistID = [Dentist].DentistID";
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
                                ReportAppoint reportAppoint = new ReportAppoint(reader);
                                reportAppointList.Add(reportAppoint);
                            }
                            // Gán ObservableCollection làm nguồn dữ liệu cho DataGrid
                            ReportAppointListView.ItemsSource = reportAppointList;
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
