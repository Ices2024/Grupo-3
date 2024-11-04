using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Contracts
{
    public interface InterfaceTurnos
    {
        Task CrearTurno(TurnoDTO nuevoTurno);
        Task ModificarTurno(int id, TurnoDTO turnoModificado);
        Task<List<TurnoDTO>> ObtenerTodos();
        Task<TurnoDTO?> ObtenerPorId(int id);
        Task Borrar(int id);
    }

}
