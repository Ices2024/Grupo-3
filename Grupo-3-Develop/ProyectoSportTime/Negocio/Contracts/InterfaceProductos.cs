using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Contracts
{
    public interface InterfaceProductos
    {
        void AltaProducto(string tipo, string descripcion, int proveedorID);
        void ModificarProducto(int productoID, string nuevoTipo, string nuevaDescripcion);
        void BajaProducto(int productoID);
    }
}
