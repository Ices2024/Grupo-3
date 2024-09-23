using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Contracts
{
    public interface InterfaceConsumicion
    {
        void AltaConsumicion(int cantidad, bool precio, int codProducto);
        void ModificarConsumicion(int consumicionID, int nuevaCantidad, bool nuevoPrecio);
        void BajaConsumicion(int consumicionID);
    }

}
