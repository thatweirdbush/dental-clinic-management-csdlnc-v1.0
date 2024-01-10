using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicManagement.Dentist.Class
{
    public class PatientRecord
    {
        public int? PatientRecordID { get; set; }
        public int? PatientID { get; set; }
        public int? Age { get; set; }
        public string? Name { get; set; }
        public string? Sex { get; set; }
        public string? GeneralInformation { get; set; }
        public string? AllergyStatus { get; set; }
        public decimal? TotalTreatmentFee { get; set; }
        public decimal? TotalPaid { get; set; }

        // Constructor để tạo đối tượng Payment từ SqlDataReader
        public PatientRecord(SqlDataReader reader)
        {
            PatientRecordID = (int)reader["PatientRecordID"];
            PatientID = DBNull.Value.Equals(reader["PatientID"]) ? (int?)null : (int)reader["PatientID"];
            Age = DBNull.Value.Equals(reader["Age"]) ? (int?)null : (int)reader["Age"];
            Name = reader["Name"].ToString();
            Sex = reader["Sex"].ToString();
            GeneralInformation = reader["GeneralInformation"].ToString();
            AllergyStatus = reader["AllergyStatus"].ToString();
            TotalTreatmentFee = DBNull.Value.Equals(reader["TotalTreatmentFee"]) ? (decimal?)null : (decimal)reader["TotalTreatmentFee"];
            TotalPaid = DBNull.Value.Equals(reader["TotalPaid"]) ? (decimal?)null : (decimal)reader["TotalPaid"];
        }

        public PatientRecord() { }

        // Copy constructor
        public PatientRecord(PatientRecord other)
        {
            PatientRecordID = other.PatientRecordID;
            PatientID = other.PatientID;
            Age = other.Age;
            Name = other.Name;
            Sex = other.Sex;
            GeneralInformation = other.GeneralInformation;
            AllergyStatus = other.AllergyStatus;
            TotalTreatmentFee = other.TotalTreatmentFee;
            TotalPaid = other.TotalPaid;
        }
    }
}
