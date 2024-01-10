using DentalClinicManagement.Account;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicManagement.Admin.Class
{
    public class Victim
    {
        public int? PatientID { get; set; }
        public string? Name { get; set; }
        public string? PhoneNo { get; set; }

        // Constructor để tạo đối tượng Payment từ SqlDataReader
        public Victim(SqlDataReader reader)
        {
            PatientID = (int)reader["PatientID"];
            Name = reader["Name"].ToString();
            PhoneNo = reader["PhoneNo"].ToString();
        }

        public Victim() { }

        // Copy constructor
        public Victim(Victim other)
        {
            PatientID = other.PatientID;
            Name = other.Name;
            PhoneNo = other.PhoneNo;
        }
    }
}