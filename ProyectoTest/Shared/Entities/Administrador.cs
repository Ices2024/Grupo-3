using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    internal class Administrador : Turnos
    {
        public int Id_Administrador { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public ICollection<Turnos> Turnos { get; set; }
    }
}
