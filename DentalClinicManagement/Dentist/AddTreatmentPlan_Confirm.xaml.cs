using DentalClinicManagement.Account.Class;
using DentalClinicManagement.Dentist.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
        DetailedTreatmentPlan detailPlan;
        DentistClass dentist;
        TreatmentChild child;
        FullDetailedTreatmentPlan fullplan;
        Patient patient;

        public AddTreatmentPlan_Confirm(DetailedTreatmentPlan detailPlan, DentistClass dentist, TreatmentChild child, ToothSurface toothSurface, Patient patient)
        {
            InitializeComponent();
            this.dentist = new DentistClass(dentist);
            this.detailPlan = new DetailedTreatmentPlan(detailPlan);
            this.child = new TreatmentChild(child);

            fullplan = new FullDetailedTreatmentPlan(detailPlan);
            fullplan.TeethID = toothSurface.TeethID;
            fullplan.SurfaceID = toothSurface.SurfaceID;

            MainCanvas.DataContext = fullplan;
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
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.AddTreatmentPlan_ChooseTeeth(detailPlan ,dentist, child, patient));
            }
        }

        private void FixButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.AddTreatmentPlan_ChooseTreatment(dentist, patient));
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //MessageBox.Show($"{detailPlan.ConductedTreatmentID}", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                //MessageBox.Show($"{detailPlan.TreatmentID}", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                //MessageBox.Show($"{detailPlan.PatientID}", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                //MessageBox.Show($"{detailPlan.Date}", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                //MessageBox.Show($"{detailPlan.DentistID}", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                //MessageBox.Show($"{detailPlan.Assistant}", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                //MessageBox.Show($"{detailPlan.ToothSurfaceID}", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);




                // Thực hiện đăng ký và lưu vào database
                RegistryHelpers regist = new RegistryHelpers();
                if (regist.RegisterDetailTreatmentPlan(detailPlan))
                {
                    MessageBox.Show("Thêm kế hoạch điều trị thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

                    if (mainWindow != null && mainWindow.MainFrame != null)
                    {
                        mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.DashBoard(dentist));
                    }
                }
                else
                {
                    MessageBox.Show("Thêm kế hoạch thất bại. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }       
    }

}
