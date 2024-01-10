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
    public class Patient
    {
        public int? PatientID { get; set; }
        public string? Name { get; set; }
        public string? PhoneNo { get; set; }

        // Constructor để tạo đối tượng Payment từ SqlDataReader
        public Patient(SqlDataReader reader)
        {
            PatientID = (int)reader["PatientID"];
            Name = reader["Name"].ToString();
            PhoneNo = reader["PhoneNo"].ToString();
        }

        public Patient() { }

        // Copy constructor
        public Patient(Patient other)
        {
            PatientID = other.PatientID;
            Name = other.Name;
            PhoneNo = other.PhoneNo;
        }
    }
}
