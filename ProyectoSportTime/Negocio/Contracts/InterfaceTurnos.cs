using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Contracts
{
    public interface InterfaceTurnos
    {
        void AltaTurno(int adminID, int canchaID, DateTime horaInicio, DateTime horaFin, int consumicionID, int clienteID);
        void ModificarTurno(int turnoID, DateTime nuevaHoraInicio, DateTime nuevaHoraFin);
        void BajaTurno(int turnoID);
    }

}
