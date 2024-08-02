using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Academica.Data.Entities
{
    public class Profesor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public int Cedula { get; set; }
        public char Sexo { get; set; }
    }
}
