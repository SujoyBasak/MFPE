﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortal.Models
{
    public class InternalQuestions
    {
        [Display(Name ="Here is Your First Question ?")]
        public bool Question1 { get; set; }
        public bool Question2 { get; set; }
        public bool Question3{ get; set; }
        public bool Question4 { get; set; }
        public bool Question5 { get; set; }

    }
}
