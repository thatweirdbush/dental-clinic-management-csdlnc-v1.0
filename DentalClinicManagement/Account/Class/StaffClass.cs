using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace DentalClinicManagement.Account.Class
{
    public class StaffClass
    {
        public int? StaffID { get; set; }
        public string? Name { get; set; }
        public string? PhoneNo { get; set; }
        public int? AccountID { get; set; }

        // Constructor để tạo đối tượng Customer từ SqlDataReader
        public StaffClass(SqlDataReader reader)
        {
            StaffID = DBNull.Value.Equals(reader["StaffID"]) ? (int?)null : (int)reader["StaffID"];
            Name = reader["Name"].ToString();
            PhoneNo = reader["PhoneNo"].ToString();
            AccountID = DBNull.Value.Equals(reader["AccountID"]) ? (int?)null : (int)reader["AccountID"];
        }

        // Constructor mặc định
        public StaffClass() { }

        // Copy constructor
        public StaffClass(StaffClass other)
        {
            StaffID = other.StaffID;
            Name = other.Name;
            PhoneNo = other.PhoneNo;
            AccountID = other.AccountID;
        }

        public StaffClass? LoadUser(AccountClass account)
        {
            try
            {
                // Câu truy vấn SQL để lấy thông tin Dentist từ database dựa trên AccountID
                string query = "SELECT TOP 1* FROM [Staff] WHERE AccountID = @AccountID";

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
                                // Tạo đối tượng StaffClass từ SqlDataReader
                                StaffClass user = new StaffClass(reader);
                                return user;
                            }
                            else
                            {
                                // Trường hợp không tìm thấy thông tin StaffClass
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
