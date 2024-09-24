using Microsoft.AspNetCore.Mvc;
using Shared.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers.ClientesControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        // Simulamos una base de datos en memoria para los clientes
        private static List<Clientes> clientes = new List<Clientes>();

        // GET: api/clientes (Obtener todos los clientes)
        [HttpGet]
        public ActionResult<List<Clientes>> Get()
        {
            return Ok(clientes);
        }

        // GET: api/clientes/{id} (Obtener un cliente específico por ID)
        [HttpGet("{id}")]
        public ActionResult<Clientes> Get(int id)
        {
            var cliente = clientes.FirstOrDefault(c => c.Cliente_ID == id);
            if (cliente == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el cliente
            }
            return Ok(cliente);
        }

        // POST: api/clientes (Alta de un nuevo cliente)
        [HttpPost]
        public ActionResult<Clientes> Post([FromBody] Clientes nuevoCliente)
        {
            nuevoCliente.Cliente_ID = clientes.Count + 1; // Simulación de ID auto-generado
            clientes.Add(nuevoCliente);
            return CreatedAtAction(nameof(Get), new { id = nuevoCliente.Cliente_ID }, nuevoCliente);
        }

        // PUT: api/clientes/{id} (Modificar un cliente existente)
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Clientes clienteModificado)
        {
            var cliente = clientes.FirstOrDefault(c => c.Cliente_ID == id);
            if (cliente == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el cliente
            }

            // Actualizamos los datos del cliente
            cliente.Nombre = clienteModificado.Nombre;
            cliente.NumeroTelefono = clienteModificado.NumeroTelefono;
            cliente.UpdatedDate = DateTime.Now;

            return NoContent(); // Devuelve 204 No Content
        }

        // DELETE: api/clientes/{id} (Eliminar un cliente)
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var cliente = clientes.FirstOrDefault(c => c.Cliente_ID == id);
            if (cliente == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el cliente
            }

            clientes.Remove(cliente);
            return NoContent(); // Devuelve 204 No Content
        }
    }
}
}
