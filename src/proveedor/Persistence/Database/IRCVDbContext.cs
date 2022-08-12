using Microsoft.EntityFrameworkCore;
using backendRCVUcab.Persistence.Entities;

namespace backendRCVUcab.Persistence.Database
{
    public interface IRCVDbContext
    {
        
            DbContext DbContext
            {
                get;
            }
        
            DbSet<ProveedorEntity> Proveedores
            {
                get; set;
            }
            
            DbSet<Tipo_Proveedor> Tipos
            {
                get; set;
            }
         
            DbSet<MarcaEntity> Marcas
            {
                get; set;
            }

            DbSet<PiezaEntity> Piezas
            {
                get; set;
            }
         
            DbSet<OrdenDeCompraEntity> OrdenesCompras
            {
                get; set;
            }
         
            DbSet<CotizacionEntity> Cotizaciones
            {
                get; set;
            }
            DbSet<SolicitudEntity> Solicitudes
            {
                get; set;
            }
    
        }
    
}