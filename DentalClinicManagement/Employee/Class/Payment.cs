using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicManagement.Employee.Class
{
    public class Payment
    {
        public int? PaymentID { get; set; }
        public int? PatientID { get; set; }
        public int? TreatmentID { get; set; }
        public int? ConductedTreatmentID { get; set; }
        public string? Status { get; set; }

        // Constructor để tạo đối tượng Payment từ SqlDataReader
        public Payment(SqlDataReader reader)
        {
            PaymentID = (int)reader["PaymentID"];
            PatientID = DBNull.Value.Equals(reader["PatientID"]) ? (int?)null : (int)reader["PatientID"];
            TreatmentID = DBNull.Value.Equals(reader["TreatmentID"]) ? (int?)null : (int)reader["TreatmentID"];
            ConductedTreatmentID = DBNull.Value.Equals(reader["ConductedTreatmentID"]) ? (int?)null : (int)reader["ConductedTreatmentID"];
            Status = reader["Status"].ToString();
        }

        public Payment() { }

        public Payment(Payment other)
        {
            PaymentID = other.PaymentID;
            PatientID = other.PatientID;
            TreatmentID = other.TreatmentID;
            ConductedTreatmentID = other.ConductedTreatmentID;
            Status = other.Status;
        }
    }
}
