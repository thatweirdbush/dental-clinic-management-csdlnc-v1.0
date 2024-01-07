using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicManagement.Dentist.Class
{
    public class MedicationList
    {
        public int? MedicationID { get; set; }
        public string? Name { get; set; }

        // Constructor để tạo đối tượng Payment từ SqlDataReader
        public MedicationList(SqlDataReader reader)
        {
            MedicationID = (int)reader["MedicationID"];
            Name = reader["Name"].ToString();
        }

        public MedicationList() { }

        // Copy constructor
        public MedicationList(MedicationList other)
        {
            MedicationID = other.MedicationID;
            Name = other.Name;

        }
    }
}
