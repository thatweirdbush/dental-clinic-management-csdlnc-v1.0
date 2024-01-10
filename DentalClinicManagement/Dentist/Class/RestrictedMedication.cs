using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicManagement.Dentist.Class
{
    public class RestrictedMedication
    {
        public int? PatientRecordID { get; set; }
        public int? MedicationID { get; set; }

        // Constructor để tạo đối tượng Payment từ SqlDataReader
        public RestrictedMedication(SqlDataReader reader)
        {
            PatientRecordID = (int)reader["PatientRecordID"];
            MedicationID = (int)reader["MedicationID"];
        }

        public RestrictedMedication() { }

        // Copy constructor
        public RestrictedMedication(RestrictedMedication other)
        {
            PatientRecordID = other.PatientRecordID;
            MedicationID = other.MedicationID;
        }
    }
}
