using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using Shared.Entidades;

namespace API.Controllers.ProveedoresController
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProveedoresController : ControllerBase
    {
        // Simulamos una base de datos en memoria para los proveedores
        private static List<Proveedores> proveedores = new List<Proveedores>();

        // GET: api/proveedores (Obtener todos los proveedores)
        [HttpGet]
        public ActionResult<List<ProveedorDTO>> Get()
        {
            var proveedorDTO = proveedores.Select(p => new ProveedorDTO
            {
                Proveedor_ID = p.Proveedor_ID,
                Nombre = p.Nombre,
                Telefono = p.Telefono,
                Email = p.Email,
                Productos = p.Productos?.Select(prod => new ProductoDTO
                {
                    Producto_ID = prod.Producto_ID,
                    Tipo = prod.Tipo,
                    Descripcion = prod.Descripcion
                }).ToList()
            }).ToList();

            return Ok(proveedorDTO);
        }

        // GET: api/proveedores/{id} (Obtener un proveedor específico por ID)
        [HttpGet("{id}")]
        public ActionResult<ProveedorDTO> Get(int id)
        {
            var proveedor = proveedores.FirstOrDefault(p => p.Proveedor_ID == id);
            if (proveedor == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el proveedor
            }

            var proveedorDTO = new ProveedorDTO
            {
                Proveedor_ID = proveedor.Proveedor_ID,
                Nombre = proveedor.Nombre,
                Telefono = proveedor.Telefono,
                Email = proveedor.Email,
                Productos = proveedor.Productos?.Select(prod => new ProductoDTO
                {
                    Producto_ID = prod.Producto_ID,
                    Tipo = prod.Tipo,
                    Descripcion = prod.Descripcion
                }).ToList()
            };

            return Ok(proveedorDTO);
        }

        // POST: api/proveedores (Alta de un nuevo proveedor)
        [HttpPost]
        public ActionResult<ProveedorDTO> Post([FromBody] ProveedorDTO nuevoProveedorDTO)
        {
            var nuevoProveedor = new Proveedores
            {
                Proveedor_ID = proveedores.Count + 1, // Simulación de ID auto-generado
                Nombre = nuevoProveedorDTO.Nombre,
                Telefono = nuevoProveedorDTO.Telefono,
                Email = nuevoProveedorDTO.Email,
                Productos = nuevoProveedorDTO.Productos?.Select(prod => new Productos
                {
                    Producto_ID = prod.Producto_ID,
                    Tipo = prod.Tipo,
                    Descripcion = prod.Descripcion
                }).ToList()
            };

            proveedores.Add(nuevoProveedor);

            return CreatedAtAction(nameof(Get), new { id = nuevoProveedor.Proveedor_ID }, nuevoProveedorDTO);
        }

        // PUT: api/proveedores/{id} (Modificar un proveedor existente)
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ProveedorDTO proveedorModificadoDTO)
        {
            var proveedor = proveedores.FirstOrDefault(p => p.Proveedor_ID == id);
            if (proveedor == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el proveedor
            }

            // Actualizamos los datos del proveedor
            proveedor.Nombre = proveedorModificadoDTO.Nombre;
            proveedor.Telefono = proveedorModificadoDTO.Telefono;
            proveedor.Email = proveedorModificadoDTO.Email;
            proveedor.Productos = proveedorModificadoDTO.Productos?.Select(prod => new Productos
            {
                Producto_ID = prod.Producto_ID,
                Tipo = prod.Tipo,
                Descripcion = prod.Descripcion
            }).ToList();

            return NoContent(); // Devuelve 204 No Content
        }

        // DELETE: api/proveedores/{id} (Eliminar un proveedor)
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var proveedor = proveedores.FirstOrDefault(p => p.Proveedor_ID == id);
            if (proveedor == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el proveedor
            }

            proveedores.Remove(proveedor);
            return NoContent(); // Devuelve 204 No Content
        }
    }

}
