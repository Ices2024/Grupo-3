using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos;
using Shared.Entidades;
using System.Collections.Generic;
using System.Linq;
using BCrypt.Net;
using API.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace API.Controllers.AdministradorController
{

    [ApiController]
    [Route("api/[controller]")]
    public class AdministradorController : ControllerBase
    {
        private readonly ProyectoDbContext _context;

        public AdministradorController(ProyectoDbContext context)
        {
            _context = context;
        }

        // Definimos un administrador en memoria para simular uno único (esto es sólo para ejemplo)
        private static AdministradorDTO? administrador = new AdministradorDTO
        {
            Admin_ID = 1,
            Nombre = "Admin",
            Email = "admin@example.com",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("password123"), // Hash de la contraseña para seguridad
            LastLogin = DateTime.Now,
            IsSuperAdmin = true
        };

        // POST: api/administrador/login (Autenticación del administrador)
        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDTO loginDto)
        {
            // Consultar el administrador por su email
            var administrador = _context.Administradores.FirstOrDefault(a => a.Email == loginDto.Email);

            // Verificamos el email y la contraseña
            if (administrador != null && BCrypt.Net.BCrypt.Verify(loginDto.Password, administrador.Contraseña))
            {
                _context.SaveChanges(); // Guardar cambios si hay alguno, aunque aquí no afecta nada sin UpdatedDate

                // Devolver un mensaje de éxito
                return Ok(new { message = "Login successful" });
            }
            return Unauthorized(new { message = "Invalid credentials" });
        }

        // GET: api/administrador (Obtener los datos del administrador)
        [HttpGet]
        public ActionResult<AdministradorDTO> Get()
        {
            return Ok(administrador);
        }

        // PUT: api/administrador (Actualizar los datos del administrador)
        [HttpPut]
        public ActionResult Update([FromBody] AdministradorDTO updatedAdmin)
        {
            // Actualizamos solo los campos permitidos
            if (administrador != null) // Verifica que el administrador exista antes de actualizar
            {
                administrador.Nombre = updatedAdmin.Nombre;
                administrador.Email = updatedAdmin.Email;

                // Si se desea actualizar la contraseña, la encriptamos
                if (!string.IsNullOrEmpty(updatedAdmin.PasswordHash))
                {
                    administrador.PasswordHash = BCrypt.Net.BCrypt.HashPassword(updatedAdmin.PasswordHash);
                }

                administrador.LastLogin = updatedAdmin.LastLogin; // Actualizamos el último login
                return NoContent(); // No contenido, porque la actualización fue exitosa
            }
            return NotFound(new { message = "Administrador no encontrado" });
        }


        // DELETE: api/administrador (Eliminar al administrador)
        [HttpDelete]
        public ActionResult Delete()
        {
            administrador = null; // Simulamos la eliminación del administrador
            return NoContent();
        }
    }
}

