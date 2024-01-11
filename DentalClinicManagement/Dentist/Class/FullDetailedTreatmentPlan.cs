using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicManagement.Dentist.Class
{
    public class FullDetailedTreatmentPlan
    {
        public int? DetailedTreatmentPlanID { get; set; }
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
        public int? TeethID { get; set; }
        public int? SurfaceID { get; set; }


        // Constructor để tạo đối tượng Payment từ SqlDataReader
        public FullDetailedTreatmentPlan(SqlDataReader reader)
        {
            DetailedTreatmentPlanID = (int)reader["DetailedTreatmentPlanID"];
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
            TeethID = DBNull.Value.Equals(reader["TeethID"]) ? (int?)null : (int)reader["TeethID"];
            SurfaceID = DBNull.Value.Equals(reader["SurfaceID"]) ? (int?)null : (int)reader["SurfaceID"];
        }

        public FullDetailedTreatmentPlan() { }

        public FullDetailedTreatmentPlan(DetailedTreatmentPlan other)
        {
            DetailedTreatmentPlanID = other.DetailedTreatmentPlanID;
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
            //TeethID = other.TeethID;
            //SurfaceID = other.SurfaceID;
        }
    }
}
