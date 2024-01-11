using DentalClinicManagement.Account.Class;
using DentalClinicManagement.Dentist.Class;
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
    /// Interaction logic for AddTreatmentPlan_ChooseTreatment.xaml
    /// </summary>
    public partial class AddTreatmentPlan_ChooseTreatment : Page
    {
        DentistClass dentist;
        Patient patient;
        public ObservableCollection<Treatment> treatmentList { get; set; } = new ObservableCollection<Treatment>();

        public AddTreatmentPlan_ChooseTreatment(DentistClass dentist, Patient patient)
        {
            InitializeComponent();
            this.dentist = new DentistClass(dentist);
            this.patient = new Patient(patient);
            LoadTreatmentList();
        }
        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.DashBoard(dentist));
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.DashBoard(dentist));
            }
        }

/*        private void ChooseTreatmentChildButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.AddTreatmentPlan_ChooseTreatmentChild());
            }
        }*/

        private void LoadTreatmentList()
        {
            try
            {
                // Câu truy vấn SQL để lấy thông tin Treatment từ database
                string query = "SELECT * FROM [Treatment]";

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
                                Treatment treatment = new Treatment(reader);
                                treatmentList.Add(treatment);
                            }
                            // Gán ObservableCollection làm nguồn dữ liệu cho DataGrid
                            TreatmentListDataGrid.ItemsSource = treatmentList;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void TreatmentListDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is DataGrid dataGrid && dataGrid.SelectedItem is Treatment treatment)
            {
                MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

                if (mainWindow != null && mainWindow.MainFrame != null)
                {
                    mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.AddTreatmentPlan_ChooseTreatmentChild(dentist, treatment, patient));
                }
            }
        }
    }
}
