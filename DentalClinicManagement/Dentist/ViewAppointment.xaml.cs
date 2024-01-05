using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
    /// Interaction logic for ViewAppointment.xaml
    /// </summary>
    public partial class ViewAppointment : Page
    {
        public ObservableCollection<Appointment> Appointment { get; set; }
        private readonly string[] StatusArray = { "Đã xong", "Đã hủy", "Quá hẹn" };
        public ViewAppointment()
        {
            InitializeComponent();
            DataContext = this;
            Random random = new Random();
            sttTextBlock.IsEnabled = false;
            nameTextBox.IsEnabled = false;
            phoneTextBox.IsEnabled = false;
            timeTextBox.IsEnabled = false;
            noteTextBox.IsEnabled = false;
            updateStatusComboBox.IsEnabled = false;

            Appointment = new ObservableCollection<Appointment>();
            for (int i = 1; i <= 10; i++)
            {
                Appointment.Add(new Appointment
                {
                    STT = i,
                    Name = $"Khách hàng {i}",
                    Phone = $"12345678{i}",
                    Time = DateTime.Now,
                    Note = $"Ghi chú {i}",
                    Status = StatusArray[random.Next(StatusArray.Length)]
                });
            }

            // Gán danh sách khách hàng làm nguồn dữ liệu cho DataGrid
            appointmentDataGrid.ItemsSource = Appointment;
        }

        private void appointmentDataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            // Chỉnh màu sắc cho các hàng chẵn và lẻ
            if (e.Row.Item is Appointment appointment && appointment.STT % 2 == 0)
            {
                e.Row.Background = Brushes.LightBlue; // Màu cho hàng chẵn
            }
            else
            {
                e.Row.Background = Brushes.White; // Màu cho hàng lẻ hoặc khi giá trị STT là lẻ
            }
        }

        

        private void home_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;


            if (mainWindow != null && mainWindow.MainFrame != null)
            {
                mainWindow.MainFrame.Navigate(new DentalClinicManagement.Dentist.DashBoard());
            }
        }


        private void FilterDataGrid()
        {
            DateTime? fromDate = fromDatePicker.SelectedDate;
            DateTime? toDate = toDatePicker.SelectedDate;

            string selectedStatus = ((ComboBoxItem)statusComboBox.SelectedItem)?.Content.ToString() ?? "Tất cả";

            // Kiểm tra nếu cả hai DatePicker đều đã được chọn và một trạng thái đã được chọn
            if (fromDate.HasValue && toDate.HasValue && selectedStatus != null)
            {
                if (fromDate.Value > toDate.Value)
                {
                    MessageBox.Show("Vui lòng chọn ngày bắt đầu và kết thúc hợp lệ", "Ngày không hợp lệ", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    // Lọc dữ liệu trong khoảng từ fromDate đến toDate và theo trạng thái
                    appointmentDataGrid.ItemsSource = Appointment.Where(c => c.Time >= fromDate && c.Time <= toDate && (selectedStatus == "Tất cả" || c.Status == selectedStatus));
                }
            }
            if (!fromDate.HasValue && !toDate.HasValue && selectedStatus != null)
            {
                if (selectedStatus == "Tất cả")
                {
                    appointmentDataGrid.ItemsSource = Appointment; // Hiển thị tất cả dữ liệu nếu chọn "Tất cả"
                }
                else
                {
                    appointmentDataGrid.ItemsSource = Appointment.Where(c => c.Status == selectedStatus);
                }
            }
            if (fromDate.HasValue && !toDate.HasValue && selectedStatus != null)
            {
                appointmentDataGrid.ItemsSource = Appointment.Where(c => c.Time >= fromDate && (selectedStatus == "Tất cả" || c.Status == selectedStatus));
            }
        }

        private void Filter_Button_Click(object sender, RoutedEventArgs e)
        {
            FilterDataGrid();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (appointmentDataGrid.SelectedItem != null)
            {
                Appointment selectedAppointment = (Appointment)appointmentDataGrid.SelectedItem;
                sttTextBlock.IsEnabled = true;
                nameTextBox.IsEnabled = true;
                phoneTextBox.IsEnabled = true;
                timeTextBox.IsEnabled = true;
                noteTextBox.IsEnabled = true;
                updateStatusComboBox.IsEnabled = true;
                // Cập nhật giá trị cho các TextBlock
                sttTextBlock.Text = selectedAppointment.STT.ToString();
                nameTextBox.Text = selectedAppointment.Name;
                phoneTextBox.Text = selectedAppointment.Phone;
                timeTextBox.Text = Convert.ToDateTime(selectedAppointment.Time).ToString("hh:mm dd/MM/yyyy");
                noteTextBox.Text = selectedAppointment.Note;
                updateStatusComboBox.Text = selectedAppointment.Status;
            }
            else
            {
                // Không có dòng nào được chọn

                // Cập nhật giá trị và tắt trạng thái Enabled cho các TextBlock và TextBox
                sttTextBlock.Text = string.Empty;
                nameTextBox.Text = string.Empty;
                phoneTextBox.Text = string.Empty;
                timeTextBox.Text = string.Empty;
                noteTextBox.Text = string.Empty;
                updateStatusComboBox.Text = string.Empty;

                sttTextBlock.IsEnabled = false;
                nameTextBox.IsEnabled = false;
                phoneTextBox.IsEnabled = false;
                timeTextBox.IsEnabled = false;
                noteTextBox.IsEnabled = false;
                updateStatusComboBox.IsEnabled = false;
            }
        }


    }
    public class Appointment
    {
        public int STT { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public DateTime? Time { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }
    }

    public class StatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string status)
            {
                switch (status)
                {
                    case "Quá hẹn":
                        return Brushes.Yellow; // Màu vàng cho trạng thái "Quá hẹn"
                    case "Đã hủy":
                        return Brushes.Red; // Màu đỏ cho trạng thái "Đã hủy"
                    case "Đã xong":
                        return Brushes.Green; // Màu xanh lá cho trạng thái "Đã xong"
                    default:
                        return Brushes.Transparent; // Mặc định màu trong suốt
                }
            }

            return Brushes.Transparent; // Mặc định màu trong suốt
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
