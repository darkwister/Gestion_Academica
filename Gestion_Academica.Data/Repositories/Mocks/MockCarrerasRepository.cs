

using Gestion_Academica.Data.Context;
using Gestion_Academica.Data.Entities;
using Gestion_Academica.Data.Exceptions;
using Gestion_Academica.Data.Interfaces;

namespace Gestion_Academica.Data.Repositories.Mocks
{
    public class MockCarrerasRepository : ICarrerasRepository
    {
        private readonly CarrerasContext context;

        public MockCarrerasRepository(CarrerasContext context)
        {
            this.context = context;
            this.CargarDatos();
        }

        public void Actualizar(Carrera carrera)
        {
            if (EsCarreraNull(carrera))
                throw new CarreraNullExceptions("La carrera no debe ser nulo.");

            Carrera carreraToUpdate = BuscarCarrera(carrera.Codigo);

            if (carreraToUpdate is null)
                throw new CarreraNotExistExceptions("La carrera no esta registrada.");

            ActualizarDatosCarrera(carreraToUpdate,carrera);

            this.context.Carreras.Update(carreraToUpdate);
            this.context.SaveChanges();

        }

        public void Agregar(Carrera carrera)
        {
            if (EsCarreraNull(carrera))
                throw new CarreraNullExceptions("La carrera no debe ser nulo.");


            Carrera carreraToAdd =  CrearNuevaCarrera(carrera);

            this.context.Carreras.Add(carreraToAdd);
            this.context.SaveChanges();
        }

        public Carrera ObtenerPorId(int carreraId)
        {

            return BuscarCarrera(carreraId);
        }

        public void Remover(Carrera carrera)
        {
            if(EsCarreraNull(carrera)) 
                throw new CarreraNullExceptions("La carrera no debe ser nulo.");
            

            Carrera carreraToRemove = BuscarCarrera(carrera.Codigo);

            if(carreraToRemove is null) 
                throw new CarreraNotExistExceptions("La carrera no esta registrada.");
            

            this.context.Carreras.Remove(carreraToRemove);
            this.context.SaveChanges();
        }

        public List<Carrera> TraerTodos()
        {
            return this.context.Carreras.ToList();
        }

        private void CargarDatos() 
        {
            Carrera carrera = new Carrera()
            {

                Codigo = 1,
                Nombre = "",
                Descripcion = "",
                Estado = 1,
                FechaCreacion = DateTime.Now

            };

            List<Carrera> carreras = new List<Carrera>() 
            {

                // 0 Incactivo 1 Activo

                new Carrera(){

                    Codigo = 2,
                    Nombre = "Software",
                    Descripcion = "Una carrera centrada en la tecnologia y el avance.",
                    Estado = 2,
                    FechaCreacion = DateTime.Now
                
                },
                new Carrera(){

                    Codigo = 3,
                    Nombre = "Multimedia",
                    Descripcion = "Centrados en lo visual, buscando el entendimiento y desarrollo de lo visual.",
                    Estado = 3,
                    FechaCreacion = DateTime.Now

                },
                new Carrera()
                {
                    Codigo = 4,
                    Nombre = "Mecatronica",
                    Descripcion = "Robots.",
                    Estado = 4,
                    FechaCreacion = DateTime.Now

                },
                new Carrera()
                {
                    Codigo = 5,
                    Nombre = "Inteligencia Artificial",
                    Descripcion = "En tiempos actuales, esta es probablemente una de las carreras del futuro.",
                    Estado = 5,
                    FechaCreacion = DateTime.Now

                }

            };

            this.context.Carreras.AddRange(carreras);
            this.context.SaveChanges();
        }

        private bool EsCarreraNull(Carrera carreras) 
        {
            bool result = false;

            if (carreras == null)
                return true;

            return result;
        }

        private Carrera BuscarCarrera(int codigo) 
        {
            return this.context.Carreras.Find(codigo);
        }

        private void ActualizarDatosCarrera(Carrera destino, Carrera origen)
        {
            destino.Codigo = origen.Codigo;
            destino.Nombre = origen.Nombre;
            destino.Descripcion = origen.Descripcion;
            destino.Estado = origen.Estado;
            destino.FechaCreacion = origen.FechaCreacion;
        }

        private Carrera CrearNuevaCarrera(Carrera carrera)
        {
            return new Carrera
            {
                Codigo = carrera.Codigo,
                Nombre = carrera.Nombre,
                Descripcion = carrera.Descripcion,
                Estado = carrera.Estado,
                FechaCreacion = carrera.FechaCreacion
            };
        }

    }
}
