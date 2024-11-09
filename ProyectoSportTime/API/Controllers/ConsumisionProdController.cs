using API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos;
using Shared.Entidades;

namespace API.Controllers
{
 
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumisionProdController : ControllerBase
    {
        private readonly ProyectoDbContext _context;

        public ConsumisionProdController(ProyectoDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] ConsumicionProductoDTO consumicionDTO)
        {
            var existProduct = await _context.Productos.AnyAsync(p => p.Producto_ID == consumicionDTO.Producto_ID);
            var existConsumicion = await _context.Consumiciones.AnyAsync(c => c.Consumicion_ID == consumicionDTO.Producto_ID);

            if (existConsumicion && existProduct)
            {

                var consProduct = new ConsumicionProducto
                {
                    Consumicion_ID = consumicionDTO.Consumicion_ID,
                    Producto_ID = consumicionDTO.Producto_ID
                };

                _context.consumicionProductos.Add(consProduct);
                await _context.SaveChangesAsync();
                return Ok("AL toke mi rei");
            }
            return NotFound("La consumision o el producto seleccionado no existe");
        }
    }
}
