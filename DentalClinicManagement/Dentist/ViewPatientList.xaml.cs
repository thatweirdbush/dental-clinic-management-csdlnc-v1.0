using DentalClinicManagement.Account.Class;
using DentalClinicManagement.Dentist.Class;
using DentalClinicManagement.Employee.Class;
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

namespace DentalClinicManagement.Dentist
{
    /// <summary>
    /// Interaction logic for ViewPatientList.xaml
    /// </summary>
    public partial class ViewPatientList : Page
    {
        DentistClass dentist;
        public ObservableCollection<Patient> patientList { get; set; } = new ObservableCollection<Patient>();

        public ViewPatientList(DentistClass dentist)
        {
            InitializeComponent();
            this.dentist = new DentistClass(dentist);

            LoadPatientList();
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
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.DashBoard(dentist));
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

        private void PatientList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is DataGrid dataGrid && dataGrid.SelectedItem is Patient selectedPatient)
            {
                MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

                if (mainWindow != null && mainWindow.MainFrame != null)
                {
                    mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.ViewPatientRecord(dentist, selectedPatient));
                }
            }
        }

        private void AddNewPatientButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.AddPatient(dentist));
            }
        }

        private void AppointmentRequestButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.ViewAppointmentRequest(dentist));
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
                                patientList.Add(patient);
                            }
                            // Gán ObservableCollection làm nguồn dữ liệu cho DataGrid
                            PatientListDataGrid.ItemsSource = patientList;
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
