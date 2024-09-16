using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entidades
{
    public class Elementos
    {
        [Key]
        public int Elemento_ID { get; set; } 
        public string? Nombre { get; set; }
        public int Cantidad { get; set; }

        public int Cancha_ID { get; set; } 
        public Canchas? Canchas { get; set; }
    }
}

