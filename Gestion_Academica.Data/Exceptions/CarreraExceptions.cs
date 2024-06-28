
using System;

namespace Gestion_Academica.Data.Exceptions
{
    public class CarreraExceptions : Exception
    {
        public CarreraExceptions(string message) : base(message) 
        {
            // Logica para guardar el log del error y retornar la notificacion
        }

    }
}
