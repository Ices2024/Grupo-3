using Microsoft.EntityFrameworkCore;
using Negocio.Contracts;
using API.Data;
using Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Implementations
{
    public class ProductosLogic : InterfaceProductos
    {
        public void AltaProducto(string tipo, string descripcion, int proveedorID)
        {
            using (var context = new ProyectoDbContext())
            {
                var nuevoProducto = new Productos
                {
                    Tipo = tipo,
                    Descripcion = descripcion,
                    Proveedor_ID = proveedorID
                };
                context.Productos.Add(nuevoProducto);
                context.SaveChanges();
            }
        }

        public void ModificarProducto(int productoID, string nuevoTipo, string nuevaDescripcion)
        {
            using (var context = new ProyectoDbContext())
            {
                var producto = context.Productos.Find(productoID);
                if (producto != null)
                {
                    producto.Tipo = nuevoTipo;
                    producto.Descripcion = nuevaDescripcion;
                    context.SaveChanges();
                }
            }
        }

        public void BajaProducto(int productoID)
        {
            using (var context = new ProyectoDbContext())
            {
                var producto = context.Productos.Find(productoID);
                if (producto != null)
                {
                    context.Productos.Remove(producto);
                    context.SaveChanges();
                }
            }
        }
    }

}
