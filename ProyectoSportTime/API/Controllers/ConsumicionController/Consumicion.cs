using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Shared.Entidades;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos;

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
        public async Task<ActionResult<List<ConsumicionDTO>>> Get()
        {
            var consumiciones = await _context.Consumiciones.ToListAsync();
            var consumicionDtos = consumiciones.Select(c => new ConsumicionDTO
            {
                Consumicion_ID = c.Consumicion_ID,
                Cantidad = c.Cantidad,
                Precio = c.Precio,
                Cod_Producto = c.Cod_Producto
            }).ToList();

            return Ok(consumicionDtos);
        }

        // GET: api/consumiciones/{id} (Obtener una consumición específica por ID)
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsumicionDTO>> Get(int id)
        {
            var consumicion = await _context.Consumiciones.FindAsync(id);
            if (consumicion == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra la consumición
            }

            var consumicionDto = new ConsumicionDTO
            {
                Consumicion_ID = consumicion.Consumicion_ID,
                Cantidad = consumicion.Cantidad,
                Precio = consumicion.Precio,
                Cod_Producto = consumicion.Cod_Producto
            };

            return Ok(consumicionDto);
        }

        // POST: api/consumiciones (Alta de una nueva consumición)
        [HttpPost]
        public async Task<ActionResult<ConsumicionDTO>> Post([FromBody] ConsumicionDTO nuevaConsumicionDto)
        {
            var nuevaConsumicion = new Consumiciones
            {
                Cantidad = nuevaConsumicionDto.Cantidad,
                Precio = nuevaConsumicionDto.Precio,
                Cod_Producto = nuevaConsumicionDto.Cod_Producto
            };

            _context.Consumiciones.Add(nuevaConsumicion);
            await _context.SaveChangesAsync();

            nuevaConsumicionDto.Consumicion_ID = nuevaConsumicion.Consumicion_ID; // Asignar el ID generado al DTO

            return CreatedAtAction(nameof(Get), new { id = nuevaConsumicion.Consumicion_ID }, nuevaConsumicionDto);
        }

        // PUT: api/consumiciones/{id} (Modificar una consumición existente)
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ConsumicionDTO consumicionModificadaDto)
        {
            var consumicion = await _context.Consumiciones.FindAsync(id);
            if (consumicion == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra la consumición
            }

            // Actualizamos los datos de la consumición
            consumicion.Cantidad = consumicionModificadaDto.Cantidad;
            consumicion.Precio = consumicionModificadaDto.Precio;
            consumicion.Cod_Producto = consumicionModificadaDto.Cod_Producto; // Asegúrate de que esto exista en tu modelo

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