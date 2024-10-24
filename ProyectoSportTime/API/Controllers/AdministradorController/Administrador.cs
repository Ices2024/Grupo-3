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

        // Usamos "context" para mantener consistencia con el resto del proyecto
        private ProyectoDbContext context = new ProyectoDbContext();

        // POST: api/administrador/login (Autenticación del administrador)
        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDTO loginDto)
        {
            // Consultar el administrador por su email
            var administrador = context.Administradores.FirstOrDefault(a => a.Email == loginDto.Email);

            // Verificamos el email y la contraseña
            if (administrador != null && BCrypt.Net.BCrypt.Verify(loginDto.Password, administrador.Contraseña))
            {
                // Actualizamos el campo UpdatedDate con la fecha del login
                administrador.UpdatedDate = DateTime.Now;
                context.SaveChanges(); // No olvides guardar el cambio

                // Devuelve un JSON con el mensaje y la fecha de última actualización (login)
                return Ok(new { message = "Login successful", lastLogin = administrador.UpdatedDate });
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
            // Actualizamos solo los campos permitidos
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

        // DELETE: api/administrador (Eliminar al administrador)
        [HttpDelete]
        public ActionResult Delete()
        {
            administrador = null; // Simulamos la eliminación del administrador
            return NoContent();
        }
    }

}
