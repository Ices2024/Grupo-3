using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entidades
{
    public class Consumiciones
    {
        [Key]
        public int Consumicion_ID { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; } // Debería ser decimal en lugar de bool
        public int Cod_Producto { get; set; } // Clave Foránea

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }

        public Productos? Producto { get; set; }
    }
}
