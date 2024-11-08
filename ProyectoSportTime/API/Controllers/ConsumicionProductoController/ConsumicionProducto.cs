using API.Data;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using Shared.Entidades;



namespace API.Controllers.ConsumicionProductoController
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsumicionProductoController : ControllerBase
    {
        private readonly ProyectoDbContext _context;

        // Constructor donde se inyecta el DbContext
        public ConsumicionProductoController(ProyectoDbContext context)
        {
            _context = context;
        }

        // GET: api/consumicionproducto/{consumicionId} (Obtener todos los productos de una consumición)
        [HttpGet("{consumicionId}")]
        public async Task<ActionResult<List<ProductoDTO>>> GetProductosByConsumicion(int consumicionId)
        {
            var consumicion = await _context.Consumiciones
                .Include(c => c.Productos)  // Cargamos los productos asociados
                .FirstOrDefaultAsync(c => c.Consumicion_ID == consumicionId);

            if (consumicion == null)
            {
                return NotFound(); // Si no encontramos la consumición
            }

            var productosDto = consumicion.Productos.Select(p => new ProductoDTO
            {
                Producto_ID = p.Producto_ID,
                Tipo = p.Tipo,
                Descripcion = p.Descripcion,
                Proveedor_ID = p.Proveedor_ID
            }).ToList();

            return Ok(productosDto);
        }

        // POST: api/consumicionproducto (Añadir productos a una consumición)
        [HttpPost]
        public async Task<ActionResult> AddProductosToConsumicion([FromBody] ConsumicionProductoDTO consumicionProductoDto)
        {
            var consumicion = await _context.Consumiciones.FindAsync(consumicionProductoDto.Consumicion_ID);
            if (consumicion == null)
            {
                return NotFound("Consumición no encontrada");
            }

            var productos = await _context.Productos
                .Where(p => consumicionProductoDto.Producto_IDs.Contains(p.Producto_ID))
                .ToListAsync();

            if (productos.Count != consumicionProductoDto.Producto_IDs.Count)
            {
                return BadRequest("Algunos productos no existen.");
            }

            var nuevosProductos = productos.Select(p => new ConsumicionProducto
            {
                Consumicion_ID = consumicionProductoDto.Consumicion_ID,
                Producto_ID = p.Producto_ID
            }).ToList();

            _context.ConsumicionProductos.AddRange(nuevosProductos);
            await _context.SaveChangesAsync();

            return NoContent(); // Devuelve 204 No Content
        }

        // DELETE: api/consumicionproducto/{consumicionId}/{productoId} (Eliminar un producto de una consumición)
        [HttpDelete("{consumicionId}/{productoId}")]
        public async Task<ActionResult> RemoveProductoFromConsumicion(int consumicionId, int productoId)
        {
            var consumicionProducto = await _context.ConsumicionProductos
                .FirstOrDefaultAsync(cp => cp.Consumicion_ID == consumicionId && cp.Producto_ID == productoId);

            if (consumicionProducto == null)
            {
                return NotFound("Relación no encontrada");
            }

            _context.ConsumicionProductos.Remove(consumicionProducto);
            await _context.SaveChangesAsync();

            return NoContent(); // Devuelve 204 No Content
        }
    }
}
}
