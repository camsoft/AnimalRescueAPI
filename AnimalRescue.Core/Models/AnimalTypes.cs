using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRescue.Core.Models
{
    public class AnimalTypes
    {
        [Key]
        public long Id { get; set; }
        [MaxLength(200)]
        public string AnimalType { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
