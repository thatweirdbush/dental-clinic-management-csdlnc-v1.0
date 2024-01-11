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
    /// Interaction logic for AddTreatmentPlan_ChooseTeeth.xaml
    /// </summary>
    public partial class AddTreatmentPlan_ChooseTeeth : Page
    {
        public AddTreatmentPlan_ChooseTeeth()
        {
            InitializeComponent();
            AddSurface();
        }
        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.DashBoard());
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.AddTreatmentPlan_ChooseDateAndDentist());
            }
        }
        private void FinishButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.AddTreatmentPlan_Confirm());
            }
        }

        private void AddSurface()
        {
            Surface.Items.Add("L (Mặt trong)");
            Surface.Items.Add("F (Mặt ngoài)");
            Surface.Items.Add("D (Mặt xa)");
            Surface.Items.Add("M (Mặt gần)");
            Surface.Items.Add("T (Mặt đỉnh)");
            Surface.Items.Add("R (Mặt chân răng)");
        }
        

    }
}
