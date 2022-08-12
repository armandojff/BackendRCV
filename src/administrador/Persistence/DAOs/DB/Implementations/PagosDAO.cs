using administrador.Exceptions;
using administrador.Persistence.Database;
using administrador.Persistence.Entities;

namespace administrador.Persistence.DAOs.Implementations;

public class PagosDAO
{
    private static DesignTimeDbContextFactory desing = new DesignTimeDbContextFactory();
    private IRCVDbContext _context = desing.CreateDbContext(null);

    public PagosDAO(){}
    
    public string createPagos(PagosEntity pago)
    {
        try
        {
            _context.pagos.Add(pago);
            _context.DbContext.SaveChanges();
            return "Pago registrado con éxito";
        }
        catch(Exception ex){
            throw new RCVExceptions("No se puede crear el incidente", ex);
                
        }
    }
}