using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRescue.Core.Dtos
{
    public class AnimalsDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public String LastName { get; set; }
        public string Gender { get; set; }
        public string AnimalType { get; set; }
        public DateTime? IntakeDate { get; set; }
    }
}
