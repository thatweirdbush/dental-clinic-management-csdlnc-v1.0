using DentalClinicManagement.Dentist.Class;
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
    /// Interaction logic for ViewDetailTreatmentPlan.xaml
    /// </summary>
    public partial class ViewDetailTreatmentPlan : Page
    {
        private DetailedTreatmentPlan plan;
        private Patient patient;
        public ViewDetailTreatmentPlan(DetailedTreatmentPlan plan, Patient patient)
        {
            InitializeComponent();
            this.plan = new DetailedTreatmentPlan(plan);
            this.patient = new Patient(patient);

            // Thiết lập DataContext cho Canvas chinhs, tất cả các TextBlock con sẽ kế thừa DataContext này
            MainCanvas.DataContext = plan;
        }
        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Admin.DashBoard());
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Admin.ViewTreatmentPlanList(patient));
            }
        }

        private void TreatingToothListButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Admin.ViewTreatingTeethList(plan, patient));
            }
        }
    }
}
