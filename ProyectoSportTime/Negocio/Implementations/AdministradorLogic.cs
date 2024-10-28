using API.Data;
using Microsoft.EntityFrameworkCore;
using Negocio.Contracts;
using Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Implementations
{
    public class AdministradorLogic : InterfaceAdministrador
    {
        private readonly ProyectoDbContext _context;

        // Constructor donde se inyecta el DbContext
        public AdministradorLogic(ProyectoDbContext context)
        {
            _context = context;
        }

        public void AltaAdministrador(string nombre, string email)
        {
            var nuevoAdmin = new Administrador
            {
                Nombre = nombre,
                Email = email
            };
            _context.Administradores.Add(nuevoAdmin);
            _context.SaveChanges();
        }

        public void ModificarAdministrador(int adminID, string nuevoNombre, string nuevoEmail)
        {
            var admin = _context.Administradores.Find(adminID);
            if (admin == null)
            {
                throw new Exception($"El administrador con ID {adminID} no fue encontrado.");
            }

            admin.Nombre = nuevoNombre;
            admin.Email = nuevoEmail;
            _context.SaveChanges();
        }

        public void BajaAdministrador(int adminID)
        {
            var admin = _context.Administradores.Find(adminID);
            if (admin == null)
            {
                throw new Exception($"El administrador con ID {adminID} no fue encontrado.");
            }

            _context.Administradores.Remove(admin);
            _context.SaveChanges();
        }
    }

}

