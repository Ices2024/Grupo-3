using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Shared.Entidades;
using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers.ConsumicionController
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsumicionesController : ControllerBase
    {
        private readonly ProyectoDbContext _context;

        // Constructor donde se inyecta el DbContext
        public ConsumicionesController(ProyectoDbContext context)
        {
            _context = context;
        }

        // GET: api/consumiciones (Obtener todas las consumiciones)
        [HttpGet]
        public async Task<ActionResult<List<Consumiciones>>> Get()
        {
            var consumiciones = await _context.Consumiciones.ToListAsync();
            return Ok(consumiciones);
        }

        // GET: api/consumiciones/{id} (Obtener una consumición específica por ID)
        [HttpGet("{id}")]
        public async Task<ActionResult<Consumiciones>> Get(int id)
        {
            var consumicion = await _context.Consumiciones.FindAsync(id);
            if (consumicion == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra la consumición
            }
            return Ok(consumicion);
        }

        // POST: api/consumiciones (Alta de una nueva consumición)
        [HttpPost]
        public async Task<ActionResult<Consumiciones>> Post([FromBody] Consumiciones nuevaConsumicion)
        {
            _context.Consumiciones.Add(nuevaConsumicion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = nuevaConsumicion.Consumicion_ID }, nuevaConsumicion);
        }

        // PUT: api/consumiciones/{id} (Modificar una consumición existente)
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Consumiciones consumicionModificada)
        {
            var consumicion = await _context.Consumiciones.FindAsync(id);
            if (consumicion == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra la consumición
            }

            // Actualizamos los datos de la consumición
            consumicion.Cantidad = consumicionModificada.Cantidad;
            consumicion.Precio = consumicionModificada.Precio;
            consumicion.Cod_Producto = consumicionModificada.Cod_Producto; // Asegúrate de que esto exista en tu modelo
            consumicion.UpdatedDate = DateTime.Now;

            await _context.SaveChangesAsync();

            return NoContent(); // Devuelve 204 No Content
        }

        // DELETE: api/consumiciones/{id} (Eliminar una consumición)
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var consumicion = await _context.Consumiciones.FindAsync(id);
            if (consumicion == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra la consumición
            }

            _context.Consumiciones.Remove(consumicion);
            await _context.SaveChangesAsync();

            return NoContent(); // Devuelve 204 No Content
        }
    }
}