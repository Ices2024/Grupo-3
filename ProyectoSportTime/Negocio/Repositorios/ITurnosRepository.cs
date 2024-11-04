using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repositorios
{
    public interface ITurnosRepository
    {
        Task<List<TurnoDTO>> ObtenerTodosAsync();
        Task<TurnoDTO?> ObtenerPorIdAsync(int id);
        Task<TurnoDTO> CrearAsync(TurnoDTO nuevoTurno);
        Task EliminarAsync(int id);
        Task<TurnoDTO> UpdateAsync(int id, TurnoDTO turnoModificado);
    }
}
