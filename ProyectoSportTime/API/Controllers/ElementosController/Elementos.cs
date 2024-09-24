using Microsoft.AspNetCore.Mvc;
using Shared.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers.ElementosController
{
    [ApiController]
    [Route("api/[controller]")]
    public class ElementosController : ControllerBase
    {
        // Simulamos una base de datos en memoria para los elementos
        private static List<Elementos> elementos = new List<Elementos>();

        // GET: api/elementos (Obtener todos los elementos)
        [HttpGet]
        public ActionResult<List<Elementos>> Get()
        {
            return Ok(elementos);
        }

        // GET: api/elementos/{id} (Obtener un elemento específico por ID)
        [HttpGet("{id}")]
        public ActionResult<ElementosController> Get(int id)
        {
            var elemento = elementos.FirstOrDefault(e => e.Elemento_ID == id);
            if (elemento == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el elemento
            }
            return Ok(elemento);
        }

        // POST: api/elementos (Alta de un nuevo elemento)
        [HttpPost]
        public ActionResult<Elementos> Post([FromBody] Elementos nuevoElemento)
        {
            nuevoElemento.Elemento_ID = elementos.Count + 1; // Simulación de ID auto-generado
            elementos.Add(nuevoElemento);
            return CreatedAtAction(nameof(Get), new { id = nuevoElemento.Elemento_ID }, nuevoElemento);
        }

        // PUT: api/elementos/{id} (Modificar un elemento existente)
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Elementos elementoModificado)
        {
            var elemento = elementos.FirstOrDefault(e => e.Elemento_ID == id);
            if (elemento == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el elemento
            }

            // Actualizamos los datos del elemento
            elemento.Nombre = elementoModificado.Nombre;
            elemento.Cantidad = elementoModificado.Cantidad;
            elemento.UpdatedDate = DateTime.Now;

            return NoContent(); // Devuelve 204 No Content
        }

        // DELETE: api/elementos/{id} (Eliminar un elemento)
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var elemento = elementos.FirstOrDefault(e => e.Elemento_ID == id);
            if (elemento == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el elemento
            }

            elementos.Remove(elemento);
            return NoContent(); // Devuelve 204 No Content
        }
    }
}
