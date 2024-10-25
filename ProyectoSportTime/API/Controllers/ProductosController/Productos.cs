using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Shared.Entidades;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos;

namespace API.Controllers.ProductosController
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProveedoresController : ControllerBase
    {
        private readonly ProyectoDbContext _context;

        // Constructor donde se inyecta el DbContext
        public ProveedoresController(ProyectoDbContext context)
        {
            _context = context;
        }

        // GET: api/proveedores (Obtener todos los proveedores)
        [HttpGet]
        public async Task<ActionResult<List<ProveedorDTO>>> Get()
        {
            var proveedores = await _context.Proveedores
                .Include(p => p.Productos) // Incluye los productos relacionados
                .ToListAsync();

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
        public async Task<ActionResult<ProveedorDTO>> Get(int id)
        {
            var proveedor = await _context.Proveedores
                .Include(p => p.Productos) // Incluye los productos relacionados
                .FirstOrDefaultAsync(p => p.Proveedor_ID == id);

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
        public async Task<ActionResult<ProveedorDTO>> Post([FromBody] ProveedorDTO nuevoProveedorDTO)
        {
            var nuevoProveedor = new Proveedores
            {
                Nombre = nuevoProveedorDTO.Nombre,
                Telefono = nuevoProveedorDTO.Telefono,
                Email = nuevoProveedorDTO.Email,
                Productos = nuevoProveedorDTO.Productos?.Select(prod => new Productos
                {
                    Tipo = prod.Tipo,
                    Descripcion = prod.Descripcion
                }).ToList()
            };

            _context.Proveedores.Add(nuevoProveedor);
            await _context.SaveChangesAsync();

            nuevoProveedorDTO.Proveedor_ID = nuevoProveedor.Proveedor_ID; // Asignar ID auto-generado

            return CreatedAtAction(nameof(Get), new { id = nuevoProveedor.Proveedor_ID }, nuevoProveedorDTO);
        }

        // PUT: api/proveedores/{id} (Modificar un proveedor existente)
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProveedorDTO proveedorModificadoDTO)
        {
            var proveedor = await _context.Proveedores
                .Include(p => p.Productos) // Incluye los productos relacionados
                .FirstOrDefaultAsync(p => p.Proveedor_ID == id);

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
                Producto_ID = prod.Producto_ID, // Esto debe ser manejado si estás actualizando productos existentes
                Tipo = prod.Tipo,
                Descripcion = prod.Descripcion
            }).ToList();

            await _context.SaveChangesAsync();

            return NoContent(); // Devuelve 204 No Content
        }

        // DELETE: api/proveedores/{id} (Eliminar un proveedor)
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);
            if (proveedor == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el proveedor
            }

            _context.Proveedores.Remove(proveedor);
            await _context.SaveChangesAsync();

            return NoContent(); // Devuelve 204 No Content
        }
    }
}