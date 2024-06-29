using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    internal class Deporte : Cancha
    { 
        public int Id_Deporte { get; set; }
        public string TipoDeporte { get; set; }
        public ICollection<Cancha> Cancha { get; set; }
    }
}
