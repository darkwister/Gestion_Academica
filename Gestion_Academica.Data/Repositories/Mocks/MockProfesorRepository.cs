using Gestion_Academica.Data.Context;
using Gestion_Academica.Data.Entities;
using Gestion_Academica.Data.Exceptions;
using Gestion_Academica.Data.Interfaces;


namespace Gestion_Academica.Data.Repositories.Mocks
{
    public class MockProfesorRepository : IProfesorRepository
    {
        private readonly ProfesorContext context;
        public MockProfesorRepository(ProfesorContext context)
        {
            this.context = context;
            this.CargarDatos();
        }
        public void Actualizar(Profesor profesor)
        {
            if (EsProfesorNull(profesor))
                throw new ProfesorNullException("El profesor no debe de ser nulo");

            Profesor profesorToUpdate = this.context.Profesores.Find(profesor.Id);

            if (profesorToUpdate == null)
                throw new ProfesorNotExistException("El profesor no se encuentra registrado");

            profesorToUpdate.Id = profesor.Id;
            profesorToUpdate.Nombre = profesor.Nombre;
            profesorToUpdate.Apellido = profesor.Apellido;
            profesorToUpdate.Cedula = profesor.Cedula;
            profesorToUpdate.fechaNacimiento = profesor.fechaNacimiento;
            profesorToUpdate.Sexo = profesor.Sexo;

            this.context.Profesores.Update(profesorToUpdate);
            this.context.SaveChanges();
        }
        public void Agregar(Profesor profesor)
        {
            if (EsProfesorNull(profesor))
                throw new ProfesorNullException("El profesor no debe de ser nulo");

            if (ExisteProfesor(profesor.Id))
            {
                throw new ProfesorDuplicadoException($"El profesor {profesor.Nombre} ya esta en los registros");
            }

            Profesor profesorToAdd = new Profesor()
            {
                Id = profesor.Id,
                Nombre = profesor.Nombre,
                Apellido = profesor.Apellido,
                Cedula = profesor.Cedula,
                fechaNacimiento = profesor.fechaNacimiento,
                Sexo = profesor.Sexo,
            };
            this.context.Add(profesorToAdd);
            this.context.SaveChanges();
        }
        public Profesor ObtenerPorID(int Id)
        {
            return this.context.Profesores.Find(Id);
        }
        public void Remover(Profesor profesor)
        {
            if (EsProfesorNull(profesor))
                throw new ProfesorNullException("El profesor no debe de ser nulo");

            Profesor profesorToRemove = this.context.Profesores.Find(profesor.Id);

            if (profesorToRemove is null)
                throw new ProfesorNotExistException("El profesor no se encuentra registrado");

            this.context.Profesores.Remove(profesorToRemove);
            this.context.SaveChanges();
        }
        public List<Profesor> TraerTodos()
        {
            return this.context.Profesores.ToList();
        }
        private void CargarDatos()
        {
            if (!this.context.Profesores.Any())
            {
                List<Profesor> Profesores = new List<Profesor>()
                {
                    new Profesor()
                    {
                        Id = 1,
                        Nombre = "Juan",
                        Apellido = "Perez",
                        fechaNacimiento = new DateTime(1991,12,13),
                        Cedula = 1234657891,
                        Sexo = 'M'
                    },
                    new Profesor()
                    {
                        Id = 2,
                        Nombre = "Maria Jose",
                        Apellido = "Gutierrez",
                        fechaNacimiento = new DateTime(1999,8,13),
                        Cedula = 1234657981,
                        Sexo = 'F'
                    },
                    new Profesor()
                    {
                        Id = 3,
                        Nombre = "Carlos",
                        Apellido = "Lopez",
                        fechaNacimiento = DateTime.Now,
                        Cedula = 1524657891,
                        Sexo = 'M'
                    },
                    new Profesor()
                    {
                        Id = 4,
                        Nombre = "Mariel",
                        Apellido = "Peralta",
                        fechaNacimiento = DateTime.Now,
                        Cedula = 1987654321,
                        Sexo = 'F'
                    }
                };
           
            this.context.Profesores.AddRange(Profesores);
            this.context.SaveChanges();
            }
        }
        private bool EsProfesorNull(Profesor profesor)
        {
            bool result = false;
            if (profesor == null)
                result = true;
            return result;
        }
        private bool ExisteProfesor(int ProfesorId)
        {
            return this.context.Profesores.Any(cd => cd.Id == ProfesorId);
        }
    }
}
