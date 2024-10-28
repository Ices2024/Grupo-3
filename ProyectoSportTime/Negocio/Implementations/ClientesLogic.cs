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
        private readonly ProyectoDbContext _context;

        // Constructor donde se inyecta el DbContext
        public ClientesLogic(ProyectoDbContext context)
        {
            _context = context;
        }

        public void AltaCliente(string nombre, int numeroTelefono)
        {
            var nuevoCliente = new Clientes
            {
                Nombre = nombre,
                NumeroTelefono = numeroTelefono
            };
            _context.Clientes.Add(nuevoCliente);
            _context.SaveChanges();
        }

        public void ModificarCliente(int clienteID, string nuevoNombre, int nuevoTelefono)
        {
            var cliente = _context.Clientes.Find(clienteID);
            if (cliente != null)
            {
                cliente.Nombre = nuevoNombre;
                cliente.NumeroTelefono = nuevoTelefono;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"No se encontró un cliente con ID {clienteID}.");
            }
        }

        public void BajaCliente(int clienteID)
        {
            var cliente = _context.Clientes.Find(clienteID);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"No se encontró un cliente con ID {clienteID}.");
            }
        }
    }

}
