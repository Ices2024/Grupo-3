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
    public class ProveedoresLogic : InterfaceProveedores
    {
        private readonly ProyectoDbContext _context;

        // Constructor donde se inyecta el DbContext
        public ProveedoresLogic(ProyectoDbContext context)
        {
            _context = context;
        }

        public void AltaProveedor(string nombre, string email, string telefono)
        {
            var nuevoProveedor = new Proveedores
            {
                Nombre = nombre,
                Email = email,
                Telefono = telefono
            };
            _context.Proveedores.Add(nuevoProveedor);
            _context.SaveChanges();
        }

        public void ModificarProveedor(int proveedorID, string nuevoNombre, string nuevoEmail, string nuevoTelefono)
        {
            var proveedor = _context.Proveedores.Find(proveedorID);
            if (proveedor != null)
            {
                proveedor.Nombre = nuevoNombre;
                proveedor.Email = nuevoEmail;
                proveedor.Telefono = nuevoTelefono;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"No se encontró un proveedor con ID {proveedorID}.");
            }
        }

        public void BajaProveedor(int proveedorID)
        {
            var proveedor = _context.Proveedores.Find(proveedorID);
            if (proveedor != null)
            {
                _context.Proveedores.Remove(proveedor);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"No se encontró un proveedor con ID {proveedorID}.");
            }
        }
    }

}
