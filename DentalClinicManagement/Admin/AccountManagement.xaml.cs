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
    /// Interaction logic for AccountManagement.xaml
    /// </summary>
    public partial class AccountManagement : Page
    {
        public AccountManagement()
        {
            InitializeComponent();
        }

        private void OnBackButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;


            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Admin.DashBoard());
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {

        }

        private void comboPage_Selected(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void addAccount(object sender, RoutedEventArgs e)
        {
            EditAccountDetail.Visibility = Visibility.Visible;
            ViewAccountDetail.Visibility = Visibility.Collapsed;
        }

        private void completeEdit(object sender, RoutedEventArgs e)
        {
            EditAccountDetail.Visibility = Visibility.Collapsed;
            ViewAccountDetail.Visibility = Visibility.Visible;
        }

        private void blockAccount(object sender, RoutedEventArgs e)
        {

        }

        private void editAccount(object sender, RoutedEventArgs e)
        {
            EditAccountDetail.Visibility = Visibility.Visible;
            ViewAccountDetail.Visibility = Visibility.Collapsed;
        }
    }
}
