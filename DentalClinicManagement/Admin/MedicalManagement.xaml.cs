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
using DentalClinicManagement.Account.Class;

namespace DentalClinicManagement.Admin
{
    /// <summary>
    /// Interaction logic for MedicalManagement.xaml
    /// </summary>
    public partial class MedicalManagement : Page
    {
        AdminClass admin;
       
        public MedicalManagement(AdminClass admin)
        {
            InitializeComponent();
            this.admin = new AdminClass(admin);
        }

        private void OnBackButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Admin.DashBoard(admin));
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void addMedical(object sender, RoutedEventArgs e)
        {
            ViewMedicalDetail.Visibility = Visibility.Collapsed;
            EditMedicalDetail.Visibility = Visibility.Visible;
        }

        private void deletemedical(object sender, RoutedEventArgs e)
        {
            ViewMedicalDetail.Visibility = Visibility.Collapsed;
            EditMedicalDetail.Visibility = Visibility.Collapsed;
        }

        private void editMedical(object sender, RoutedEventArgs e)
        {
            ViewMedicalDetail.Visibility = Visibility.Collapsed;
            EditMedicalDetail.Visibility = Visibility.Visible;
        }

        private void completeMedical(object sender, RoutedEventArgs e)
        {
            ViewMedicalDetail.Visibility = Visibility.Visible;
            EditMedicalDetail.Visibility = Visibility.Collapsed;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {

        }

        private void comboPage_Selected(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
