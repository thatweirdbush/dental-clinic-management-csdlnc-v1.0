﻿using DentalClinicManagement.Dentist.Class;
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
using DentalClinicManagement.Account.Class;

namespace DentalClinicManagement.Admin
{
    /// <summary>
    /// Interaction logic for MedicalManagement.xaml
    /// </summary>
    public partial class MedicalManagement : Page
    {
        AdminClass admin;
        public ObservableCollection<MedicationList> medicationList { get; set; } = new ObservableCollection<MedicationList>();
       
        public MedicalManagement(AdminClass admin)
        {
            InitializeComponent();
            this.admin = new AdminClass(admin);
            LoadMedicationList();
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
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Admin.DashBoard(admin));
            }
        }

        private void LoadMedicationList()
        {
            try
            {
                // Câu truy vấn SQL để lấy thông tin Detailed Treatment Plan từ database
                string query = "SELECT * FROM [Medication List]";

                // Tạo và mở kết nối
                DB dB = new DB();
                using (SqlConnection connection = dB.Connection)
                {
                    // Tạo đối tượng SqlCommand
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thực hiện truy vấn SQL và lấy dữ liệu
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MedicationList medication = new MedicationList(reader);
                                medicationList.Add(medication);
                            }
                            // Gán ObservableCollection làm nguồn dữ liệu cho DataGrid
                            MedicationListDataGrid.ItemsSource = medicationList;
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
