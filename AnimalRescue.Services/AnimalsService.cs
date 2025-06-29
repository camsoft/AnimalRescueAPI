using AnimalRescue.Services.Interfaces;
using AnimalRescue.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalRescue.Core.Dtos;

namespace AnimalRescue.Services
{
    public class AnimalsService : IAnimalsService
    {
        private readonly IAnimalsRepository animalsRepository;
        public AnimalsService(IAnimalsRepository _animalRepository)
        {
            animalsRepository = _animalRepository;
        }

        public async Task<IEnumerable<AnimalsDto>> GetAnimals()
        {
            return await animalsRepository.RetrieveAnimals();
        }
    }
}
