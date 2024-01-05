using System;
using System.Collections.Generic;
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

    public class PatientInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }

    }
   public partial class ViewPatient : Page
    {
        public ViewPatient()
        {
            InitializeComponent();
        }

        private void CheckRecord_btn(object sender, MouseButtonEventArgs e)
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

    }
}
