using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortal.Models
{
    public class AuditResponse
    {
        [Display(Name ="Audit Id: ")]
        public int AuditId { get; set; }
        [Display(Name = "Project Exexution Status: ")]
        public string ProjectExexutionStatus { get; set; }
        [Display(Name = "Remedial Action Duraion: ")]
        public string RemedialActionDuration { get; set; }

    }
}
