using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicManagement.Dentist.Class
{
    public class DentistSchedule
    {
        public int? DentistID { get; set; }
        public string? Shift { get; set; }
        public int? Day { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public string? Status { get; set; }

        public DentistSchedule(SqlDataReader reader)
        {
            DentistID = (int)reader["DentistID"];
            Shift = reader["Shift"].ToString();
            Day = (int)reader["Day"];
            Month = (int)reader["Month"];
            Year = (int)reader["Year"];
            Status = reader["Status"].ToString();
        }

        public DentistSchedule() { }

        public DentistSchedule(DentistSchedule other)
        {
            DentistID = other.DentistID;
            Shift = other.Shift;
            Day = other.Day;
            Month = other.Month;
            Year = other.Year;
            Status = other.Status;
        }



    }
}
