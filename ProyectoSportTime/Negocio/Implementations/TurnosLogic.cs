using Microsoft.EntityFrameworkCore;
using Negocio.Contracts;
using API.Data;
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
        private readonly ProyectoDbContext _context;

        // Constructor donde se inyecta el DbContext
        public TurnosLogic(ProyectoDbContext context)
        {
            _context = context;
        }

        public void AltaTurno(int adminID, int canchaID, DateTime horaInicio, DateTime horaFin, int consumicionID, int clienteID)
        {
            var nuevoTurno = new Turnos
            {
                Admin_ID = adminID,
                Cancha_ID = canchaID,
                HoraInicio = horaInicio,
                HoraFin = horaFin,
                Consumicion_ID = consumicionID,
                Cliente_ID = clienteID
            };
            _context.Turnos.Add(nuevoTurno);
            _context.SaveChanges();
        }

        public void ModificarTurno(int turnoID, DateTime nuevaHoraInicio, DateTime nuevaHoraFin)
        {
            var turno = _context.Turnos.Find(turnoID);
            if (turno != null)
            {
                turno.HoraInicio = nuevaHoraInicio;
                turno.HoraFin = nuevaHoraFin;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"No se encontró un turno con ID {turnoID}.");
            }
        }

        public void BajaTurno(int turnoID)
        {
            var turno = _context.Turnos.Find(turnoID);
            if (turno != null)
            {
                _context.Turnos.Remove(turno);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"No se encontró un turno con ID {turnoID}.");
            }
        }
    }

}
