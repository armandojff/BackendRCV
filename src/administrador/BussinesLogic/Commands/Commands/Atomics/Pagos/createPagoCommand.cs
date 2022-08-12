using administrador.Persistence.DAOs.Implementations;
using administrador.Persistence.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace administrador.Commands.Atomics.Pagos;

public class createPagoCommand : Command<string>
{
    private readonly PagosEntity _pago;
    private string _result;
        
    public createPagoCommand(PagosEntity pago)
    {
        _pago = pago;
    }
        
    public override void Execute()
    {
        PagosDAO dao = AdministradorDAOFactory.CreatePagosDAO();
        _result = dao.createPagos(_pago);
    }

    public override string GetResult()
    {
        return _result;
    }
}