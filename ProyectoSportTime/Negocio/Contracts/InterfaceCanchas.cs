using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Contracts
{
    public interface InterfaceCanchas
    {
        void AltaCancha(int codigoDeporte);
        void ModificarCancha(int canchaID, int nuevoCodigoDeporte);
        void BajaCancha(int canchaID);
    }
}
