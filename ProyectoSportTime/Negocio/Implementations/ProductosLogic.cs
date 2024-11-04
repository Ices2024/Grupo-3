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
        private readonly ProyectoDbContext _context;

        // Constructor donde se inyecta el DbContext
        public ProductosLogic(ProyectoDbContext context)
        {
            _context = context;
        }

        public void AltaProducto(string tipo, string descripcion, int proveedorID)
        {
            var nuevoProducto = new Productos
            {
                Tipo = tipo,
                Descripcion = descripcion,
                Proveedor_ID = proveedorID
            };
            _context.Productos.Add(nuevoProducto);
            _context.SaveChanges();
        }

        public void ModificarProducto(int productoID, string nuevoTipo, string nuevaDescripcion)
        {
            var producto = _context.Productos.Find(productoID);
            if (producto != null)
            {
                producto.Tipo = nuevoTipo;
                producto.Descripcion = nuevaDescripcion;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"No se encontró un producto con ID {productoID}.");
            }
        }

        public void BajaProducto(int productoID)
        {
            var producto = _context.Productos.Find(productoID);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"No se encontró un producto con ID {productoID}.");
            }
        }
    }

}
