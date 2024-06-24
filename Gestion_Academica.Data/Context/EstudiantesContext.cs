using Microsoft.EntityFrameworkCore;
namespace Gestion_Academica.Data.Context
{
    public class EstudiantesContext: DbContext
    {
        public EstudiantesContext(DbContextOptions<EstudiantesContext> options): base(options) 
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Students");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Entities.Estudiantes> Estudiantes { get; set; }
    }
}
