using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Administrador 
    {
        public int Id_Administrador { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public ICollection<Turnos> Turnos { get; set; }
    }
}
