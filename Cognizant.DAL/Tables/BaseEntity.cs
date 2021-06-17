using System;
using System.ComponentModel.DataAnnotations;
namespace Cognizant.DAL.Tables
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
