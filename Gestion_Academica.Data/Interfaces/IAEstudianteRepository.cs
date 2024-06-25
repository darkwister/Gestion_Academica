
using Gestion_Academica.Data.Entities;
using System.Collections.Generic;

namespace Gestion_Academica.Data.Interfaces
{
    public interface IAEstudianteRepository
    {
        void Agregar(Estudiantes estudiante);
        void Actualizar(Estudiantes estudiante);
        List<Estudiantes> TraerTodos();
        Estudiantes ObtenerporId(int Id);
        void Remover(Estudiantes estudiante);
    }
}
