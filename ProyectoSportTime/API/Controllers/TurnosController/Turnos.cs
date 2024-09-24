using Microsoft.AspNetCore.Mvc;
using Shared.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers.TurnosController
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurnosController : ControllerBase
    {
        // Simulamos una base de datos en memoria por ahora
        private static List<Turnos> turnos = new List<Turnos>();

        // GET: api/turnos (Obtener todos los turnos)
        [HttpGet]
        public ActionResult<List<Turnos>> Get()
        {
            return Ok(turnos);
        }

        // GET: api/turnos/{id} (Obtener un turno específico por ID)
        [HttpGet("{id}")]
        public ActionResult<Turnos> Get(int id)
        {
            var turno = turnos.FirstOrDefault(t => t.Turno_ID == id);
            if (turno == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el turno
            }
            return Ok(turno);
        }

        // POST: api/turnos (Alta de un nuevo turno)
        [HttpPost]
        public ActionResult<Turnos> Post([FromBody] Turnos nuevoTurno)
        {
            nuevoTurno.Turno_ID = turnos.Count + 1; // Simulación de ID auto-generado
            turnos.Add(nuevoTurno);
            return CreatedAtAction(nameof(Get), new { id = nuevoTurno.Turno_ID }, nuevoTurno);
        }

        // PUT: api/turnos/{id} (Modificar un turno existente)
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Turnos turnoModificado)
        {
            var turno = turnos.FirstOrDefault(t => t.Turno_ID == id);
            if (turno == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el turno
            }

            // Actualizamos los datos del turno
            turno.Admin_ID = turnoModificado.Admin_ID;
            turno.Cancha_ID = turnoModificado.Cancha_ID;
            turno.HoraInicio = turnoModificado.HoraInicio;
            turno.HoraFin = turnoModificado.HoraFin;
            turno.Consumicion_ID = turnoModificado.Consumicion_ID;
            turno.UpdatedDate = DateTime.Now;

            return NoContent(); // Devuelve 204 No Content
        }

        // DELETE: api/turnos/{id} (Eliminar un turno)
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var turno = turnos.FirstOrDefault(t => t.Turno_ID == id);
            if (turno == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el turno
            }

            turnos.Remove(turno);
            return NoContent(); // Devuelve 204 No Content
        }
    }
}
