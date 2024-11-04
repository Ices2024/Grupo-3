using Microsoft.EntityFrameworkCore;
using Negocio.Contracts;
using API.Data;
using Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Dtos;
using Negocio.Repositorios;

namespace Negocio.Implementations
{
    public class TurnosLogic : InterfaceTurnos
    {
        private readonly ITurnosRepository _turnosRepository;

        public TurnosLogic(ITurnosRepository turnosRepository)
        {
            _turnosRepository = turnosRepository;
        }

        public async Task CrearTurno(TurnoDTO nuevoTurno)
        {
            ArgumentNullException.ThrowIfNull(nuevoTurno);

            if (nuevoTurno.Admin_ID <= 0)
                throw new ArgumentException("El ID del administrador debe ser mayor a cero.");

            // Aquí podrías agregar más validaciones según sea necesario.

            await _turnosRepository.CrearAsync(nuevoTurno);
        }

        public async Task ModificarTurno(int id, TurnoDTO turnoModificado)
        {
            ArgumentNullException.ThrowIfNull(turnoModificado);

            if (id <= 0)
                throw new ArgumentException("El ID del turno debe ser mayor a cero.");

            // Validaciones adicionales pueden ser añadidas aquí.

            await _turnosRepository.UpdateAsync(id, turnoModificado);
        }

        public async Task<List<TurnoDTO>> ObtenerTodos()
        {
            return await _turnosRepository.ObtenerTodosAsync();
        }

        public async Task<TurnoDTO?> ObtenerPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del turno debe ser mayor a cero.");

            return await _turnosRepository.ObtenerPorIdAsync(id);
        }

        public async Task Borrar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del turno debe ser mayor a cero.");

            await _turnosRepository.EliminarAsync(id);
        }

    }
}
