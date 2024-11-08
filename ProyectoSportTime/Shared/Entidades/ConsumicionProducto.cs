using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entidades
{
    public class ConsumicionProducto
    {
        public int Consumicion_ID { get; set; } // Clave foránea hacia Consumiciones
        public Consumiciones Consumicion { get; set; }

        public int Producto_ID { get; set; } // Clave foránea hacia Productos
        public Productos Producto { get; set; }
    }
}
