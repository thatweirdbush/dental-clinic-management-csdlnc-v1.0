using DentalClinicManagement.Dentist.Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DentalClinicManagement.Admin.Class
{
    public class ReportAppoint
    {
        public DateTime? Date { get; set; }
        public string? Shift { get; set; }
        public string? PatientName { get; set; }
        public string? Dentist { get; set; }
        public string? TroKham { get; set; }
        public int? Room { get; set; }
        public string? Status { get; set; }
        public ReportAppoint() { }

        public ReportAppoint(SqlDataReader reader)
        {
            Date = reader["TimeOfRequest"] != DBNull.Value ? (DateTime?)reader["TimeOfRequest"] : null;
            Shift = reader["Shift"].ToString();
            PatientName = reader["Name"].ToString();
            Dentist = reader["DentistName"].ToString();
            Room = (int)reader["Room"];
            Status = reader["Status"].ToString();
        }

        // Copy constructor
        public ReportAppoint(ReportAppoint other)
        {
            Date = other.Date;
            Shift = other.Shift;
            PatientName = other.PatientName;
            Dentist = other.Dentist;
            TroKham = other.TroKham;
            Room = other.Room;
            Status = other.Status;
        }
    }
}
