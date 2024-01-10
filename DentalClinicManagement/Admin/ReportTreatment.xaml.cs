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
using DentalClinicManagement.Admin.Class;

namespace DentalClinicManagement.Admin
{
    /// <summary>
    /// Interaction logic for ReportTreatment.xaml
    /// </summary>

    public class MainViewModel2 : INotifyPropertyChanged
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
    }

    public partial class ReportTreatment : Page
    {
        public ReportTreatment()
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
                MainViewModel2 viewModel = new MainViewModel2()
                {
                    ReportTreats = new ObservableCollection<ReportTreat>
                    {
                        new ReportTreat { ID = "001", Date = "01/01/2023", PatientName = "Giang", Status = " " },
                        new ReportTreat { ID = "002", Date = "02/01/2023", PatientName = "Huy", Status = " " },
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
