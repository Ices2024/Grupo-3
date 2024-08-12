using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SportsTime.Entities
{
    public class Elementos
    {
        [Key]
        public int Elemento_ID { get; set; } // Clave primaria
        public string? Nombre { get; set; }
        public int Cantidad { get; set; }

        public int Cancha_ID { get; set; } // Clave foránea
        public Canchas? Canchas { get; set; }
    }
}
