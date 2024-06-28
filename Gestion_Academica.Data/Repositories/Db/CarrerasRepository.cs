

using Gestion_Academica.Data.Context;
using Gestion_Academica.Data.Entities;
using Gestion_Academica.Data.Interfaces;
using System.Collections.Generic;

namespace Gestion_Academica.Data.Repositories.Db
{
    public class CarrerasRepository : ICarrerasRepository
    {
        private readonly CarrerasContext context;

        public CarrerasRepository(CarrerasContext context) 
        {
            this.context = context;
        }

        public void Actualizar(Carrera carrera)
        {
            throw new System.NotImplementedException();
        }

        public void Agregar(Carrera carrera)
        {
            throw new System.NotImplementedException();
        }

        public Carrera ObtenerPorId(int Id)
        {
            throw new System.NotImplementedException();
        }

        public void Remover(Carrera carrera)
        {
            throw new System.NotImplementedException();
        }

        public List<Carrera> TraerTodos()
        {
            throw new System.NotImplementedException();
        }
    }
}
