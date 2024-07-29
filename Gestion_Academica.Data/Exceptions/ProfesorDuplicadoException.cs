using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Academica.Data.Exceptions
{
    public class ProfesorDuplicadoException : Exception
    {
        public ProfesorDuplicadoException(string message) : base(message) { }
    }
}
