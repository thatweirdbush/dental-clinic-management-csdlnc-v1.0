using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicManagement.Admin.Class
{
    public class ReportAppoint
    {
        public string Date { get; set; }
        public string Shift { get; set; }
        public string PatientName { get; set; }
        public string Dentist { get; set; }
        public string TroKham { get; set; }
        public string Room { get; set; }
        public string Status { get; set; }

        public ReportAppoint() { }
    }
}
