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

        public ProyectoDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-4U7JAH5\\SQLEXPRESS;Database=SportsTimeDB;Trusted_Connection=True;Encrypt=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Canchas>().HasIndex(x => x.Codigo_Deporte);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var createdDateProp = entity.FindProperty("CreatedDate");
                if (createdDateProp != null)
                {
                    createdDateProp.SetDefaultValueSql("GETDATE()");
                }

                var updatedDateProp = entity.FindProperty("UpdatedDate");
                if (updatedDateProp != null)
                {
                    updatedDateProp.SetValueConverter(new ValueConverter<DateTime?, DateTime?>(
                        v => v.HasValue ? v.Value : null,
                        v => v.HasValue ? v.Value : null));
                }
            }

            DisableCascadingDelete(modelBuilder); // Deshabilitar eliminación en cascada
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.DoCustomEntityPreparations();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            this.DoCustomEntityPreparations();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void DoCustomEntityPreparations()
        {
            var modifiedEntitiesWithTrackDate = this
                .ChangeTracker.Entries()
                .Where(c => c.State == EntityState.Modified);

            foreach (var entityEntry in modifiedEntitiesWithTrackDate)
            {
                if (entityEntry.Properties.Any(c => c.Metadata.Name == "UpdatedDate"))
                {
                    entityEntry.Property("UpdatedDate").CurrentValue = DateTime.Now;
                }
            }
        }

        private void DisableCascadingDelete(ModelBuilder modelBuilder)
        {
            var relationships = modelBuilder
                .Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys());

            foreach (var relationship in relationships)
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}



