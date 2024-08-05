﻿using Microsoft.EntityFrameworkCore;
using Moq;
using Gestion_Academica.Data.Context;
using Gestion_Academica.Data.Exceptions;
using Gestion_Academica.Data.Entities;
using Gestion_Academica.Data.Repositories.Mocks;

namespace Gestion_Academica.Test
{
    public class UnitTestAddEstudiante2
    {
        private DbContextOptions<EstudiantesContext> GetInMemoryDatabaseOptions()
        {
            // Configura las opciones para usar una base de datos en memoria
            return new DbContextOptionsBuilder<EstudiantesContext>()
                .UseInMemoryDatabase(databaseName: "GestionAcademica")
                .Options;
        }

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
    }
}