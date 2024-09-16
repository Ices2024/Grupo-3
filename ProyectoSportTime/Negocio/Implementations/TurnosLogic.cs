using Microsoft.EntityFrameworkCore;
using Negocio.Contracts;
using Shared.Dtos;
using Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Implementations
{
    public class TurnosLogic : InterfaceTurnos
    {
        public void AltaTurno(int adminID, int canchaID, DateTime horaInicio, DateTime horaFin, int consumicionID)
        {
            using (var context = new ProyectoDbContext())
            {
                var nuevoTurno = new Turnos
                {
                    Admin_ID = adminID,
                    Cancha_ID = canchaID,
                    HoraInicio = horaInicio,
                    HoraFin = horaFin,
                    Consumicion_ID = consumicionID
                };
                context.Turnos.Add(nuevoTurno);
                context.SaveChanges();
            }
        }

        public void ModificarTurno(int turnoID, DateTime nuevaHoraInicio, DateTime nuevaHoraFin)
        {
            using (var context = new ProyectoDbContext())
            {
                var turno = context.Turnos.Find(turnoID);
                if (turno != null)
                {
                    turno.HoraInicio = nuevaHoraInicio;
                    turno.HoraFin = nuevaHoraFin;
                    context.SaveChanges();
                }
            }
        }

        public void BajaTurno(int turnoID)
        {
            using (var context = new ProyectoDbContext())
            {
                var turno = context.Turnos.Find(turnoID);
                if (turno != null)
                {
                    context.Turnos.Remove(turno);
                    context.SaveChanges();
                }
            }
        }
    }

}
