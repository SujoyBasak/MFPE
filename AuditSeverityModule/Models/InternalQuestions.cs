using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuditSeverityModule.Models
{
    public class InternalQuestions
    {
        [Display(Name ="Here is Your Question")]
        public bool Question { get; set; }
        [Display(Name = "Here is Your Question")]
        public bool Question1 { get; set; }
    }
}
