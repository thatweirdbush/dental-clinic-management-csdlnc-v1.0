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
    public class CustomerClass
    {
        public string Name { get; set; }
        public DateTime DayOfBirth { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public bool Sex { get; set; }

        // Constructor để tạo đối tượng Customer từ SqlDataReader
        public CustomerClass(SqlDataReader reader)
        {
            Name = reader["Name"].ToString();
            DayOfBirth = (DateTime)reader["DateOfBirth"];
            Address = reader["Address"].ToString();
            PhoneNo = reader["PhoneNo"].ToString();
            //Email = reader["Email"].ToString();
            //Sex = (bool)reader["Gender"];
        }

        // Constructor để tạo đối tượng Customer từ dữ liệu trực tiếp
        public CustomerClass(string name, DateTime dayOfBirth, string address, string phoneNo, string email, bool sex)
        {
            Name = name;
            DayOfBirth = dayOfBirth;
            Address = address;
            PhoneNo = phoneNo;
            Email = email;
            Sex = sex;
        }

        // Constructor mặc định
        public CustomerClass() { }

        // Copy constructor
        public CustomerClass(CustomerClass other)
        {
            Name = other.Name;
            DayOfBirth = other.DayOfBirth;
            Address = other.Address;
            PhoneNo = other.PhoneNo;
            Email = other.Email;
            Sex = other.Sex;
        }
    }
}
