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
        public int? PatientID { get; set; }
        public int? TreatmentID { get; set; }
        public int? ToothSurfaceID { get; set; }
        public int? DentistID { get; set; }
        public DateTime? Date { get; set; }
        public string? Description { get; set; }
        public string? Assistant { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }


        // Constructor để tạo đối tượng Payment từ SqlDataReader
        public ReportTreat(SqlDataReader reader)
        {
            ConductedTreatmentID = (int)reader["ConductedTreatmentID"];
            PatientID = DBNull.Value.Equals(reader["PatientID"]) ? (int?)null : (int)reader["PatientID"];
            TreatmentID = DBNull.Value.Equals(reader["TreatmentID"]) ? (int?)null : (int)reader["TreatmentID"];
            ToothSurfaceID = DBNull.Value.Equals(reader["ToothSurfaceID"]) ? (int?)null : (int)reader["ToothSurfaceID"];
            DentistID = DBNull.Value.Equals(reader["DentistID"]) ? (int?)null : (int)reader["DentistID"];
            Date = reader["Date"] != DBNull.Value ? (DateTime?)reader["Date"] : null;
            Description = reader["Description"].ToString();
            Assistant = reader["Assistant"].ToString();
            Note = reader["Note"].ToString();
            Status = reader["Status"].ToString();
        }

        public ReportTreat() { }

        public ReportTreat(ReportTreat other)
        {
            ConductedTreatmentID = other.ConductedTreatmentID;
            PatientID = other.PatientID;
            TreatmentID = other.TreatmentID;
            ToothSurfaceID = other.ToothSurfaceID;
            DentistID = other.DentistID;
            Date = other.Date;
            Description = other.Description;
            Assistant = other.Assistant;
            Note = other.Note;
            Status = other.Status;
        }
    }
}