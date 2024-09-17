using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared.Entidades;

namespace Shared.Dtos
{
    public class ProyectoDbContext : DbContext
    {
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Canchas> Canchas { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Consumiciones> Consumiciones { get; set; }
        public DbSet<Deportes> Deportes { get; set; }
        public DbSet<Elementos> Elementos { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Turnos> Turnos { get; set; }

        public DbSet<Ejemplo> Ejemplo { get; set; }

        // Constructor sin parámetros para Entity Framework
        public ProyectoDbContext() : base()
        {
        }

        // Constructor que acepta DbContextOptions
        public ProyectoDbContext(DbContextOptions<ProyectoDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Solo se configura aquí si no se pasan opciones desde el constructor
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=PCLEO\\SQLEXPRESS;database=SportsTimeDB;trusted_connection=true;Encrypt=False");
            }
        }
    }
}

