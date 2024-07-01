using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Consumicion
    {
        public int Id_Consumicion { get; set; }
        public string Cantidad { get; set; }
        public int Precio { get; set; }
        public ICollection<Turnos> Turnos { get; set; }
        public int Id_Producto{ get; set; }
        public Producto Producto { get; set; }
    }
}
