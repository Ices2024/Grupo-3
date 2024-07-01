using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Cliente 
    {
        public int Id_Cliente { get; set; }
        public string Nombre { get; set; }
        public long NumeroTelefono { get; set; }
        public int Id_Turnos { get; set; }
        public Turnos Turnos { get; set; }
    }
}
