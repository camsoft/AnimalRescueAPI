using AnimalRescue.Core.Dtos;
using AnimalRescue.Data;
using AnimalRescue.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AnimalRescue.Repositories
{
    public class AnimalsRepository : IAnimalsRepository
    {
        private readonly AnimalRescueDbContext animalRescueDbContext;

        public AnimalsRepository(AnimalRescueDbContext _animalRescueDbContext)
        {
            this.animalRescueDbContext = _animalRescueDbContext;
        }

        public async Task<IEnumerable<AnimalsDto>> RetrieveAnimals()
        {
            try
            {
                var results = await (from ani in animalRescueDbContext.animals
                                     join anp in animalRescueDbContext.animalProfiles on ani.AnimalProfileId equals anp.Id
                                     join ant in animalRescueDbContext.animalTypes on ani.AnimalProfileId equals ant.Id
                                     select new AnimalsDto
                                     {
                                         Id = ani.AnimalProfileId,
                                         LastName = anp.LastName,
                                         FirstName = anp.FirstName,
                                         IntakeDate = anp.IntakeDate,
                                         Gender = anp.Gender
                                     }
                                 )
                                 .AsNoTracking()
                                 .ToListAsync()
                                 .ConfigureAwait(false);

                return results;

            }
            catch (Exception ex)
            {
                return new List<AnimalsDto>();
            }
            
        }
    }
}
