using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace DentalClinicManagement.Dentist.Class
{
    public class TreatmentChild
    {
        public int? TreatmentID { get; set; }
        public int? TreatmentChildID { get; set; }

        // Constructor để tạo đối tượng Payment từ SqlDataReader
        public TreatmentChild(SqlDataReader reader)
        {
            TreatmentID = (int)reader["TreatmentID"];
            TreatmentChildID = (int)reader["TreatmentChildID"];

        }

        public TreatmentChild() { }

        // Copy constructor
        public TreatmentChild(TreatmentChild other)
        {
            TreatmentID = other.TreatmentID;
            TreatmentChildID = other.TreatmentChildID;
        }
    }
}
