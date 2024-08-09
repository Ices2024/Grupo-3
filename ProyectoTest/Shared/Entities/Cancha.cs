using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Cancha 
    {
        public int Id_Cancha { get; set; }
        public string Elementos { get; set; }
        public ICollection<Turnos> Turnos { get; set; }
        public int Id_Deporte { get; set; }
        public Deporte Deporte { get; set; }
    }
}
