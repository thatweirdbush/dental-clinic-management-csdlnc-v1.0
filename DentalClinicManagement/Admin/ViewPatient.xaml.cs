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
using DentalClinicManagement.Dentist.Class;
using DentalClinicManagement.Account.Class;

namespace DentalClinicManagement.Admin
{
    
    public partial class ViewPatient : Page
    {
        AdminClass admin;
        public ObservableCollection<Patient> PatientList { get; set; } = new ObservableCollection<Patient>();
        public ViewPatient(AdminClass admin)
        {
            InitializeComponent();
            LoadPatientList();
            this.admin = new AdminClass(admin);
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Tìm kiếm.");
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
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Admin.DashBoard());
            }
        }

        private void PatientList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is DataGrid dataGrid && dataGrid.SelectedItem is Patient selectedPatient)
            {
                MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

                if (mainWindow != null && mainWindow.MainFrame != null)
                {
                    mainWindow.MainFrame.Navigate(new DentalClinicManagement.Admin.ViewPatientRecord(selectedPatient));
                }
            }
        }

        private void AddNewPatientButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.AddPatient());
            }
        }

        private void AppointmentRequestButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Admin.ViewAppointmentRequest());
            }
        }

        private void LoadPatientList()
        {
            try
            {
                // Câu truy vấn SQL để lấy thông tin AppointmentRequest từ database
                string query = "SELECT * FROM [Patient]";

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
                                Patient patient = new Patient(reader);
                                PatientList.Add(patient);
                            }
                            // Gán ObservableCollection làm nguồn dữ liệu cho DataGrid
                            PatientListDataGrid.ItemsSource = PatientList;
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
