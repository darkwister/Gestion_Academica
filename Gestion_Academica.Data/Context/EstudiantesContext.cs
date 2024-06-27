using Microsoft.EntityFrameworkCore;
namespace Gestion_Academica.Data.Context
{
    public class EstudiantesContext : DbContext
    {
        public EstudiantesContext(DbContextOptions<EstudiantesContext> options) : base(options)
        {

        }

        public DbSet<Entities.Estudiantes> Estudiantes { get; set; }
    }
}

