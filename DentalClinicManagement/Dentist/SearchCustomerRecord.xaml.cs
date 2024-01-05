using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for SearchCustomerRecord.xaml
    /// </summary>
    public class sourceInformation
    {
        public string teethImage { get; set; }
        public string makeAppoinmentImage { get; set; }
        public string Fullname { get; set; }
        public string Year { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
    public class MedicalRecord
    {
        public string Date { get; set; }
        public string Condition { get; set; }
        public string Medicine { get; set; }
        public string ReDate { get; set; }
        public string Doctor { get; set; }

        public string Payment { get; set; }
    }

    public class MainViewModel : INotifyPropertyChanged
    {
        private sourceInformation _patientInfo;
        public sourceInformation PatientInfo
        {
            get { return _patientInfo; }
            set
            {
                _patientInfo = value;
                OnPropertyChanged(nameof(PatientInfo));
            }
        }

        private ObservableCollection<MedicalRecord> _medicalRecords;
        public ObservableCollection<MedicalRecord> MedicalRecords
        {
            get { return _medicalRecords; }
            set
            {
                _medicalRecords = value;
                OnPropertyChanged(nameof(MedicalRecords));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public partial class SearchCustomerRecord : Page
    {
        public SearchCustomerRecord()
        {
            InitializeComponent();
        }

        public ObservableCollection<MedicalRecord> MedicalRecords { get; set; }

        sourceInformation src = new sourceInformation();

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPhoneSearch.Text))
            {
                MainViewModel viewModel = new MainViewModel()
                {
                    PatientInfo = new sourceInformation
                    {
                        Fullname = "Trương Tấn Đạt",
                        Year = "2003",
                        Gender = "Nam",
                        Phone = "0123456789",
                        Address = "TP Hồ Chí Minh"
                    },

                    // Khởi tạo danh sách MedicalRecords
                    MedicalRecords = new ObservableCollection<MedicalRecord>
                    {
                        new MedicalRecord { Date = "01/01/2023", Condition = "Bình thường", Medicine = "Paracetamol", ReDate = "01/02/2023", Doctor = "Trần Hàn Phong", Payment = "Yes" },
                        new MedicalRecord { Date = "02/01/2023", Condition = "Nguy cơ cao", Medicine = "Amoxicillin", ReDate = "01/03/2023", Doctor = "Quách Khiếu Thiên", Payment = "No" },
                    },
                };
                this.DataContext = viewModel;
            }
            else
            {
                MessageBox.Show("Please enter phone number");
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;


            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.DashBoard());
            }
        }

        private void AddRecord(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;


            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.AddRecord());
            }
        }
    }
}
