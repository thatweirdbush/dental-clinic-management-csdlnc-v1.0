using DentalClinicManagement.Dentist.Class;
using DentalClinicManagement.Dentist;
using DentalClinicManagement.Employee.Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DentalClinicManagement.Account.Class
{
    public class AdminClass
    {
        public int? AdminID { get; set; }
        public string? Name { get; set; }
        public string? PhoneNo { get; set; }
        public int? AccountID { get; set; }

        // Constructor để tạo đối tượng Customer từ SqlDataReader
        public AdminClass(SqlDataReader reader)
        {
            AdminID = (int)reader["AdminID"];
            Name = reader["Name"].ToString();
            PhoneNo = reader["PhoneNo"].ToString();
            AccountID = DBNull.Value.Equals(reader["AccountID"]) ? (int?)null : (int)reader["AccountID"];
        }

        public AdminClass() { }

        public AdminClass(AdminClass other)
        {
            AdminID = other.AdminID;
            Name = other.Name;
            PhoneNo = other.PhoneNo;
            AccountID = other.AccountID;
        }

        public AdminClass? LoadUser(AccountClass account)
        {
            try
            {
                // Câu truy vấn SQL để lấy thông tin Admin từ database dựa trên AccountID
                string query = "SELECT TOP 1* FROM [Admin] WHERE AccountID = @AccountID";

                // Tạo và mở kết nối
                DB dB = new DB();
                using (SqlConnection connection = dB.Connection)
                {
                    // Tạo đối tượng SqlCommand
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số cho câu truy vấn
                        command.Parameters.AddWithValue("@AccountID", account.AccountID);

                        // Sử dụng SqlDataReader để đọc dữ liệu từ database
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Kiểm tra xem có dữ liệu hay không
                            if (reader.Read())
                            {
                                // Tạo đối tượng AdminClass từ SqlDataReader
                                AdminClass user = new AdminClass(reader);
                                return user;
                            }
                            else
                            {
                                // Trường hợp không tìm thấy thông tin AdminClass
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
