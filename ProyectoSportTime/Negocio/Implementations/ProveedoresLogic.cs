using Microsoft.EntityFrameworkCore;
using Negocio.Contracts;
using Shared.Dtos;
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
        public void AltaProveedor(string nombre, string email, string telefono)
        {
            using (var context = new ProyectoDbContext())
            {
                var nuevoProveedor = new Proveedores
                {
                    Nombre = nombre,
                    Email = email,
                    Telefono = telefono
                };
                context.Proveedores.Add(nuevoProveedor);
                context.SaveChanges();
            }
        }

        public void ModificarProveedor(int proveedorID, string nuevoNombre, string nuevoEmail, string nuevoTelefono)
        {
            using (var context = new ProyectoDbContext())
            {
                var proveedor = context.Proveedores.Find(proveedorID);
                if (proveedor != null)
                {
                    proveedor.Nombre = nuevoNombre;
                    proveedor.Email = nuevoEmail;
                    proveedor.Telefono = nuevoTelefono;
                    context.SaveChanges();
                }
            }
        }

        public void BajaProveedor(int proveedorID)
        {
            using (var context = new ProyectoDbContext())
            {
                var proveedor = context.Proveedores.Find(proveedorID);
                if (proveedor != null)
                {
                    context.Proveedores.Remove(proveedor);
                    context.SaveChanges();
                }
            }
        }
    }

}
