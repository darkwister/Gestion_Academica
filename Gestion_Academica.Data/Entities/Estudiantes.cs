
using System;

namespace Gestion_Academica.Data.Entities
{
    public class Estudiantes
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Matricula { get; set; }
        public DateTime Fecha_nacimiento { get; set; }
        public string Cedula { get; set; }
        public char Sexo { get; set; }
        public char Becado { get; set; }
    }
}
