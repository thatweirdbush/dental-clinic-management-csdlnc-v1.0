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
    /// Interaction logic for ViewTreatingTeethList.xaml
    /// </summary>
    public partial class ViewTreatingTeethList : Page
    {
        private DetailedTreatmentPlan plan;
        private Patient patient;
        public ObservableCollection<DetailedTreatmentTooth> treatingToothList { get; set; } = new ObservableCollection<DetailedTreatmentTooth>();

        public ViewTreatingTeethList(DetailedTreatmentPlan plan, Patient patient)
        {
            InitializeComponent();
            this.plan = new DetailedTreatmentPlan(plan);
            this.patient = new Patient(patient);
            LoadTreatingToothList();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.ViewDetailTreatmentPlan(plan, patient));
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

        private void TreatingTeethList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // For later
        }

        private void LoadTreatingToothList()
        {
            int? patientID = patient.PatientID;
            try
            {
                // Câu truy vấn SQL để lấy thông tin Detailed Treatment Plan từ database
                string query = "SELECT * FROM [Detailed Treatment Tooth]" +
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
                                DetailedTreatmentTooth detail = new DetailedTreatmentTooth(reader);
                                treatingToothList.Add(detail);
                            }
                            // Gán ObservableCollection làm nguồn dữ liệu cho DataGrid
                            TreatingTeethListDataGrid.ItemsSource = treatingToothList;
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
