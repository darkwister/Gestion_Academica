using Gestion_Academica.Data.Context;
using Gestion_Academica.Data.Entities;
using Gestion_Academica.Data.Exceptions;
using Gestion_Academica.Data.Interfaces;

namespace Gestion_Academica.Data.Repositories.Mocks
{
    public class MockEstudianteRepository : IAEstudianteRepository
    {
        private readonly EstudiantesContext context;
        public MockEstudianteRepository(EstudiantesContext context)
        {
            this.context = context;
            this.CargarDatos();
        }
        public void Actualizar(Estudiantes estudiante)
        {
            if (EsEstudianteNull(estudiante))
                throw new EstudiantesNullException("El objeto estudiante no debe ser nulo.");

            Estudiantes estudianteToUpdate = this.context.Estudiantes.Find(estudiante.Id);

            if (estudianteToUpdate is null)
                throw new EstudianteNotExistsException("El estudiante no se encuentra registrado.");

            estudianteToUpdate.Nombre = estudiante.Nombre;
            estudianteToUpdate.Apellido = estudiante.Apellido;
            estudianteToUpdate.Matricula = estudiante.Matricula;
            estudianteToUpdate.Fecha_nacimiento = estudiante.Fecha_nacimiento;
            estudianteToUpdate.Sexo = estudiante.Sexo;
            estudianteToUpdate.Becado = estudiante.Becado;

            this.context.Update(estudianteToUpdate);
            this.context.SaveChanges();
        }

        public void Agregar(Estudiantes estudiante)
        {
            if (EsEstudianteNull(estudiante))
                throw new EstudiantesNullException("El objeto estudiante no debe ser nulo.");

            if (ExisteEstudiante(estudiante.Id))
                throw new EstudianteDuplicadoExists($"El estudiante {estudiante.Id} ya existe en el registro.");

            Estudiantes estudianteToAdd = new Estudiantes()
            {
                Id = estudiante.Id,
                Nombre = estudiante.Nombre,
                Apellido = estudiante.Apellido,
                Matricula = estudiante.Matricula,
                Fecha_nacimiento = estudiante.Fecha_nacimiento,
                Cedula = estudiante.Cedula,
                Sexo = estudiante.Sexo,
                Becado = estudiante.Becado
            };

            this.context.Estudiantes.Add(estudianteToAdd);
            this.context.SaveChanges();
        }

        public Estudiantes ObtenerporId(int Id)
        {
            return this.context.Estudiantes.Find(Id);
        }

        public void Remover(Estudiantes estudiante)
        {
            if (EsEstudianteNull(estudiante))
                throw new EstudiantesNullException("El objeto estudiante no debe ser nulo.");

            Estudiantes estudianteToRemove = this.context.Estudiantes.Find(estudiante.Id);

            if (estudianteToRemove is null)
                throw new EstudianteNotExistsException("El estudiante no existe en la BD.");

            this.context.Estudiantes.Remove(estudianteToRemove);
            this.context.SaveChanges();
        }

        public List<Estudiantes> TraerTodos()
        {
            return this.context.Estudiantes.ToList();
        }
        private void CargarDatos()
        {
            if (!this.context.Estudiantes.Any()){
                List<Estudiantes> estudiantes = new List<Estudiantes>()
            {
                new Estudiantes
                {
                    Id = 1,
                    Nombre="Omar",
                    Apellido="Casal",
                    Matricula="3030-2023",
                    Fecha_nacimiento = new DateTime(2001,09,02),
                    Cedula="202-1024234-2",
                    Sexo='M',
                    Becado='N'
                },
                new Estudiantes
                {
                    Id = 2,
                    Nombre="Marcela",
                    Apellido="Meyer Baranovskaia",
                    Matricula="2029-3020",
                    Fecha_nacimiento = new DateTime(2004,11,04),
                    Cedula="503-4050234-1",
                    Sexo='F',
                    Becado='S'
                },
                new Estudiantes
                {
                    Id = 3,
                    Nombre="Pedro José",
                    Apellido="Ravelo Pérez",
                    Matricula="2025-1122",
                    Fecha_nacimiento = new DateTime(2006,01,31),
                    Cedula="209-1350401-9",
                    Sexo='M',
                    Becado='S'
                }
            };

                this.context.Estudiantes.AddRange(estudiantes);
                this.context.SaveChanges();
            }
        }

        private bool EsEstudianteNull(Estudiantes estudiante)
        {
            bool result = false;
            if (estudiante == null)
                return true;
            return result;
        }

        private bool ExisteEstudiante(int Id)
        {
            return this.context.Estudiantes.Any(cd => cd.Id == Id);
        }
    }
}

