﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.DAL.Tables
{
    public class ProgrammingLanguages :BaseEntity
    {
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(8)]
        public string KeyCode { get; set; }
        [StringLength(200)]
        public String BaseSolutionCode { get; set; }
    }
}
