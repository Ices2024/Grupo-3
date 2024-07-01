using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Shared.Entities
{
    public class SportsTimeDBcontext : DbContext
    {
        public DbSet<Administrador> Administradores { get; set;}
        public DbSet<Cancha> Cachas { get; set;}
        public DbSet<Cliente> Clientes { get; set;}
        public DbSet<Consumicion> Consumiciones { get; set;}
        public DbSet<Deporte> Deportes { get; set;}
        public DbSet<Producto> Productos { get; set;}
        public DbSet<Turnos> Turnos { get; set;}

        protected override void OnConfiguring(SportsTimeDBcontext optionsBuilder)
        {
            optionsBuilder.UseSqlServer(&quot; server = COMPUT025521\\SQLEXPRESS; database = Mati01; trusted_connection = true; Encrypt = False & quot;);
        }
    }
}
