using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entidades
{
    public class Ejemplo
    {
        [Key]
        public int Ejemplo_ID { get; set; }
        public string? Nombre { get; set; }
        public string? Email { get; set; }

        public ICollection<Turnos>? Turnos { get; set; }
    }
}
