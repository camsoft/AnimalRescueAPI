using AnimalRescue.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRescue.Repositories.Interfaces
{
    public interface IAnimalsRepository
    {
        Task<IEnumerable<AnimalsDto>> RetrieveAnimals();
    }
}
