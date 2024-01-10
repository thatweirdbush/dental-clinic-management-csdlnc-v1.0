using DentalClinicManagement.Dentist.Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DentalClinicManagement.Employee.Class
{
    public class PaymentDetail
    {
        public int? PayDetailID { get; set; }
        public int? PaymentID { get; set; }
        public decimal? TotalPayment { get; set; }
        public decimal? TotalPaid { get; set; }
        public decimal? Change { get; set; }
        public DateTime? Date { get; set; }
        public string? Payer { get; set; }
        public string? PaymentMethod { get; set; }
        public string? Note { get; set; }

        // Constructor để tạo đối tượng Payment từ SqlDataReader
        public PaymentDetail(SqlDataReader reader)
        {
            PayDetailID = (int)reader["PayDetailID"];
            PaymentID = DBNull.Value.Equals(reader["PaymentID"]) ? (int?)null : (int)reader["PaymentID"];
            // Đọc giá trị từ cột TotalPayment và kiểm tra null
            TotalPayment = DBNull.Value.Equals(reader["TotalPayment"]) ? (decimal?)null : (decimal)reader["TotalPayment"];

            // Đọc giá trị từ cột TotalPaid và kiểm tra null
            TotalPaid = DBNull.Value.Equals(reader["TotalPaid"]) ? (decimal?)null : (decimal)reader["TotalPaid"];

            // Đọc giá trị từ cột Change và kiểm tra null
            Change = DBNull.Value.Equals(reader["Change"]) ? (decimal?)null : (decimal)reader["Change"];

            Date = reader["Date"] != DBNull.Value ? (DateTime?)reader["Date"] : null;
            Payer = reader["Payer"].ToString();
            PaymentMethod = reader["PaymentMethod"].ToString();
            Note = reader["Note"].ToString();
        }

        public PaymentDetail() { }

        public PaymentDetail(PaymentDetail other)
        {
            PayDetailID = other.PayDetailID;
            PaymentID = other.PaymentID;
            TotalPayment = other.TotalPayment;
            TotalPaid = other.TotalPaid;
            Change = other.Change;
            Date = other.Date;
            Payer = other.Payer;
            PaymentMethod = other.PaymentMethod;
            Note = other.Note;
        }
    }
}
