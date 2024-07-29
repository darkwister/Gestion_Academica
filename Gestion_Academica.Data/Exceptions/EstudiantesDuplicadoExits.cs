using System;
namespace Gestion_Academica.Data.Exceptions
{
    public class EstudianteDuplicadoExists : Exception
    {
        public EstudianteDuplicadoExists(string message) : base(message) { }
    }
}

