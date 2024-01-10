using DentalClinicManagement.Dentist.Class;
using DentalClinicManagement.Dentist;
using DentalClinicManagement.Employee.Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicManagement.Account.Class
{
    public class AccountClass
    {
        public int? AccountID { get; set; }
        public string? PhoneNo { get; set; }
        public string? Password { get; set; }
        public string? Status { get; set; }

        // Constructor để tạo đối tượng Customer từ SqlDataReader
        public AccountClass(SqlDataReader reader)
        {
            AccountID = (int)reader["AccountID"];
            PhoneNo = reader["PhoneNo"].ToString();
            Password = reader["Password"].ToString();
            Status = reader["Status"].ToString();
        }

        public AccountClass() { }

        public AccountClass(AccountClass other) {        
            PhoneNo = other.PhoneNo;
            Password = other.Password;
            Status = other.Status;
        }
    }
}
