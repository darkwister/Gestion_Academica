

using System;
using System.ComponentModel.DataAnnotations;

namespace Gestion_Academica.Data.Entities
{
    public class Carrera
    {
        [Key]
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get;set; }
        public int Estado { get; set;}
        public DateTime FechaCreacion { get; set; }

    }
}
