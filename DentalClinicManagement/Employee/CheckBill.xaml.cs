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

namespace DentalClinicManagement.Employee
{
    /// <summary>
    /// Interaction logic for CheckBill.xaml
    /// </summary>
    public partial class CheckBill : Page
    {
        public CheckBill()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;


            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Employee.SearchCustomerRecord());
            }
        }

        private void medicines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void payButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("success");
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;


            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Employee.SearchCustomerRecord());
            }
        }
    }
}
