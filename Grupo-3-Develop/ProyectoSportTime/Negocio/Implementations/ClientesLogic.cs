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
    public class ClientesLogic : InterfaceClientes
    {
        public void AltaCliente(string nombre, int numeroTelefono)
        {
            using (var context = new ProyectoDbContext())
            {
                var nuevoCliente = new Clientes
                {
                    Nombre = nombre,
                    NumeroTelefono = numeroTelefono
                };
                context.Clientes.Add(nuevoCliente);
                context.SaveChanges();
            }
        }

        public void ModificarCliente(int clienteID, string nuevoNombre, int nuevoTelefono)
        {
            using (var context = new ProyectoDbContext())
            {
                var cliente = context.Clientes.Find(clienteID);
                if (cliente != null)
                {
                    cliente.Nombre = nuevoNombre;
                    cliente.NumeroTelefono = nuevoTelefono;
                    context.SaveChanges();
                }
            }
        }

        public void BajaCliente(int clienteID)
        {
            using (var context = new ProyectoDbContext())
            {
                var cliente = context.Clientes.Find(clienteID);
                if (cliente != null)
                {
                    context.Clientes.Remove(cliente);
                    context.SaveChanges();
                }
            }
        }
    }

}
