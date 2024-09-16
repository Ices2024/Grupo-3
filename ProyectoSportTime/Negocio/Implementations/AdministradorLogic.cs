using Microsoft.EntityFrameworkCore;
using Negocio.Contracts;
using Shared.Dtos;
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
        public void AltaAdministrador(string nombre, string email)
        {
            using (var context = new ProyectoDbContext())
            {
                var nuevoAdmin = new Administrador
                {
                    Nombre = nombre,
                    Email = email
                };
                context.Administradores.Add(nuevoAdmin);
                context.SaveChanges();
            }
        }

        public void ModificarAdministrador(int adminID, string nuevoNombre, string nuevoEmail)
        {
            using (var context = new ProyectoDbContext())
            {
                var admin = context.Administradores.Find(adminID);
                if (admin != null)
                {
                    admin.Nombre = nuevoNombre;
                    admin.Email = nuevoEmail;
                    context.SaveChanges();
                }
            }
        }

        public void BajaAdministrador(int adminID)
        {
            using (var context = new ProyectoDbContext())
            {
                var admin = context.Administradores.Find(adminID);
                if (admin != null)
                {
                    context.Administradores.Remove(admin);
                    context.SaveChanges();
                }
            }
        }
    }

}
