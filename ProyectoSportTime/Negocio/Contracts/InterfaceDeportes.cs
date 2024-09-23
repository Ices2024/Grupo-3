using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Contracts
{
    public interface InterfaceDeportes
    {
        void AltaDeporte(string tipo);
        void ModificarDeporte(int deporteID, string nuevoTipo);
        void BajaDeporte(int deporteID);
    }
}
