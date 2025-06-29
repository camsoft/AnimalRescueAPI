using AnimalRescue.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRescue.Services.Interfaces
{
    public interface IAnimalsService
    {
        Task<IEnumerable<AnimalsDto>> GetAnimals();
    }
}
