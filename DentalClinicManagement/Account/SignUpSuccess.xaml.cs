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

namespace DentalClinicManagement.Account
{
    /// <summary>
    /// Interaction logic for SignUpSuccess.xaml
    /// </summary>
    public partial class SignUpSuccess : Page
    {
        public SignUpSuccess()
        {
            InitializeComponent();
        }
        private void toSignInButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;


            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Account.SignIn());
            }
        }
    }
}
