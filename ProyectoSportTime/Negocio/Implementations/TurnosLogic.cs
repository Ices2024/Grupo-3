using Microsoft.EntityFrameworkCore;
using Negocio.Repositorys;
using Negocio.Contracts;
using API.Data;
using Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Dtos;

namespace Negocio.Implementations
{
    public class TurnosLogic
    {
        public async Task CrearTurno(TurnoDTO turno)
        {
            ArgumentNullException.ThrowIfNull(turno);

            // Validaciones adicionales si las necesitas
            if (turno.Admin_ID <= 0)
                throw new ArgumentException("Admin_ID debe ser mayor a cero");

            if (turno.Cancha_ID <= 0)
                throw new ArgumentException("Cancha_ID debe ser mayor a cero");

            if (turno.Consumicion_ID <= 0)
                throw new ArgumentException("Consumicion_ID debe ser mayor a cero");

            if (turno.Cliente_ID <= 0)
                throw new ArgumentException("Cliente_ID debe ser mayor a cero");

            if (turno.HoraInicio >= turno.HoraFin)
                throw new ArgumentException("Hora de inicio debe ser menor que la hora de fin");

            await TurnosRepository.CreateTurno(turno);  // Llamamos al servicio para crear el turno
        }

        public async Task ModificarTurno(int turnoID, TurnoDTO turnoModificar)
        {
            ArgumentNullException.ThrowIfNull(turnoModificar);

            if (turnoID <= 0)
                throw new ArgumentException("Id debe ser mayor a cero");

            if (turnoModificar.HoraInicio >= turnoModificar.HoraFin)
                throw new ArgumentException("Hora de inicio debe ser menor que la hora de fin");

            await TurnosRepository.UpdateTurno(turnoID, turnoModificar);  // Llamamos al servicio para modificar el turno
        }

        public async Task BorrarTurno(int turnoID)
        {
            if (turnoID <= 0)
                throw new ArgumentException("Id debe ser mayor a cero");

            await TurnosRepository.DeleteTurno(turnoID);  // Llamamos al servicio para eliminar el turno
        }

        public async Task<List<TurnoDTO>> ObtenerTodosLosTurnos()
        {
            return await TurnosRepository.GetAllTurnos();  // Llamamos al servicio para obtener los turnos
        }

        public async Task<TurnoDTO?> ObtenerTurnoPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id debe ser mayor a cero");

            return await TurnosRepository.GetTurnoById(id);  // Llamamos al servicio para obtener un turno por ID
        }
    }

}

