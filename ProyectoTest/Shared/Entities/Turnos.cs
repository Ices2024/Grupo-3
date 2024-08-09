using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Turnos 
    {
        public int Id_Turnos { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public int Administrador { get; set; }
        public int Id_Cancha { get; set; }
        public Cancha Cancha { get; set; }

        public int Id_Administrador { get; set; }
        public Administrador administrador { get; set; }

        public int Id_Consumicion { get; set; }
        public Consumicion Consumicion { get; set; }
        public ICollection<Cliente> Cliente { get; set; }
    }

}

