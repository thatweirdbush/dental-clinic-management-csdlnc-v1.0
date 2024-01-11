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
    /// Interaction logic for AddTreatmentPlan_Confirm.xaml
    /// </summary>
    public partial class AddTreatmentPlan_Confirm : Page
    {
        public AddTreatmentPlan_Confirm()
        {
            InitializeComponent();
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
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.AddTreatmentPlan_ChooseTeeth());
            }
        }

        private void FixButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.AddTreatmentPlan_ChooseTreatment());
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thêm kế hoạch điều trị thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.DashBoard());
            }
        }
        // How to get data from another page
        // public AddTreatmentPlan_Confirm(string treatmentID, string teeth, string date, string dentist)
        // {
        //     InitializeComponent();
        //     TreatmentIDTextBlock.Text = treatmentID;
        //     TeethTextBlock.Text = teeth;
        //     DateTextBlock.Text = date;
        //     DentistTextBlock.Text = dentist;
        // }

        // How to get date data from another page when using DatePicker
        // public AddTreatmentPlan_Confirm(string treatmentID, string teeth, DateTime date, string dentist)
        // {
        //     InitializeComponent();
        //     TreatmentIDTextBlock.Text = treatmentID;
        //     TeethTextBlock.Text = teeth;
        //     DateTextBlock.Text = date.ToString("dd/MM/yyyy");
        //     DentistTextBlock.Text = dentist;
        // }



    }

}
