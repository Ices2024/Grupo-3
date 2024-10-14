using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos;
using Shared.Entidades;
using System.Collections.Generic;
using System.Linq;
using BCrypt.Net;



namespace API.Controllers.AdministradorController
{

    [ApiController]
    [Route("api/[controller]")]
    public class AdministradorController : ControllerBase
    {
        // Simulamos un administrador único en memoria
        private static AdministradorDTO administrador = new AdministradorDTO
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
            // Verificamos el email y la contraseña
            if (administrador.Email == loginDto.Email && BCrypt.Net.BCrypt.Verify(loginDto.Password, administrador.PasswordHash))
            {
                administrador.LastLogin = DateTime.Now; // Actualizamos el último login

                // Aquí deberías generar y devolver un token JWT o algo similar para autenticar futuras solicitudes.
                return Ok(new { message = "Login successful", lastLogin = administrador.LastLogin });
            }
            return Unauthorized(new { message = "Invalid credentials" });
        }

        // GET: api/administrador (Obtener los datos del administrador)
        [HttpGet]
        public ActionResult<AdministradorDTO> Get()
        {
            // Retornamos los datos del administrador
            return Ok(administrador);
        }

        // PUT: api/administrador (Actualizar los datos del administrador)
        [HttpPut]
        public ActionResult Update([FromBody] AdministradorDTO updatedAdmin)
        {
            // Aquí actualizamos solo los campos permitidos del administrador
            administrador.Nombre = updatedAdmin.Nombre;
            administrador.Email = updatedAdmin.Email;

            // Si se desea actualizar la contraseña, debemos encriptarla
            if (!string.IsNullOrEmpty(updatedAdmin.PasswordHash))
            {
                administrador.PasswordHash = BCrypt.Net.BCrypt.HashPassword(updatedAdmin.PasswordHash);
            }

            administrador.LastLogin = updatedAdmin.LastLogin; // Actualizamos la fecha de login
            return NoContent();
        }

        // DELETE: api/administrador (Eliminar al administrador)
        // En este caso, como es un único administrador, esta acción puede no ser necesaria
        // pero si quieres implementarla, sería algo así:
        [HttpDelete]
        public ActionResult Delete()
        {
            administrador = null; // Simulamos la eliminación del administrador
            return NoContent();
        }
    }
}
