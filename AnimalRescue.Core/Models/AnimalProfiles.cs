using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRescue.Core.Models
{
    public class AnimalProfiles
    {
        [Key]
        public long Id { get; set; }
        [MaxLength(250)]
        public string FirstName { get; set; }
        [MaxLength(250)]
        public string LastName { get; set; }
        public DateTime? IntakeDate { get; set; }
        [MaxLength(10)]
        public string Gender { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
