using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicManagement.Dentist.Class
{
    public class DetailedTreatmentTooth
    {
        public int? DetailedToothID { get; set; }
        public int? PatientID { get; set; }
        public int? TreatmentID { get; set; }
        public int? ConductedTreatmentID { get; set; }
        public int? ToothSurfaceID { get; set; }


        // Constructor để tạo đối tượng Payment từ SqlDataReader
        public DetailedTreatmentTooth(SqlDataReader reader)
        {
            DetailedToothID = (int)reader["DetailedToothID"];
            PatientID = DBNull.Value.Equals(reader["PatientID"]) ? (int?)null : (int)reader["PatientID"];
            TreatmentID = DBNull.Value.Equals(reader["TreatmentID"]) ? (int?)null : (int)reader["TreatmentID"];
            ConductedTreatmentID = DBNull.Value.Equals(reader["ConductedTreatmentID"]) ? (int?)null : (int)reader["ConductedTreatmentID"];
            ToothSurfaceID = DBNull.Value.Equals(reader["ToothSurfaceID"]) ? (int?)null : (int)reader["ToothSurfaceID"];

        }

        public DetailedTreatmentTooth() { }

        // Copy constructor
        public DetailedTreatmentTooth(DetailedTreatmentTooth other)
        {
            DetailedToothID = other.DetailedToothID;
            PatientID = other.PatientID;
            TreatmentID = other.TreatmentID;
            ConductedTreatmentID = other.ConductedTreatmentID;
            ToothSurfaceID = other.ToothSurfaceID;
        }
    }
}
