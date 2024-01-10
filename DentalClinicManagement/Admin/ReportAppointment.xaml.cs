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

namespace DentalClinicManagement.Admin
{
    /// <summary>
    /// Interaction logic for ReportAppointment.xaml
    /// </summary>
    public class ReportAppoint
    {
        public string Date { get; set; }
        public string Shift { get; set; }
        public string PatientName { get; set; }
        public string Dentist { get; set; }
        public string TroKham { get; set; }
        public string Room { get; set; }
        public string Status { get; set; }
    }

    public class MainViewModel : INotifyPropertyChanged
    {    
        private ObservableCollection<ReportAppoint> _reportAppoint;
        public ObservableCollection<ReportAppoint> ReportAppoints
        {
            get { return _reportAppoint; }
            set
            {
                _reportAppoint = value;
                OnPropertyChanged(nameof(ReportAppoints));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public partial class ReportAppointment : Page
    {
        public ReportAppointment()
        {
            InitializeComponent();
        }

        private void viewHome(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;


            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Admin.DashBoard());
            }
        }

        private void Report(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(DentistSearch.Text))
            {
                MainViewModel viewModel = new MainViewModel()
                {
                    ReportAppoints = new ObservableCollection<ReportAppoint>
                    {
                        new ReportAppoint { Date = "01/01/2023", Shift = "1", PatientName = "Giang", Dentist = "Giang", TroKham = "Trần Hàn Phong", Room = "3", Status = " " },
                        new ReportAppoint { Date = "02/01/2023", Shift = "3", PatientName = "Huy", Dentist = "Huy", TroKham = "Trần Hàn Phong", Room = "7", Status = " " },
                    },
                };
                this.DataContext = viewModel;

            }
            else
            {

                MessageBox.Show("Please enter name of dentist");
            }
        }
    }
}
