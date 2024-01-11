using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DentalClinicManagement.Admin.Class
{
    public class ReportTreat
    {
        public int? ConductedTreatmentID { get; set; }
        public DateTime? Date { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }

        public ReportTreat() { }
        public ReportTreat(SqlDataReader reader)
        {
            ConductedTreatmentID = (int)reader["ConductedTreatmentID"];
            Date = reader["Date"] != DBNull.Value ? (DateTime?)reader["Date"] : null;
            Name = reader["Name"].ToString();
            Status = reader["Status"].ToString();
        }

        // Copy constructor
        public ReportTreat(ReportTreat other)
        {
            ConductedTreatmentID = other.ConductedTreatmentID;
            Date = other.Date;
            Name = other.Name;
            Status = other.Status;

        }
    }
}