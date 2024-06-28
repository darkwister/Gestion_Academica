

using Gestion_Academica.Data.Entities;
using System.Collections.Generic;

namespace Gestion_Academica.Data.Interfaces
{
    public interface ICarrerasRepository
    {
        void Agregar(Carrera carrera);
        void Actualizar(Carrera carrera);
        List<Carrera> TraerTodos();
        Carrera ObtenerPorId(int carreraId);
        void Remover(Carrera carrera);
    }
}
