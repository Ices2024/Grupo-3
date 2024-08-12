using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime.Entities
{
    public class Consumiciones
    {
        [Key]
        public int Consumicion_ID { get; set; }
        public int Cantidad { get; set; }
        public bool Precio { get; set; }
        public int Cod_Producto { get; set; } // Clave Foranea

        public Productos? Producto { get; set; }
    }
}
