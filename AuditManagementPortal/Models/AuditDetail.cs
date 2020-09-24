using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortal.Models
{
    public class AuditDetail
    {
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public Questions questions { get; set; }
    }
}
