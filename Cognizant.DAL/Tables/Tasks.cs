using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.DAL.Tables
{
    public class Tasks : BaseEntity
    {
        [StringLength(100)]
        public String Name { get; set; }
        public String Description { get; set; }
        [StringLength(100)]
        public String InputParameter { get; set; }
        public String ExpectedOutPut { get; set; }
    }
}
