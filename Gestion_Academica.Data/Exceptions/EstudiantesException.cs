using System;

namespace Gestion_Academica.Data.Exceptions
{
    public class EstudiantesNullException: Exception
    {
        public EstudiantesNullException(string message): base(message) 
        { 
            //X logica
        }
    }
}
