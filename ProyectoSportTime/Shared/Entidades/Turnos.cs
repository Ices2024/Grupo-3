using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entidades
{
    public class Turnos
    {
        [Key]
        public int Turno_ID { get; set; }
        public int Admin_ID { get; set; } // Clave Foránea
        public int Cancha_ID { get; set; } // Clave Foránea
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public int Consumicion_ID { get; set; } // Clave Foránea
        public int Cliente_ID { get; set; } // Clave Foránea a Clientes


        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }

        public Administrador? Administrador { get; set; }
        public Canchas? Canchas { get; set; }
        public Consumiciones? Consumicion { get; set; }
        public Clientes? Cliente { get; set; } // Relación con Cliente
    }
}
