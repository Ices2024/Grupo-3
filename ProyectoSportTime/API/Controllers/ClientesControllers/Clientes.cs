using API.Data;
using Microsoft.AspNetCore.Mvc;
using Shared.Entidades;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers.ClientesControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ProyectoDbContext _context;

        // Constructor donde se inyecta el DbContext
        public ClientesController(ProyectoDbContext context)
        {
            _context = context;
        }

        // GET: api/clientes (Obtener todos los clientes)
        [HttpGet]
        public async Task<ActionResult<List<Clientes>>> Get()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return Ok(clientes);
        }

        // GET: api/clientes/{id} (Obtener un cliente específico por ID)
        [HttpGet("{id}")]
        public async Task<ActionResult<Clientes>> Get(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el cliente
            }
            return Ok(cliente);
        }

        // POST: api/clientes (Alta de un nuevo cliente)
        [HttpPost]
        public async Task<ActionResult<Clientes>> Post([FromBody] Clientes nuevoCliente)
        {
            _context.Clientes.Add(nuevoCliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = nuevoCliente.Cliente_ID }, nuevoCliente);
        }

        // PUT: api/clientes/{id} (Modificar un cliente existente)
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Clientes clienteModificado)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el cliente
            }

            // Actualizamos los datos del cliente
            cliente.Nombre = clienteModificado.Nombre;
            cliente.NumeroTelefono = clienteModificado.NumeroTelefono; // Asegúrate de que esto exista en tu modelo
            cliente.UpdatedDate = DateTime.Now;

            await _context.SaveChangesAsync();

            return NoContent(); // Devuelve 204 No Content
        }

        // DELETE: api/clientes/{id} (Eliminar un cliente)
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el cliente
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent(); // Devuelve 204 No Content
        }
    }
}

