using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRescue.Core.Models
{
    public class Animals
    {
        [Key]
        public long Id { get; set; }
        public long AnimalTypeId { get; set; }
        public long AnimalProfileId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
