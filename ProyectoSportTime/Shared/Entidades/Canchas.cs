using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entidades
{
    public class Canchas
    {
        [Key]
        public int Cancha_ID { get; set; }
        public int Deporte_ID { get; set; }
        public Deportes Deporte { get; set; }  // Propiedad de navegación

        public string DisplayName => $"{Cancha_ID} - {Deporte_ID}";
        public ICollection<Turnos>? Turnos { get; set; }
        public ICollection<Elementos>? Elementos { get; set; }
    }

}
