using Microsoft.EntityFrameworkCore;
using Moq;
using Gestion_Academica.Data.Context;
using Gestion_Academica.Data.Exceptions;
using Gestion_Academica.Data.Entities;
using Gestion_Academica.Data.Repositories.Mocks;

namespace Gestion_Academica.Test
{
    public class UnitTestEstudianteRepos
    {
        private DbContextOptions<EstudiantesContext> GetInMemoryDatabaseOptions()
        {
            // Configura las opciones para usar una base de datos en memoria
            return new DbContextOptionsBuilder<EstudiantesContext>()
                .UseInMemoryDatabase(databaseName: "GestionAcademica")
                .Options;
        }

        //Prueba 1
        [Fact]
        public void Agregar_EsEstudianteNull()
        {
            // Arrange
            var options = GetInMemoryDatabaseOptions();
            using (var context = new EstudiantesContext(options))
            {
                var mockRepository = new Mock<MockEstudianteRepository>(context);

                // Act
                Estudiantes estudiante = null;

                // Assert
                Assert.Throws<EstudiantesNullException>(() => mockRepository.Object.Agregar(estudiante));
            }
        }

        //Prueba 2
        [Fact]
        public void Agregar_ExisteEstudiante()
        {
            // Arrange
            var options = GetInMemoryDatabaseOptions();
            using (var context = new EstudiantesContext(options))
            {
                var mockRepository = new Mock<MockEstudianteRepository>(context);

                // Act
                Estudiantes estudiante = new Estudiantes()
                {
                    Id = 1,
                };

                // Assert
                Assert.Throws<EstudianteDuplicadoExists>(() => mockRepository.Object.Agregar(estudiante));
            }
        }

        //Prueba 3
        [Fact]
        public void Actualizar_EsEstudianteNull()
        {
            // Arrange
            var options = GetInMemoryDatabaseOptions();
            using (var context = new EstudiantesContext(options))
            {
                var mockRepository = new Mock<MockEstudianteRepository>(context);

                // Act
                Estudiantes estudiante = null;

                // Assert
                Assert.Throws<EstudiantesNullException>(() => mockRepository.Object.Actualizar(estudiante));
            }
        }

        //Prueba 4
        [Fact]
        public void Actualizar_EstudianteNotExistsException()
        {
            // Arrange
            var options = GetInMemoryDatabaseOptions();
            using (var context = new EstudiantesContext(options))
            {
                var mockRepository = new Mock<MockEstudianteRepository>(context);

                // Act
                Estudiantes estudiante = new Estudiantes()
                {
                    Id = 8
                };

                // Assert
                Assert.Throws<EstudianteNotExistsException>(() => mockRepository.Object.Actualizar(estudiante));
            }
        }

        //Prueba 5
        [Fact]
        public void Remover_EstudianteNotExistsException()
        {
            // Arrange
            var options = GetInMemoryDatabaseOptions();
            using (var context = new EstudiantesContext(options))
            {
                var mockRepository = new Mock<MockEstudianteRepository>(context);

                // Act
                Estudiantes estudiante = null;

                // Assert
                Assert.Throws<EstudiantesNullException>(() => mockRepository.Object.Remover(estudiante));
            }
        }
    }
}
