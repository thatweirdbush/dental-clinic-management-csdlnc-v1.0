using DentalClinicManagement.Account;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using DentalClinicManagement.Dentist.Class;
using DentalClinicManagement.Employee.Class;

namespace DentalClinicManagement.Dentist
{
    /// <summary>
    /// Interaction logic for ViewPatientRecord.xaml
    /// </summary>
    public partial class ViewPatientRecord : Page
    {
        private Patient patient;
        private PatientRecord patientRecord;

        public ViewPatientRecord(Patient patient)
        {
            InitializeComponent();

            this.patient = new Patient(patient);
            patientRecord = LoadPatientRecord(patient.PatientID);

            // Thiết lập DataContext cho Canvas bên trái, tất cả các TextBlock con sẽ kế thừa DataContext này
            LeftCanvas.DataContext = patient;

            // Thiết lập DataContext cho Canvas bên phải, tất cả các TextBlock con sẽ kế thừa DataContext này
            RightCanvas.DataContext = patientRecord;
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            // Thực hiện cập nhật và lưu vào database
            if (UpdateGeneralInformation())
            {
                MessageBox.Show("Cập nhật thành công.");
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại. Vui lòng thử lại.");
            }
        }

        private bool UpdateGeneralInformation()
        {
            if (patientRecord == null)
            {
                MessageBox.Show("Hồ sơ bệnh án không tồn tại.");
                return false;
            }
            try
            {
                patientRecord.GeneralInformation = TeethHealthStatusTextBox.Text;
                string newGeneralInformation = patientRecord.GeneralInformation;

                DB dB = new DB();
                using (SqlConnection connection = dB.Connection)
                {
                    // Thực hiện cập nhật dữ liệu vào database
                    string query = "UPDATE [Patient Record] SET GeneralInformation = @GeneralInformation " +
                                   "WHERE @PatientRecordID = PatientRecordID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@GeneralInformation", newGeneralInformation);
                        command.Parameters.AddWithValue("@PatientRecordID", patientRecord.PatientRecordID);

                        command.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.ViewPatientList());
            }
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.DashBoard());
            }
        }

        private void ViewTreatmentPlanButton_Click(object sender, RoutedEventArgs e)
        {
            if(patientRecord == null)
            {
                MessageBox.Show("Không truy cập được vì hồ sơ bệnh án không tồn tại.");
                return;
            }

            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.ViewTreatmentPlanList(patient));
            }
        }

        private void ViewPaymentButton_Click(object sender, RoutedEventArgs e)
        {
            if (patientRecord == null)
            {
                MessageBox.Show("Không truy cập được vì hồ sơ bệnh án không tồn tại.");
                return;
            }

            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.ViewPaymentList(patient));
            }
        }

        private void ViewContraindicatedMedicationsButton_Click(object sender, RoutedEventArgs e)
        {
            if (patientRecord == null)
            {
                MessageBox.Show("Không truy cập được vì hồ sơ bệnh án không tồn tại.");
                return;
            }

            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.ViewRestrictedMedicationList(patient, patientRecord));
            }
        }
       
        private PatientRecord LoadPatientRecord(int? patientID)
        {
            try
            {
                // Câu truy vấn SQL để lấy thông tin PatientRecord từ database dựa trên PatientID
                string query = "SELECT TOP 1* FROM [Patient Record] WHERE PatientID = @PatientID";

                // Tạo và mở kết nối
                DB dB = new DB();
                using (SqlConnection connection = dB.Connection)
                {
                    // Tạo đối tượng SqlCommand
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số cho câu truy vấn
                        command.Parameters.AddWithValue("@PatientID", patientID);

                        // Sử dụng SqlDataReader để đọc dữ liệu từ database
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Kiểm tra xem có dữ liệu hay không
                            if (reader.Read())
                            {
                                // Tạo đối tượng PatientRecord từ SqlDataReader
                                PatientRecord patientRecord = new PatientRecord(reader);
                                return patientRecord;
                            }
                            else
                            {
                                // Trường hợp không tìm thấy thông tin PatientRecord
                                return null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
