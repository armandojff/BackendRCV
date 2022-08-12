using administrador.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
namespace administrador.Persistence.Database
{
    public class RCVDbContext : DbContext, IRCVDbContext
    {
        public RCVDbContext()
        {
        }

        public RCVDbContext(DbContextOptions<RCVDbContext> options) : base(options)
        {
        }
        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*API FLUENTE PRIMARY KEY*/
            modelBuilder.HasPostgresExtension("uuid-ossp");
            modelBuilder.Entity<AseguradoEntity>()
                .HasKey(p => p.ci);
            modelBuilder.Entity<CarrosEntity>()
                .HasKey(p => p.placa);
            modelBuilder.Entity<IncidentesEntity>()
                .Property(registro => registro.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()")    // Use 
                .IsRequired();
            modelBuilder.Entity<PolizaEntity>()
                .Property(registro => registro.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()")    // Use 
                .IsRequired();
            modelBuilder.Entity<UsuariosEntity>()
                .Property(dni => dni.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()")    // Use 
                .IsRequired();
            modelBuilder.Entity<MarcaEntity>()
                .Property(p => p.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()")    // Use 
                .IsRequired();
            modelBuilder.Entity<PagosEntity>()
                .Property(p => p.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()")    // Use 
                .IsRequired();
        }
        
        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
        public virtual DbSet<AseguradoEntity> asegurado { get; set; }
        public virtual DbSet<CarrosEntity> cars { get; set; }
        public virtual DbSet<IncidentesEntity> incident { get; set; }
        public virtual DbSet<PolizaEntity> poliza { get; set; }
        public virtual DbSet<UsuariosEntity> user { get; set; }
        public virtual DbSet<MarcaEntity> marca { get; set; }
        public virtual DbSet<PagosEntity> pagos { get; set; }
    }
}