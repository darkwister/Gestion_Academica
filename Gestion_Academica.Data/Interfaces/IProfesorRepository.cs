using Gestion_Academica.Data.Entities;

namespace Gestion_Academica.Data.Interfaces
{
    public interface IProfesorRepository
    {
        void Agregar(Profesor profesor);
        void Actualizar(Profesor profesor);
        void Remover(Profesor profesor);
        List<Profesor> TraerTodos();
        Profesor ObtenerPorID(int Id);
    }
}
