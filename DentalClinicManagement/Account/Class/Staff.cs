using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DentalClinicManagement.Account.Class
{
    public class Staff
    {
        public string? Name { get; set; }
        public string? PhoneNo { get; set; }
        public int? AccountID { get; set; }

        // Constructor để tạo đối tượng Customer từ SqlDataReader
        public Staff(SqlDataReader reader)
        {
            Name = reader["Name"].ToString();
            PhoneNo = reader["PhoneNo"].ToString();
            AccountID = DBNull.Value.Equals(reader["AccountID"]) ? (int?)null : (int)reader["AccountID"];
        }

        // Constructor mặc định
        public Staff() { }

        // Copy constructor
        public Staff(Staff other)
        {
            Name = other.Name;
            PhoneNo = other.PhoneNo;
            AccountID = other.AccountID;
        }
    }
}
