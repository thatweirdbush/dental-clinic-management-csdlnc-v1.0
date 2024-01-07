using DentalClinicManagement.Dentist;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DentalClinicManagement.Employee.Class
{
    public class AppointmentRequest
    {
        public int? AppointmentID { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }
        public int? Room { get; set; }
        public DateTime? TimeOfRequest { get; set; }
        public int? PatientID { get; set; }
        public int? ScheduleID { get; set; }
        public int? DentistID { get; set; }

        // Constructor để tạo đối tượng Customer từ SqlDataReader
        public AppointmentRequest(SqlDataReader reader)
        {
            AppointmentID = (int)reader["AppointmentID"];
            Note = reader["Note"].ToString();
            Status = reader["Status"].ToString();
            Room = DBNull.Value.Equals(reader["Room"]) ? (int?)null : (int)reader["Room"];
            TimeOfRequest = reader["TimeOfRequest"] != DBNull.Value ? (DateTime?)reader["TimeOfRequest"] : null;
            PatientID = DBNull.Value.Equals(reader["PatientID"]) ? (int?)null : (int)reader["PatientID"];
            ScheduleID = DBNull.Value.Equals(reader["ScheduleID"]) ? (int?)null : (int)reader["ScheduleID"];
            DentistID = DBNull.Value.Equals(reader["DentistID"]) ? (int?)null : (int)reader["DentistID"];
        }

        public AppointmentRequest() { }
    }
}
