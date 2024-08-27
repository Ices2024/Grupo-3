using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime
{
    public class Canchas
    {
        [Key]
        public int Cancha_ID { get; set; }
        public int Codigo_Deporte { get; set; }
        public Deportes? Deporte { get; set; }

        public ICollection<Turnos>? Turnos { get; set; }
        public ICollection<Elementos>? Elementos { get; set; }

    }
}
