using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Entidades;
using System.Collections.Generic;
using System.Linq;



namespace API.Controllers.AdministradorController
{
    /*[Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        private static List<Administrador> administradores = new List<Administrador>();

        // GET: api/Administradores
        [HttpGet]
        public ActionResult<List<Administrador>> Get()
        {
            return Ok(administradores);
        }

        // GET: api/Administradores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Administrador>> GetAdministrador(int id)
        {
            var administrador = await _context.Administradores.FindAsync(id);

            if (administrador == null)
            {
                return NotFound();
            }

            return administrador;
        }

        // POST: api/Administradores
        [HttpPost]
        public async Task<ActionResult<Administrador>> PostAdministrador(Administrador administrador)
        {
            _context.Administradores.Add(administrador);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAdministrador), new { id = administrador.Admin_ID }, administrador);
        }

        // PUT: api/Administradores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdministrador(int id, Administrador administrador)
        {
            if (id != administrador.Admin_ID)
            {
                return BadRequest();
            }

            _context.Entry(administrador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministradorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Administradores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdministrador(int id)
        {
            var administrador = await _context.Administradores.FindAsync(id);
            if (administrador == null)
            {
                return NotFound();
            }

            _context.Administradores.Remove(administrador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdministradorExists(int id)
        {
            return _context.Administradores.Any(e => e.Admin_ID == id);
        }
    }
}

    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        private readonly InterfaceAdministrador _adminLogic;

        public AdministradorController(InterfaceAdministrador AdminstradorLogic)
        {
            _adminLogic = AdministradorLogic;
        }

        [HttpPost]
        public IActionResult AltaAdministrador([FromBody] CrearAdministradorDTO nuevoAdminDto)
        {
            _adminLogic.AltaAdministrador(nuevoAdminDto.Nombre, nuevoAdminDto.Email);
            return CreatedAtAction(nameof(GetAdministrador), new { id = nuevoAdminDto.Id }, nuevoAdminDto);
        }

        [HttpGet("{id}")]
        public ActionResult<Administrador> Get(int id)
        {
            var admin = administrador.FirstOrDefault(a => a.Admin_ID == id); // lógica para obtener el administrador por ID
            if (admin == null) return NotFound();
            return Ok(admin);
        }

        [HttpPut("{id}")]
        public IActionResult ModificarAdministrador(int id, [FromBody] ModificarAdministradorDTO adminModificarDto)
        {
            _adminLogic.ModificarAdministrador(id, adminModificarDto.NuevoNombre, adminModificarDto.NuevoEmail);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult BajaAdministrador(int id)
        {
            _adminLogic.BajaAdministrador(id);
            return NoContent();
        }
    }
*/
}
