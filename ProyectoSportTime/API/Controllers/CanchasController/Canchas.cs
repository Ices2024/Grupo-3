using Microsoft.AspNetCore.Mvc;
using Shared.Entidades;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using API.Data;

namespace API.Controllers.CanchasController
{

    [ApiController]
    [Route("api/[controller]")]
    public class CanchasController : ControllerBase
    {
        private readonly ProyectoDbContext _context;

        // Constructor donde se inyecta el DbContext
        public CanchasController(ProyectoDbContext context)
        {
            _context = context;
        }

        // GET: api/canchas (Obtener todas las canchas)
        [HttpGet]
        public async Task<ActionResult<List<Canchas>>> Get()
        {
            var canchas = await _context.Canchas.ToListAsync();
            return Ok(canchas);
        }

        // GET: api/canchas/{id} (Obtener una cancha específica por ID)
        [HttpGet("{id}")]
        public async Task<ActionResult<Canchas>> Get(int id)
        {
            var cancha = await _context.Canchas.FindAsync(id);
            if (cancha == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra la cancha
            }
            return Ok(cancha);
        }

        // POST: api/canchas (Alta de una nueva cancha)
        [HttpPost]
        public async Task<ActionResult<Canchas>> Post([FromBody] Canchas nuevaCancha)
        {
            _context.Canchas.Add(nuevaCancha);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = nuevaCancha.Cancha_ID }, nuevaCancha);
        }

        // PUT: api/canchas/{id} (Modificar una cancha existente)
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Canchas canchaModificada)
        {
            var cancha = await _context.Canchas.FindAsync(id);
            if (cancha == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra la cancha
            }

            // Actualizamos los datos de la cancha
            cancha.Deporte_ID = canchaModificada.Deporte_ID;
            cancha.Deporte = canchaModificada.Deporte;  // Asegúrate de que esto sea correcto según el modelo
            cancha.UpdatedDate = DateTime.Now;

            await _context.SaveChangesAsync();

            return NoContent(); // Devuelve 204 No Content
        }

        // DELETE: api/canchas/{id} (Eliminar una cancha)
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var cancha = await _context.Canchas.FindAsync(id);
            if (cancha == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra la cancha
            }

            _context.Canchas.Remove(cancha);
            await _context.SaveChangesAsync();

            return NoContent(); // Devuelve 204 No Content
        }
    }

}
