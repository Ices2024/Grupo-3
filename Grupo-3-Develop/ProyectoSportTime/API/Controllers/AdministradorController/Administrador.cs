using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers.AdministradorController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        private readonly IInterfaceAdministrador _adminLogic;

        public AdministradorController(IInterfaceAdministrador adminLogic)
        {
            _adminLogic = adminLogic;
        }

        [HttpPost]
        public IActionResult AltaAdministrador([FromBody] CrearAdministradorDTO nuevoAdminDto)
        {
            _adminLogic.AltaAdministrador(nuevoAdminDto.Nombre, nuevoAdminDto.Email);
            return CreatedAtAction(nameof(GetAdministrador), new { id = nuevoAdminDto.Id }, nuevoAdminDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetAdministrador(int id)
        {
            var admin = // lógica para obtener el administrador por ID
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

}
