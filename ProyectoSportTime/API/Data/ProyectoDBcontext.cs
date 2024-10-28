using Microsoft.EntityFrameworkCore;
using Shared.Entidades;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.Design;


namespace API.Data
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

        public ProyectoDbContext(DbContextOptions<ProyectoDbContext> options)
            : base(options) { }

        // Configuraciones del modelo
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Deshabilitar eliminación en cascada
            DisableCascadingDelete(modelBuilder);
        }

        // Guardar cambios de forma asíncrona
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void DisableCascadingDelete(ModelBuilder modelBuilder)
        {
            var relationships = modelBuilder
                .Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys());

            foreach (var relationship in relationships)
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict; // Configurar comportamiento de eliminación
            }
        }
    }

}



