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
    /// Interaction logic for ViewTreatmentPlanList.xaml
    /// </summary>
    public partial class ViewTreatmentPlanList : Page
    {
        private Patient patient;
        public ObservableCollection<DetailedTreatmentPlan> planList { get; set; } = new ObservableCollection<DetailedTreatmentPlan>();

        public ViewTreatmentPlanList(Patient patient)
        {
            InitializeComponent();
            this.patient = new Patient(patient);
            LoadPlanList(patient);

        }

        private void AddNewTreatmentPlanButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.AddTreatmentPlan_ChooseTreatment());
            }
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.DashBoard());
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.ViewPatientRecord(patient));
            }
        }

        private void TreatmentPlanList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is DataGrid dataGrid && dataGrid.SelectedItem is DetailedTreatmentPlan selectedPlan)
            {
                MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

                if (mainWindow != null && mainWindow.MainFrame != null)
                {
                    mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.ViewDetailTreatmentPlan(selectedPlan, patient));
                }
            }
        }

        private void LoadPlanList(Patient patient)
        {
            int? patientID = patient.PatientID;
            try
            {
                // Câu truy vấn SQL để lấy thông tin Detailed Treatment Plan từ database
                string query = "SELECT * FROM [Detailed Treatment Plan]" + 
                    "WHERE @PatientID = PatientID";

                // Tạo và mở kết nối
                DB dB = new DB();
                using (SqlConnection connection = dB.Connection)
                {
                    // Tạo đối tượng SqlCommand
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PatientID", patientID);
                        // Thực hiện truy vấn SQL và lấy dữ liệu
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DetailedTreatmentPlan plan = new DetailedTreatmentPlan(reader);
                                planList.Add(plan);
                            }
                            // Gán ObservableCollection làm nguồn dữ liệu cho DataGrid
                            TreatmentPlanListDataGrid.ItemsSource = planList;
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
