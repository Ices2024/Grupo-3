using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Shared.Entidades;

namespace API.Controllers.ConsumicionController
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsumicionesController : ControllerBase
    {
        // Simulamos una base de datos en memoria para las consumiciones
        private static List<Consumiciones> consumiciones = new List<Consumiciones>();

        // GET: api/consumiciones (Obtener todas las consumiciones)
        [HttpGet]
        public ActionResult<List<Consumiciones>> Get()
        {
            return Ok(consumiciones);
        }

        // GET: api/consumiciones/{id} (Obtener una consumición específica por ID)
        [HttpGet("{id}")]
        public ActionResult<Consumiciones> Get(int id)
        {
            var consumicion = consumiciones.FirstOrDefault(c => c.Consumicion_ID == id);
            if (consumicion == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra la consumición
            }
            return Ok(consumicion);
        }

        // POST: api/consumiciones (Alta de una nueva consumición)
        [HttpPost]
        public ActionResult<Consumiciones> Post([FromBody] Consumiciones nuevaConsumicion)
        {
            nuevaConsumicion.Consumicion_ID = consumiciones.Count + 1; // Simulación de ID auto-generado
            consumiciones.Add(nuevaConsumicion);
            return CreatedAtAction(nameof(Get), new { id = nuevaConsumicion.Consumicion_ID }, nuevaConsumicion);
        }

        // PUT: api/consumiciones/{id} (Modificar una consumición existente)
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Consumiciones consumicionModificada)
        {
            var consumicion = consumiciones.FirstOrDefault(c => c.Consumicion_ID == id);
            if (consumicion == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra la consumición
            }

            // Actualizamos los datos de la consumición
            consumicion.Cantidad = consumicionModificada.Cantidad;
            consumicion.Precio = consumicionModificada.Precio;
            consumicion.Cod_Producto = consumicionModificada.Cod_Producto;
            consumicion.UpdatedDate = DateTime.Now;

            return NoContent(); // Devuelve 204 No Content
        }

        // DELETE: api/consumiciones/{id} (Eliminar una consumición)
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var consumicion = consumiciones.FirstOrDefault(c => c.Consumicion_ID == id);
            if (consumicion == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra la consumición
            }

            consumiciones.Remove(consumicion);
            return NoContent(); // Devuelve 204 No Content
        }
    }
}