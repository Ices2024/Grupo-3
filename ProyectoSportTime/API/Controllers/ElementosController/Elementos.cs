using API.Data;
using Microsoft.AspNetCore.Mvc;
using Shared.Entidades;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers.ElementosController
{
    [ApiController]
    [Route("api/[controller]")]
    public class ElementosController : ControllerBase
    {
        private readonly ProyectoDbContext _context;

        // Constructor donde se inyecta el DbContext
        public ElementosController(ProyectoDbContext context)
        {
            _context = context;
        }

        // GET: api/elementos (Obtener todos los elementos)
        [HttpGet]
        public async Task<ActionResult<List<Elementos>>> Get()
        {
            var elementos = await _context.Elementos.ToListAsync();
            return Ok(elementos);
        }

        // GET: api/elementos/{id} (Obtener un elemento específico por ID)
        [HttpGet("{id}")]
        public async Task<ActionResult<Elementos>> Get(int id)
        {
            var elemento = await _context.Elementos.FindAsync(id);
            if (elemento == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el elemento
            }
            return Ok(elemento);
        }

        // POST: api/elementos (Alta de un nuevo elemento)
        [HttpPost]
        public async Task<ActionResult<Elementos>> Post([FromBody] Elementos nuevoElemento)
        {
            _context.Elementos.Add(nuevoElemento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = nuevoElemento.Elemento_ID }, nuevoElemento);
        }

        // PUT: api/elementos/{id} (Modificar un elemento existente)
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Elementos elementoModificado)
        {
            var elemento = await _context.Elementos.FindAsync(id);
            if (elemento == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el elemento
            }

            // Actualizamos los datos del elemento
            elemento.Nombre = elementoModificado.Nombre;
            elemento.Cantidad = elementoModificado.Cantidad;
            elemento.UpdatedDate = DateTime.Now;

            await _context.SaveChangesAsync();

            return NoContent(); // Devuelve 204 No Content
        }

        // DELETE: api/elementos/{id} (Eliminar un elemento)
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var elemento = await _context.Elementos.FindAsync(id);
            if (elemento == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el elemento
            }

            _context.Elementos.Remove(elemento);
            await _context.SaveChangesAsync();

            return NoContent(); // Devuelve 204 No Content
        }
    }
}
