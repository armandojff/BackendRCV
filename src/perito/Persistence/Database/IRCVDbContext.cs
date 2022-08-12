using Microsoft.EntityFrameworkCore;
using perito.Persistence.Entities;

namespace perito.Persistence.Database
{
    public interface IRCVDbContext
    {
        
        DbContext DbContext
        {
            get;
        }
        
        DbSet<AnalisisEntity> analisis
        {
            get; set;
        }
        DbSet<UsuarioPeritoEntity> peritos
        {
            get; set;
        }
        DbSet<PiezaEntity> piezas
        {
            get; set;
        }

        DbSet<DireccionEntity> direcciones
        {
            get;
            set;
        }

    }
}