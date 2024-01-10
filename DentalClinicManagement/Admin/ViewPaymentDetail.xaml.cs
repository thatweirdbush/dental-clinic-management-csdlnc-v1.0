using DentalClinicManagement.Account.Class;
using DentalClinicManagement.Dentist.Class;
using DentalClinicManagement.Employee.Class;
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
    /// Interaction logic for ViewPaymentDetail.xaml
    /// </summary>
    public partial class ViewPaymentDetail : Page
    {
        AdminClass admin;
        Patient patient;
        Payment payment;
        PaymentDetail paymentDetail;
        public ViewPaymentDetail(Patient patient, Payment payment, PaymentDetail paymentDetail)
        {
            InitializeComponent();
            this.admin = new AdminClass(admin);
            this.patient = new Patient(patient);
            this.payment = new Payment(payment);
            this.paymentDetail = new PaymentDetail(paymentDetail);

            // Thiết lập DataContext cho Canvas, tất cả các TextBlock con sẽ kế thừa DataContext này
            MainCanvas.DataContext = this.paymentDetail;
        }
        private void NeedPaymentListButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Admin.ViewNeedPaymentList(patient, payment, paymentDetail));
            }
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Admin.DashBoard(admin));
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Admin.ViewPatientRecord(admin, patient));
            }
        }
    }
}
