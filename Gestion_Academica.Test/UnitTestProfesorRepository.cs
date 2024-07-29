using Moq;
using Gestion_Academica.Data.Context;
using Gestion_Academica.Data.Exceptions;
using Gestion_Academica.Data.Repositories.Mocks;
using Gestion_Academica.Data.Entities;
namespace Gestion_Academica.Test
{
    public class UnitTestProfesorRepository
    {
        [Fact]
        public void Actualizar_EsProfesorNull()
        {
            //Arrange//
            var context = new ProfesorContext(); 
            var repository = new MockProfesorRepository(context);

            //Act & Assert//
            Profesor profesor = null;
            
            Assert.Throws<ProfesorNullException>(() => repository.Actualizar(profesor));
        }
        [Fact]
        public void Actualizar_ProfesorNotExist()
        {
            //Arrange//
            var context = new ProfesorContext();
            var repository = new MockProfesorRepository(context);

            //Act & Assert//
            Profesor profesor = new Profesor()
            {
                Id = 9
            };

            Assert.Throws<ProfesorNotExistException>(() => repository.Actualizar(profesor));
        }
        [Fact]
        public void Agregar_EsProfesorNull()
        {
            //Arrange//
            var context = new ProfesorContext();
            var repository = new MockProfesorRepository(context);

            //Act & Assert//
            Profesor profesor = null;

            Assert.Throws<ProfesorNullException>(() => repository.Agregar(profesor));
        }
        [Fact]
        public void Agregar_Duplicado()
        {
            //Arrange//
            var context = new ProfesorContext();
            var repository = new MockProfesorRepository(context);

            //Act & Assert//
            Profesor profesor = new Profesor()
            {
                Id = 2
            };

            Assert.Throws<ProfesorDuplicadoException>(() => repository.Agregar(profesor));
        }
        [Fact]
        public void Remover_EsProfesorNull()
        {
            //Arrange//
            var context = new ProfesorContext();
            var repository = new MockProfesorRepository(context);

            //Act & Assert//
            Profesor profesor = null;

            Assert.Throws<ProfesorNullException>(() => repository.Remover(profesor));
        }
    }
}