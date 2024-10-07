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
        public int Codigo_Deporte { get; set; }
        public string? Deporte { get; set; }
        public DateTime UpdatedDate { get; set; }
    }

}
