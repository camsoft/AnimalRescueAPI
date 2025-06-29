using AnimalRescue.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalRescue.Data
{
    public class AnimalRescueDbContext : DbContext
    {
        public AnimalRescueDbContext(DbContextOptions options) : base(options)
        {

        }

        protected AnimalRescueDbContext()
        {
        }

        public DbSet<Animals> animals { get; set; }
        public DbSet<AnimalTypes> animalTypes { get; set; }
        public DbSet<AnimalProfiles> animalProfiles { get; set; }
    }
}
