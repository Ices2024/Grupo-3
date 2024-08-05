using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime
{
    public class Productos
    {
        [Key]
        public int Producto_ID { get; set; }
        public string? Tipo { get; set; }
        public string? Descripcion { get; set; }

        public ICollection<Consumiciones>? Consumiciones { get; set; }
    }
}
