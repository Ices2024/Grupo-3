using Microsoft.AspNetCore.Mvc;
using Shared.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers.CanchasController
{
    [ApiController]
    [Route("api/[controller]")]
    public class CanchasController : ControllerBase
    {
        // Simulamos una base de datos en memoria para las canchas
        private static List<Canchas> canchas = new List<Canchas>();

        // GET: api/canchas (Obtener todas las canchas)
        [HttpGet]
        public ActionResult<List<Canchas>> Get()
        {
            return Ok(canchas);
        }

        // GET: api/canchas/{id} (Obtener una cancha específica por ID)
        [HttpGet("{id}")]
        public ActionResult<Canchas> Get(int id)
        {
            var cancha = canchas.FirstOrDefault(c => c.Cancha_ID == id);
            if (cancha == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra la cancha
            }
            return Ok(cancha);
        }

        // POST: api/canchas (Alta de una nueva cancha)
        [HttpPost]
        public ActionResult<Canchas> Post([FromBody] Canchas nuevaCancha)
        {
            nuevaCancha.Cancha_ID = canchas.Count + 1; // Simulación de ID auto-generado
            canchas.Add(nuevaCancha);
            return CreatedAtAction(nameof(Get), new { id = nuevaCancha.Cancha_ID }, nuevaCancha);
        }

        // PUT: api/canchas/{id} (Modificar una cancha existente)
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Canchas canchaModificada)
        {
            var cancha = canchas.FirstOrDefault(c => c.Cancha_ID == id);
            if (cancha == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra la cancha
            }

            // Actualizamos los datos de la cancha
            cancha.Codigo_Deporte = canchaModificada.Codigo_Deporte;
            cancha.Deporte = canchaModificada.Deporte;
            cancha.UpdatedDate = DateTime.Now;

            return NoContent(); // Devuelve 204 No Content
        }

        // DELETE: api/canchas/{id} (Eliminar una cancha)
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var cancha = canchas.FirstOrDefault(c => c.Cancha_ID == id);
            if (cancha == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra la cancha
            }

            canchas.Remove(cancha);
            return NoContent(); // Devuelve 204 No Content
        }
    }
}
