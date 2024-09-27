using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Contracts
{
    public interface InterfaceConsumicion
    {
        void AltaConsumicion(int cantidad, decimal precio, int codProducto);
        void ModificarConsumicion(int consumicionID, int nuevaCantidad, decimal nuevoPrecio);
        void BajaConsumicion(int consumicionID);
    }

}
