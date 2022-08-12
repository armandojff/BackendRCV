using backendRCVUcab.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace backendRCVUcab.Persistence.Database
{
    public class RCVDbContext : DbContext, IRCVDbContext
    {
        public RCVDbContext() { }

        public RCVDbContext(DbContextOptions<RCVDbContext> options) : base(options) { }

        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Generar un uuid cuando creas un registro en una entidad
            //inicio
            modelBuilder.HasPostgresExtension("uuid-ossp");

            //Entidad Proveedor
            modelBuilder.Entity<ProveedorEntity>()
                .Property(proveedor => proveedor.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()")    // Use 
                .IsRequired();

            //Entidad Cotizacion
            modelBuilder.Entity<CotizacionEntity>()
                .Property(cotizacion => cotizacion.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()")    // Use 
                .IsRequired();

            //Entidad Marca
            modelBuilder.Entity<MarcaEntity>()
                .Property(marca => marca.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()")    // Use 
                .IsRequired();

            //Entidad Solicitud
            modelBuilder.Entity<SolicitudEntity>()
                .Property(solicitud => solicitud.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()")    // Use 
                .IsRequired();

            //Entidad Orden de compra
            modelBuilder.Entity<OrdenDeCompraEntity>()
                .Property(ordendecompra => ordendecompra.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()")    // Use 
                .IsRequired();

            //Entidad Pieza
            modelBuilder.Entity<PiezaEntity>()
                .Property(pieza => pieza.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()")    // Use 
                .IsRequired();
            
            //Entidad Tipo
            modelBuilder.Entity<Tipo_Proveedor>()
                .Property(tipo => tipo.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()")    // Use 
                .IsRequired();

        }


        public virtual Microsoft.EntityFrameworkCore.DbSet<ProveedorEntity> proveedor
        {
            get; set;
        }
        
        public virtual Microsoft.EntityFrameworkCore.DbSet<Tipo_Proveedor> tipo_Proveedor
        {
            get; set;
        }

        public virtual Microsoft.EntityFrameworkCore.DbSet<PiezaEntity> pieza
        {
            get; set;
        }

        public virtual Microsoft.EntityFrameworkCore.DbSet<MarcaEntity> marca
        {
            get; set;
        }


        public virtual Microsoft.EntityFrameworkCore.DbSet<OrdenDeCompraEntity> ordendecompra
        {
            get; set;
        }


        public virtual Microsoft.EntityFrameworkCore.DbSet<CotizacionEntity> cotizacion
        {
            get; set;
        }

        public virtual Microsoft.EntityFrameworkCore.DbSet<SolicitudEntity> solicitud
        {
            get; set;
        }

        public DbSet<ProveedorEntity> Proveedores
        {
            get; set;
        }
        
        public DbSet<MarcaEntity> Marcas
        {
            get; set;
        }
        
        public DbSet<Tipo_Proveedor> Tipos
        {
            get; set;
        }

        public DbSet<PiezaEntity> Piezas
        {
            get; set;
        }
         
        public DbSet<OrdenDeCompraEntity> OrdenesCompras
        {
            get; set;
        }
         
        public DbSet<CotizacionEntity> Cotizaciones
        {
            get; set;
        }
        public DbSet<SolicitudEntity> Solicitudes
        {
            get; set;
        }




    }
}

