using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicManagement.Admin.Class
{
    public class ReportTreat
    {
        public string ID { get; set; }
        public string Date { get; set; }
        public string PatientName { get; set; }
        public string Status { get; set; }

        public ReportTreat() { }
    }
}
