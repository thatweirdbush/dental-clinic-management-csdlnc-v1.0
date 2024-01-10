using DentalClinicManagement.Account;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicManagement.Dentist.Class
{
    public class Treatment
    {
        public int? TreatmentID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Fee { get; set; }

        // Constructor để tạo đối tượng Payment từ SqlDataReader
        public Treatment(SqlDataReader reader)
        {
            TreatmentID = (int)reader["TreatmentID"];
            Name = reader["Name"].ToString();
            Description = reader["Description"].ToString();
            Fee = DBNull.Value.Equals(reader["Fee"]) ? (decimal?)null : (decimal)reader["Fee"];

        }

        public Treatment() { }

        // Copy constructor
        public Treatment(Treatment other)
        {
            TreatmentID = other.TreatmentID;
            Name = other.Name;
            Description = other.Description;
            Fee = other.Fee;
        }
    }
}
