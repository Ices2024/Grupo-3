using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace SportsTime
{
    public class ProyectoDBcontext : DbContext
    {
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Canchas> Canchas { get; set; }
        public DbSet<Consumiciones> Consumiciones { get; set; }
        public DbSet<Deportes> Deportes { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Turnos> Turnos { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Elementos> Elementos { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = LAPTOP-TI84IK3Q\\SQLEXPRESS; database = SportsTimeDB; trusted_connection = true; Encrypt = False");
        }
    }
}
