using System.ComponentModel.DataAnnotations;

namespace SportsTime
{
    public class Turnos
    {
        [Key]
        public int Turno_ID { get; set; }
        public int Admin_ID { get; set; }
        public int Cancha_ID { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public int Consumicion_ID { get; set; }

        public Administrador? Administrador { get; set; }
        public Canchas? Canchas { get; set; }
        public Consumiciones? Consumicion { get; set; }
    }
}
