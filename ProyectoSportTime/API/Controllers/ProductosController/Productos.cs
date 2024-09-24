using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Shared.Entidades;

namespace API.Controllers.ProductosController
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        // Simulamos una base de datos en memoria para los productos
        private static List<Productos> productos = new List<Productos>();

        // GET: api/productos (Obtener todos los productos)
        [HttpGet]
        public ActionResult<List<Productos>> Get()
        {
            return Ok(productos);
        }

        // GET: api/productos/{id} (Obtener un producto específico por ID)
        [HttpGet("{id}")]
        public ActionResult<Productos> Get(int id)
        {
            var producto = productos.FirstOrDefault(p => p.Producto_ID == id);
            if (producto == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el producto
            }
            return Ok(producto);
        }

        // POST: api/productos (Alta de un nuevo producto)
        [HttpPost]
        public ActionResult<Productos> Post([FromBody] Productos nuevoProducto)
        {
            nuevoProducto.Producto_ID = productos.Count + 1; // Simulación de ID auto-generado
            productos.Add(nuevoProducto);
            return CreatedAtAction(nameof(Get), new { id = nuevoProducto.Producto_ID }, nuevoProducto);
        }

        // PUT: api/productos/{id} (Modificar un producto existente)
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Productos productoModificado)
        {
            var producto = productos.FirstOrDefault(p => p.Producto_ID == id);
            if (producto == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el producto
            }

            // Actualizamos los datos del producto
            producto.Tipo = productoModificado.Tipo;
            producto.Descripcion = productoModificado.Descripcion;
            producto.Proveedor_ID = productoModificado.Proveedor_ID;
            producto.UpdatedDate = DateTime.Now;

            return NoContent(); // Devuelve 204 No Content
        }

        // DELETE: api/productos/{id} (Eliminar un producto)
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var producto = productos.FirstOrDefault(p => p.Producto_ID == id);
            if (producto == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el producto
            }

            productos.Remove(producto);
            return NoContent(); // Devuelve 204 No Content
        }
    }
}