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

namespace DentalClinicManagement.Admin
{
    /// <summary>
    /// Interaction logic for ReportTreatment.xaml
    /// </summary>

/*    public class MainViewModel2 : INotifyPropertyChanged
    {

        private ObservableCollection<ReportTreat> _reportTreat;
        public ObservableCollection<ReportTreat> ReportTreats
        {
            get { return _reportTreat; }
            set
            {
                _reportTreat = value;
                OnPropertyChanged(nameof(ReportTreats));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }*/

    public partial class ReportTreatment : Page
    {
        private Victim victim;
        public ObservableCollection<ReportTreat> treatmentList { get; set; } = new ObservableCollection<ReportTreat>();

        public ReportTreatment(Victim victim)
        {
            InitializeComponent();
            this.victim = new Victim(victim);
            LoadTreatmentList(victim);

        }

        private void LoadTreatmentList(Victim victim)
        {
            int? patientID = victim.PatientID;
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
                                ReportTreat report = new ReportTreat(reader);
                                treatmentList.Add(report);
                            }
                            // Gán ObservableCollection làm nguồn dữ liệu cho DataGrid
                            ReportTreatmentListDataGrid.ItemsSource = treatmentList;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
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

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
