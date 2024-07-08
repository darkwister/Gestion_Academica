using Moq;
using Gestion_Academica.Data.Context;
using Gestion_Academica.Data.Repositories.Mocks;
using Gestion_Academica.Data.Entities;
using Gestion_Academica.Data.Exceptions;

namespace Gestion_Academica.Test
{
    public class UnitTestCarrerasRepository
    {
        [Fact]
        public void Actualizar_CarreraIsNull()
        {
            // Arrange //

            var context = new CarrerasContext();
            var repository = new MockCarrerasRepository(context);

            // Act //

            Carrera carrera = null;

            // Assert //

            Assert.Throws<CarreraNullExceptions>(() => repository.Actualizar(carrera));

        }

        [Fact]
        public void Actualizar_CarreraExist()
        {
            // Arrange //

            var context = new CarrerasContext();
            var repository = new MockCarrerasRepository(context);

            // Act //

            Carrera carrera = new Carrera()
            {
                Codigo = 11
            };

            // Assert //

            Assert.Throws<CarreraNotExistExceptions>(() => repository.Actualizar(carrera));

        }

        [Fact]
        public void Agregar_CarreraIsNull()
        {
            // Arrange //

            var context = new CarrerasContext();
            var repository = new MockCarrerasRepository(context);

            // Act //

            Carrera carrera = null;

            // Assert //

            Assert.Throws<CarreraNullExceptions>(() => repository.Agregar(carrera));

        }

        [Fact]
        public void Agregar_CarreraDuplicate()
        {
            // Arrange //

            var context = new CarrerasContext();
            var repository = new MockCarrerasRepository(context);

            // Act //

            Carrera carrera = new Carrera()
            {
                Codigo = 2,
                Nombre = "Software",
                Descripcion = "Una carrera centrada en la tecnologia y el avance.",
                Estado = 2,
                FechaCreacion = DateTime.Now
            };

            // Assert //

            Assert.Throws<CarreraDuplicadoExceptions>(() => repository.Agregar(carrera));

        }

        [Fact]
        public void Remover_CarreraIsNull()
        {
            // Arrange //

            var context = new CarrerasContext();
            var repository = new MockCarrerasRepository(context);

            // Act //

            Carrera carrera = null;

            // Assert //

            Assert.Throws<CarreraNullExceptions>(() => repository.Remover(carrera));

        }

        [Fact]
        public void Remover_CarreraExist()
        {
            // Arrange //

            var context = new CarrerasContext();
            var repository = new MockCarrerasRepository(context);

            // Act //

            Carrera carrera = new Carrera()
            {
                Codigo = 14
            };

            // Assert //

            Assert.Throws<CarreraNotExistExceptions>(() => repository.Remover(carrera));

        }
    }
}
