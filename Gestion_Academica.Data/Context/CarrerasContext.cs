

using Gestion_Academica.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Academica.Data.Context
{
    public class CarrerasContext : DbContext
    {

        public CarrerasContext(DbContextOptions<CarrerasContext> options) 
        { 

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("GestionAcademica");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Carrera> Carreras { get; set; }

    }
}
