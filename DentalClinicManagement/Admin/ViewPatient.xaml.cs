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
    /// Interaction logic for ViewPatient.xaml
    /// </summary>
    /// 

    public class PatientInfor
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }

    }

    public class MainViewModels : INotifyPropertyChanged
    {

        private ObservableCollection<PatientInfor> _patientInfo;
        public ObservableCollection<PatientInfor> PatientInfos
        {
            get { return _patientInfo; }
            set
            {
                _patientInfo = value;
                OnPropertyChanged(nameof(PatientInfos));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    public partial class ViewPatient : Page
    {
        public ViewPatient()
        {
            InitializeComponent();
        }

        public ObservableCollection<PatientInfor> PatientInfos { get; set; }

        private void checkRecord_btn(object sender, MouseButtonEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;


            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Admin.ViewRecord());
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;


            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Admin.DashBoard());
            }
        }

        private void search_click(object sender, RoutedEventArgs e)
        {
            MainViewModels viewModel = new MainViewModels()
            {
                PatientInfos = new ObservableCollection<PatientInfor>
                    {
                        new PatientInfor { Id = "1", Name = "Giang", Sex = "Nam", Address = "TP.HCM" },
                        new PatientInfor { Id = "2", Name = "Huy", Sex = "Nam", Address = "TP.HCM" },
                    },
            };
            this.DataContext = viewModel;
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
