using System.Threading.Tasks;
using administrador.Persistence.Entities;
using Microsoft.EntityFrameworkCore;


namespace administrador.Persistence.Database
{
    public interface IRCVDbContext
    {
        DbContext DbContext
        {
            get;
        }

        DbSet<AseguradoEntity> asegurado
        {
            get; set;
        }
        DbSet<MarcaEntity> marca
        {
            get; set;
        }
        DbSet<CarrosEntity> cars
        {
            get; set;
        }
        DbSet<IncidentesEntity> incident
        {
            get; set;
        }
        DbSet<PolizaEntity> poliza
        {
            get; set;
        }
        DbSet<UsuariosEntity> user
        {
            get; set;
        }
        
        DbSet<PagosEntity> pagos
        {
            get; set;
        }
        Task<int> SaveChangesAsync();
    }
}     