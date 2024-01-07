using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicManagement.Employee.Class
{
    public class Schedule
    {
        public int? ScheduleID { get; set; }
        public int? DentistID { get; set; }
        public string? Shift { get; set; }
        public int? Day { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public string? Status { get; set; }

        // Constructor để tạo đối tượng Customer từ SqlDataReader
        public Schedule(SqlDataReader reader)
        {
            ScheduleID = (int)reader["ScheduleID"];
            DentistID = DBNull.Value.Equals(reader["DentistID"]) ? (int?)null : (int)reader["DentistID"];
            Shift = reader["Shift"].ToString();
            Day = DBNull.Value.Equals(reader["Day"]) ? (int?)null : (int)reader["Day"];
            Month = DBNull.Value.Equals(reader["Month"]) ? (int?)null : (int)reader["Month"];
            Year = DBNull.Value.Equals(reader["Year"]) ? (int?)null : (int)reader["Year"];
            Status = reader["Status"].ToString();
        }

        public Schedule() { }
    }
}
