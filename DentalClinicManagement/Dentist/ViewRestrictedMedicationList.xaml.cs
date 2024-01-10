using DentalClinicManagement.Account.Class;
using DentalClinicManagement.Dentist.Class;
using DentalClinicManagement.Employee;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DentalClinicManagement.Dentist
{
    /// <summary>
    /// Interaction logic for ViewRestrictedMedicationList.xaml
    /// </summary>
    /// 

    public partial class ViewRestrictedMedicationList : Page
    {
        DentistClass dentist;
        private Patient patient;
        private PatientRecord patientRecord;
        public ObservableCollection<MedicationList> restrictedMedicationList { get; set; } = new ObservableCollection<MedicationList>();

        public ViewRestrictedMedicationList(DentistClass dentist, Patient patient, PatientRecord patientRecord)
        {
            InitializeComponent();
            this.dentist = new DentistClass(dentist);
            this.patient = new Patient(patient);
            this.patientRecord = new PatientRecord(patientRecord);

            LoadRestrictedMedicationList();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.ViewPatientRecord(dentist, patient));
            }
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.DashBoard(dentist));
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Tìm kiếm.");

        }

        private void AddNewRestrictedMedicationButton_Click(object sender, RoutedEventArgs e)
        {
            RestrictedMedication newRestriction = new RestrictedMedication
            {
                MedicationID = int.TryParse(NewMedicationIDTextBox.Text, out int id) ? id : 0,
                PatientRecordID = patientRecord.PatientRecordID
            };

            // Thực hiện đăng ký và lưu vào database
            RegistryHelpers regist = new RegistryHelpers();  
            if (regist.RegisterRestrictedMedication(newRestriction))
            {
                MessageBox.Show("Thêm thuốc chống chỉ định thành công.");
                MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

                if (mainWindow != null && mainWindow.MainFrame != null)
                {
                    // Chuyển qua cửa sổ PasswordSignUp và chuyển số điện thoại từ SignUp qua
                    mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.ViewRestrictedMedicationList(dentist, patient, patientRecord));
                }
            }
            else
            {
                MessageBox.Show("Thêm mới thất bại. Vui lòng thử lại.");
            }
        }

        private void RestrictedMedicationList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show("Thông tin chi tiết thuốc chống chỉ định.");

        }

        private void LoadRestrictedMedicationList()
        {
            try
            {
                // Câu truy vấn SQL để lấy thông tin Detailed Treatment Plan từ database
                string query = "SELECT rm.MedicationID, ml.Name " +
                                       "FROM [Restricted Medication] rm " +
                                       "INNER JOIN [Medication List] ml ON rm.MedicationID = ml.MedicationID " +
                                       "WHERE @PatientRecordID = rm.PatientRecordID";

                // Tạo và mở kết nối
                DB dB = new DB();
                using (SqlConnection connection = dB.Connection)
                {
                    // Tạo đối tượng SqlCommand
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thực hiện truy vấn SQL và lấy dữ liệu
                        command.Parameters.AddWithValue("@PatientRecordID", patientRecord.PatientRecordID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MedicationList restrictedMedication = new MedicationList(reader);
                                restrictedMedicationList.Add(restrictedMedication);
                            }
                            // Gán ObservableCollection làm nguồn dữ liệu cho DataGrid
                            ContraindicatedMedicationListDataGrid.ItemsSource = restrictedMedicationList;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

    }
}
