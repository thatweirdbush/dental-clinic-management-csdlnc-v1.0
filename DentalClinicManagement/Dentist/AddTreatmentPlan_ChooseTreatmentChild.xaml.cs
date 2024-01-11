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
    /// Interaction logic for AddTreatmentPlan_ChooseTreatmentChild.xaml
    /// </summary>
    public partial class AddTreatmentPlan_ChooseTreatmentChild : Page
    {
        private Treatment treatment;
        public ObservableCollection<TreatmentChild> treatmentChildList { get; set; } = new ObservableCollection<TreatmentChild>();
        public AddTreatmentPlan_ChooseTreatmentChild(Treatment treatment)
        {
            InitializeComponent();
            this.treatment = new Treatment(treatment);
            LoadTreatmentChildList(treatment);
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
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.AddTreatmentPlan_ChooseTreatment());
            }
        }

        private void ChooseDateAndDentistButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.AddTreatmentPlan_ChooseDateAndDentist());
            }
        }

        private void LoadTreatmentChildList(Treatment treatment)
        {
            int? treatmentID = treatment.TreatmentID;
            try
            {
                // Câu truy vấn SQL để lấy thông tin TreatmentChild từ database
                string query = "SELECT [Treatment].TreatmentID, [Treatment Child List].TreatmentChildID, [Treatment].Name " +
                               "FROM [Treatment Child List], [Treatment] " +
                               "WHERE @TreatmentID = [Treatment].TreatmentID " +
                               "AND [Treatment Child List].TreatmentChildID = [Treatment].TreatmentID";
                               

                // Tạo và mở kết nối
                DB dB = new DB();
                using (SqlConnection connection = dB.Connection)
                {
                    // Tạo đối tượng SqlCommand
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thực hiện truy vấn SQL và lấy dữ liệu
                        command.Parameters.AddWithValue("@TreatmentID", treatmentID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TreatmentChild treatmentChild = new TreatmentChild(reader);
                                treatmentChildList.Add(treatmentChild);
                            }
                            // Gán ObservableCollection làm nguồn dữ liệu cho DataGrid
                            TreatmentChildListDataGrid.ItemsSource = treatmentChildList;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void TreatmentChildListDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is DataGrid dataGrid && dataGrid.SelectedItem is TreatmentChild treatmentChild)
            {
                MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

                if (mainWindow != null && mainWindow.MainFrame != null)
                {
                    mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.AddTreatmentPlan_ChooseTeeth());
                }
            }
        }
    }
}
