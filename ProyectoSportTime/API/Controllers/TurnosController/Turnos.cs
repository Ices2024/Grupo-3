using API.Data;
using Microsoft.AspNetCore.Mvc;
using Shared.Entidades;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers.TurnosController
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurnosController : ControllerBase
    {
        private readonly ProyectoDbContext _context;

        // Constructor donde se inyecta el DbContext
        public TurnosController(ProyectoDbContext context)
        {
            _context = context;
        }

        // GET: api/turnos (Obtener todos los turnos)
        [HttpGet]
        public async Task<ActionResult<List<Turnos>>> Get()
        {
            var turnos = await _context.Turnos
                .Include(t => t.Administrador) // Incluye el administrador relacionado
                .Include(t => t.Canchas) // Incluye la cancha relacionada
                .Include(t => t.Consumicion) // Incluye la consumición relacionada
                .Include(t => t.Cliente) // Incluye el cliente relacionado
                .ToListAsync();

            return Ok(turnos);
        }

        // GET: api/turnos/{id} (Obtener un turno específico por ID)
        [HttpGet("{id}")]
        public async Task<ActionResult<Turnos>> Get(int id)
        {
            var turno = await _context.Turnos
                .Include(t => t.Administrador)
                .Include(t => t.Canchas)
                .Include(t => t.Consumicion)
                .Include(t => t.Cliente)
                .FirstOrDefaultAsync(t => t.Turno_ID == id);

            if (turno == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el turno
            }

            return Ok(turno);
        }

        // POST: api/turnos (Alta de un nuevo turno)
        [HttpPost]
        public async Task<ActionResult<Turnos>> Post([FromBody] Turnos nuevoTurno)
        {
            _context.Turnos.Add(nuevoTurno);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = nuevoTurno.Turno_ID }, nuevoTurno);
        }

        // PUT: api/turnos/{id} (Modificar un turno existente)
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Turnos turnoModificado)
        {
            var turno = await _context.Turnos.FindAsync(id);
            if (turno == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el turno
            }

            // Actualizamos los datos del turno
            turno.Admin_ID = turnoModificado.Admin_ID;
            turno.Canchas = turnoModificado.Canchas; // Cambiado de Cancha_ID a Canchas
            turno.HoraInicio = turnoModificado.HoraInicio;
            turno.HoraFin = turnoModificado.HoraFin;
            turno.Consumicion_ID = turnoModificado.Consumicion_ID;
            turno.UpdatedDate = DateTime.Now;

            await _context.SaveChangesAsync();

            return NoContent(); // Devuelve 204 No Content
        }

        // DELETE: api/turnos/{id} (Eliminar un turno)
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var turno = await _context.Turnos.FindAsync(id);
            if (turno == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el turno
            }

            _context.Turnos.Remove(turno);
            await _context.SaveChangesAsync();

            return NoContent(); // Devuelve 204 No Content
        }
    }
}
