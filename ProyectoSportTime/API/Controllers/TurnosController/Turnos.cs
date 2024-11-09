using API.Data;
using Microsoft.AspNetCore.Mvc;
using Shared.Entidades;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos;

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
        public async Task<ActionResult<List<TurnoDTO>>> Get()
        {
            var turnos = await _context.Turnos
                .Include(t => t.Administrador) // Incluye el administrador relacionado
                .Include(t => t.Canchas) // Incluye la cancha relacionada
                .Include(t => t.Consumicion)// Incluye la consumición relacionada
                .Include(t => t.Cliente) // Incluye el cliente relacionado
                .Select(t => new TurnoDTO
                {
                    Turno_ID = t.Turno_ID,
                    Admin_ID = t.Admin_ID,
                    Cancha_ID = t.Cancha_ID,
                    HoraInicio = t.HoraInicio,
                    HoraFin = t.HoraFin,
                    Consumicion_ID = t.Consumicion_ID,
                    Consumicion = t.Consumicion,
                    Cliente_ID = t.Cliente_ID // Agregado para reflejar la relación con Cliente
                })
                .ToListAsync();

            return Ok(turnos);
        }

        // GET: api/turnos/{id} (Obtener un turno específico por ID)
        [HttpGet("{id}")]
        public async Task<ActionResult<TurnoDTO>> Get(int id)
        {
            var turno = await _context.Turnos
                .Include(t => t.Administrador)
                .Include(t => t.Canchas)
                .Include(t => t.Consumicion)
                .Include(t => t.Cliente)
                .Where(t => t.Turno_ID == id)
                .Select(t => new TurnoDTO
                {
                    Turno_ID = t.Turno_ID,
                    Admin_ID = t.Admin_ID,
                    Cancha_ID = t.Cancha_ID,
                    HoraInicio = t.HoraInicio,
                    HoraFin = t.HoraFin,
                    Consumicion_ID = t.Consumicion_ID,
                    Cliente_ID = t.Cliente_ID // Agregado para reflejar la relación con Cliente
                })
                .FirstOrDefaultAsync();

            if (turno == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el turno
            }

            return Ok(turno);
        }

        // POST: api/turnos (Alta de un nuevo turno)
        [HttpPost]
        public async Task<ActionResult<TurnoDTO>> Post([FromBody] TurnoDTO nuevoTurno)
        {
            var turno = new Turnos
            {
                Admin_ID = nuevoTurno.Admin_ID,
                Cancha_ID = nuevoTurno.Cancha_ID,
                HoraInicio = nuevoTurno.HoraInicio,
                HoraFin = nuevoTurno.HoraFin,
                Consumicion_ID = nuevoTurno.Consumicion_ID,
                Cliente_ID = nuevoTurno.Cliente_ID // Agregado para reflejar la relación con Cliente
            };

            _context.Turnos.Add(turno);
            await _context.SaveChangesAsync();

            nuevoTurno.Turno_ID = turno.Turno_ID; // Asignar el ID generado
            return CreatedAtAction(nameof(Get), new { id = nuevoTurno.Turno_ID }, nuevoTurno);
        }

        // PUT: api/turnos/{id} (Modificar un turno existente)
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TurnoDTO turnoModificado)
        {
            var turno = await _context.Turnos.FindAsync(id);
            if (turno == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el turno
            }

            // Actualizamos los datos del turno
            turno.Admin_ID = turnoModificado.Admin_ID;
            turno.Cancha_ID = turnoModificado.Cancha_ID; // Cambiado de Canchas a Cancha_ID
            turno.HoraInicio = turnoModificado.HoraInicio;
            turno.HoraFin = turnoModificado.HoraFin;
            turno.Consumicion_ID = turnoModificado.Consumicion_ID;
            turno.Cliente_ID = turnoModificado.Cliente_ID; // Agregado para reflejar la relación con Cliente

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
