using Microsoft.EntityFrameworkCore;
using Negocio.Contracts;
using API.Data;
using Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Repositorys;
using Shared.Dtos;

namespace Negocio.Implementations
{
    public class ClientesLogic
    {
        // Crear un nuevo cliente
        public async Task AltaCliente(ClienteDTO nuevoCliente)
        {
            ArgumentNullException.ThrowIfNull(nuevoCliente);

            // Validación de los datos
            if (string.IsNullOrEmpty(nuevoCliente.Nombre))
            {
                throw new ArgumentException("El nombre no puede estar vacío.");
            }

            if (nuevoCliente.NumeroTelefono <= 0)
            {
                throw new ArgumentException("El número de teléfono debe ser válido.");
            }

            // Llamamos al repositorio para crear el cliente
            await ClientesRepository.CreateCliente(nuevoCliente);
        }

        // Modificar un cliente existente
        public async Task ModificarCliente(int clienteID, ClienteDTO clienteModificado)
        {
            ArgumentNullException.ThrowIfNull(clienteModificado);

            // Validaciones
            if (clienteID <= 0)
            {
                throw new ArgumentException("El ID debe ser mayor a cero.");
            }

            if (string.IsNullOrEmpty(clienteModificado.Nombre))
            {
                throw new ArgumentException("El nombre no puede estar vacío.");
            }

            if (clienteModificado.NumeroTelefono <= 0)
            {
                throw new ArgumentException("El número de teléfono debe ser válido.");
            }

            // Llamamos al repositorio para modificar el cliente
            await ClientesRepository.UpdateCliente(clienteID, clienteModificado);
        }

        // Eliminar un cliente
        public async Task BajaCliente(int clienteID)
        {
            if (clienteID <= 0)
            {
                throw new ArgumentException("El ID debe ser mayor a cero.");
            }

            // Llamamos al repositorio para eliminar el cliente
            await ClientesRepository.DeleteCliente(clienteID);
        }

        // Obtener todos los clientes
        public async Task<List<ClienteDTO>> ObtenerTodosLosClientes()
        {
            return await ClientesRepository.GetAllClientes();
        }

        // Obtener un cliente por ID
        public async Task<ClienteDTO?> ObtenerClientePorId(int clienteID)
        {
            if (clienteID <= 0)
            {
                throw new ArgumentException("El ID debe ser mayor a cero.");
            }

            return await ClientesRepository.GetClienteById(clienteID);
        }
    }
}
