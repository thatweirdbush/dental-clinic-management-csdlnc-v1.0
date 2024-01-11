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
using DentalClinicManagement.Dentist.Class;
using DentalClinicManagement.Employee.Class;

namespace DentalClinicManagement.Dentist
{
    /// <summary>
    /// Interaction logic for AddTreatmentPlan_ChooseDateAndDentist.xaml
    /// </summary>
    public partial class AddTreatmentPlan_ChooseDateAndDentist : Page
    {
        DentistClass dentist;
        TreatmentChild child;
        DetailedTreatmentPlan detailPlan;
        Patient patient;
        public AddTreatmentPlan_ChooseDateAndDentist(DentistClass dentist, TreatmentChild child, Patient patient)
        {
            InitializeComponent();
            this.dentist = new DentistClass(dentist);
            this.child = new TreatmentChild(child);
            MainCanvas.DataContext = this.child;
            this.patient = new Patient(patient);
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.DashBoard(dentist));
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.AddTreatmentPlan_ChooseTreatment(dentist, patient));
            }
        }

        private void ChooseTeethButton_Click(object sender, RoutedEventArgs e)
        {
            detailPlan = new DetailedTreatmentPlan
            {
                TreatmentID = child.TreatmentID,
                ConductedTreatmentID = child.TreatmentChildID,
                DentistID = int.TryParse(DentistTextBox.Text, out int id) ? id : null,
                Assistant = AssistantTextBox.Text,
                Date = Date.SelectedDate ?? DateTime.Now,
                PatientID = patient.PatientID
            };

            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.AddTreatmentPlan_ChooseTeeth(detailPlan, dentist, child, patient));
            }
        }
    }
}
