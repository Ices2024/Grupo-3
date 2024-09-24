using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Shared.Entidades;

namespace API.Controllers.DeportesController
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeportesController : ControllerBase
    {
        // Simulamos una base de datos en memoria para los deportes
        private static List<Deportes> deportes = new List<Deportes>();

        // GET: api/deportes (Obtener todos los deportes)
        [HttpGet]
        public ActionResult<List<Deportes>> Get()
        {
            return Ok(deportes);
        }

        // GET: api/deportes/{id} (Obtener un deporte específico por ID)
        [HttpGet("{id}")]
        public ActionResult<Deportes> Get(int id)
        {
            var deporte = deportes.FirstOrDefault(d => d.Deporte_ID == id);
            if (deporte == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el deporte
            }
            return Ok(deporte);
        }

        // POST: api/deportes (Alta de un nuevo deporte)
        [HttpPost]
        public ActionResult<Deportes> Post([FromBody] Deportes nuevoDeporte)
        {
            nuevoDeporte.Deporte_ID = deportes.Count + 1; // Simulación de ID auto-generado
            deportes.Add(nuevoDeporte);
            return CreatedAtAction(nameof(Get), new { id = nuevoDeporte.Deporte_ID }, nuevoDeporte);
        }

        // PUT: api/deportes/{id} (Modificar un deporte existente)
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Deportes deporteModificado)
        {
            var deporte = deportes.FirstOrDefault(d => d.Deporte_ID == id);
            if (deporte == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el deporte
            }

            // Actualizamos los datos del deporte
            deporte.Tipo = deporteModificado.Tipo;
            deporte.UpdatedDate = DateTime.Now;

            return NoContent(); // Devuelve 204 No Content
        }

        // DELETE: api/deportes/{id} (Eliminar un deporte)
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var deporte = deportes.FirstOrDefault(d => d.Deporte_ID == id);
            if (deporte == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el deporte
            }

            deportes.Remove(deporte);
            return NoContent(); // Devuelve 204 No Content
        }
    }
}
