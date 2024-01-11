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
using DentalClinicManagement.Account.Class;

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
        AdminClass admin;
        public ObservableCollection<ReportTreat> reportTreatmentList { get; set; } = new ObservableCollection<ReportTreat>();

        public ReportTreatment(AdminClass admin)
        {
            InitializeComponent();
            this.admin = new AdminClass(admin);
            LoadReportTreat();
        }

        private void viewHome(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;


            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Admin.DashBoard(admin));
            }
        }

        private void LoadReportTreat()
        {

            try
            {
                // Câu truy vấn SQL để lấy thông tin AppointmentRequest từ database
                string query = "SELECT dtl.ConductedTreatmentID, dtl.Date, [Patient].Name, dtl.Status\r\nFROM [Detailed Treatment Plan] dtl, [Patient]\r\nWHERE dtl.PatientID = [Patient].PatientID";
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
                                ReportTreat reportTreat = new ReportTreat(reader);
                                reportTreatmentList.Add(reportTreat);
                            }
                            // Gán ObservableCollection làm nguồn dữ liệu cho DataGrid
                            ReportTreatListView.ItemsSource = reportTreatmentList;
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

        private void FilterDataGrid()
        {
            DateTime? fromDate = fromDatePicker.SelectedDate;
            DateTime? toDate = toDatePicker.SelectedDate;

            string selectPatient = PatientSearch.Text;

            // Kiểm tra nếu cả hai DatePicker đều đã được chọn và một trạng thái đã được chọn
            if (fromDate.HasValue && toDate.HasValue && selectPatient != null)
            {
                if (fromDate.Value > toDate.Value)
                {
                    MessageBox.Show("Vui lòng chọn ngày bắt đầu và kết thúc hợp lệ", "Ngày không hợp lệ", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {

                    // Lọc dữ liệu trong khoảng từ fromDate đến toDate và theo trạng thái
                    ReportTreatListView.ItemsSource = reportTreatmentList.Where(c => c.Date >= fromDate && c.Date <= toDate && (c.Name.Contains(selectPatient) == true));
                }
            }
            if (!fromDate.HasValue && !toDate.HasValue && selectPatient != null)
            {
                ReportTreatListView.ItemsSource = reportTreatmentList.Where(c => c.Name.Contains(selectPatient));
            }
        }
        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            FilterDataGrid();
        }
    }
}
