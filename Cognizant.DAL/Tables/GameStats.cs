using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.DAL.Tables
{
    public class GameStats : BaseEntity
    {
        [StringLength(100)]
        public string PlayerName { get; set; }
        public bool IsSuccess { get; set; }

        [ForeignKey("Tasks")]
        public int TaskId { get; set; }
        public Tasks Task { get; set; }
    }
}
