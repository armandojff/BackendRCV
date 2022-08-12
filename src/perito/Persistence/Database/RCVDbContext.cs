using perito.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

using DbContext = Microsoft.EntityFrameworkCore.DbContext;
namespace perito.Persistence.Database
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
            get { return this; }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");

            //Entidad PiezaEntity
            modelBuilder.Entity<PiezaEntity>()
                .Property(piezas => piezas.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()") // Use 
                .IsRequired();
            //Entidad usuarioPeritoEntity
            modelBuilder.Entity<UsuarioPeritoEntity>()
                .Property(peritos => peritos.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()") // Use 
                .IsRequired();
            //Entidad AnalisisEntity
            modelBuilder.Entity<AnalisisEntity>()
                .Property(analisis => analisis.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()") // Use 
                .IsRequired();
            //Entidad DireccionEntity
            modelBuilder.Entity<DireccionEntity>()
                .Property(direccion => direccion.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()") // Use 
                .IsRequired();
            //Fin
        }


        public virtual Microsoft.EntityFrameworkCore.DbSet<PiezaEntity> piezas { get; set; }
        
        public virtual Microsoft.EntityFrameworkCore.DbSet<UsuarioPeritoEntity> peritos
        {
            get; set;
        }

        public virtual Microsoft.EntityFrameworkCore.DbSet<AnalisisEntity> analisis { get; set; }

        public virtual Microsoft.EntityFrameworkCore.DbSet<DireccionEntity> direcciones { get; set; }


    }
}
