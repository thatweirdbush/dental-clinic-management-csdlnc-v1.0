using DentalClinicManagement.Account.Class;
using DentalClinicManagement.Dentist.Class;
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

namespace DentalClinicManagement.Dentist
{
    /// <summary>
    /// Interaction logic for AddTreatmentPlan_ChooseTeeth.xaml
    /// </summary>
    public partial class AddTreatmentPlan_ChooseTeeth : Page
    {
        DentistClass dentist;
        DetailedTreatmentPlan detailPlan;
        TreatmentChild child;
        Patient patient;

        public AddTreatmentPlan_ChooseTeeth(DetailedTreatmentPlan detailPlan, DentistClass dentist, TreatmentChild child, Patient patient)
        {
            InitializeComponent();
            this.detailPlan = new DetailedTreatmentPlan(detailPlan);
            this.dentist = new DentistClass(dentist);
            this.child = new TreatmentChild(child);
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
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.AddTreatmentPlan_ChooseDateAndDentist(dentist, child, patient));
            }
        }
        private void FinishButton_Click(object sender, RoutedEventArgs e)
        {
            int teethID = int.TryParse(TeethIDTextBox.Text, out int teeth) ? teeth : 1;
            int surfaceID = int.TryParse((Surface.SelectedItem as ComboBoxItem).Content.ToString(), out int surface) ? surface : 1;

            ToothSurface toothSurface = LoadToothSurface(teethID, surfaceID);
            //if (toothSurface == null)
            //{
            //    MessageBox.Show($"{detailPlan.TreatmentID}");
            //    return;

            //}

            detailPlan.ToothSurfaceID = toothSurface.ToothSurfaceID;

            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.AddTreatmentPlan_Confirm(detailPlan, dentist, child, toothSurface, patient));
            }
        }

        private ToothSurface LoadToothSurface(int? tooth, int? surface)
        {
            try
            {
                // Câu truy vấn SQL để lấy thông tin PatientRecord từ database dựa trên PatientID
                string query = "SELECT TOP 1* FROM [Tooth Surface] WHERE TeethID = @TeethID AND SurfaceID = @SurfaceID";

                // Tạo và mở kết nối
                DB dB = new DB();
                using (SqlConnection connection = dB.Connection)
                {
                    // Tạo đối tượng SqlCommand
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số cho câu truy vấn
                        command.Parameters.AddWithValue("@TeethID", tooth);
                        command.Parameters.AddWithValue("@SurfaceID", surface);

                        // Sử dụng SqlDataReader để đọc dữ liệu từ database
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Kiểm tra xem có dữ liệu hay không
                            if (reader.Read())
                            {
                                // Tạo đối tượng PatientRecord từ SqlDataReader
                                ToothSurface toothSurface = new ToothSurface(reader);
                                return toothSurface;
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
