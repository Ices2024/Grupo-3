using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos
{
    public class CanchaDTO
    {
        public int Cancha_ID { get; set; }
        public int Deporte_ID { get; set; } // Asegúrate de que esto sea parte del DTO
        public string? Deporte { get; set; } // Este puede ser un string o un DTO de deportes si necesitas más información
        public string? Tipo { get; set; }
    }
}