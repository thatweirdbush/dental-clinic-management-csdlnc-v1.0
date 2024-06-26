﻿using DentalClinicManagement.Account;
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

namespace DentalClinicManagement.Customer
{
    /// <summary>
    /// Interaction logic for CheckAppoinment.xaml
    /// </summary>
    public partial class CheckAppoinment : Page
    {
        // Biến lưu User từ cửa sổ Sign In
        private CustomerClass user;

        public CheckAppoinment(CustomerClass user)
        {
            InitializeComponent();
            this.user = new CustomerClass(user);
        }

        private void makeAppointment(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;


            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Customer.MakeAppointment(user));
            }
        }

        private void homePageButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;


            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Customer.DashBoard(user));
            }
        }
    }
}
