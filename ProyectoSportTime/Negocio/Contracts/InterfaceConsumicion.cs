using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Contracts
{
    public interface InterfaceConsumicion
    {
        void AltaCliente(string nombre, int numeroTelefono);
        void ModificarCliente(int clienteID, string nuevoNombre, int nuevoTelefono);
        void BajaCliente(int clienteID);
    }
}
