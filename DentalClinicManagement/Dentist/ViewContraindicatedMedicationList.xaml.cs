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

namespace DentalClinicManagement.Dentist
{
    /// <summary>
    /// Interaction logic for ViewContraindicatedMedicationList.xaml
    /// </summary>
    public partial class ViewContraindicatedMedicationList : Page
    {
        public ViewContraindicatedMedicationList()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.ViewPatientRecord());
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

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddNewPatientButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ContraindicatedMedicationList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Mở cửa sổ thông tin chi tiết thuốc chống chỉ định.");

        }
    }
}
