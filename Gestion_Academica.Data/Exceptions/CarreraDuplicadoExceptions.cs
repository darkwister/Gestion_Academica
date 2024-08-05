
using System;

namespace Gestion_Academica.Data.Exceptions
{
    public class CarreraDuplicadoExceptions : Exception
    {
        public CarreraDuplicadoExceptions(string message) : base(message) 
        {
            // Logica para guardar el log del error y retornar la notificacion
        }

    }
}
