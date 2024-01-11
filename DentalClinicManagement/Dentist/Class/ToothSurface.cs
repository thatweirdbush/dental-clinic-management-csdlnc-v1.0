using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicManagement.Dentist.Class
{
    public class ToothSurface
    {
        public int? ToothSurfaceID { get; set; }
        public int? TeethID { get; set; }
        public int? SurfaceID { get; set; }

        // Constructor để tạo đối tượng Payment từ SqlDataReader
        public ToothSurface(SqlDataReader reader)
        {
            ToothSurfaceID = (int)reader["ToothSurfaceID"];
            TeethID = DBNull.Value.Equals(reader["TeethID"]) ? (int?)null : (int)reader["TeethID"];
            SurfaceID = DBNull.Value.Equals(reader["SurfaceID"]) ? (int?)null : (int)reader["SurfaceID"];

        }

        public ToothSurface() { }

        // Copy constructor
        public ToothSurface(ToothSurface other)
        {
            ToothSurfaceID = other.ToothSurfaceID;
            TeethID = other.TeethID;
            SurfaceID = other.SurfaceID;
        }
    }
}
