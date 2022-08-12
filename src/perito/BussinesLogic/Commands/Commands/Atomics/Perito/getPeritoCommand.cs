using perito;
using perito.BussinesLogic.DTOs;
using perito.Commands;
using perito.Persistence.DAOs.Implementations;

namespace perito.Commands.Atomics.Perito{

public class getPeritoCommand : Command<PeritoDTO>
{
    private readonly Guid _id;
    private PeritoDTO _result;

    public getPeritoCommand(Guid id)
    {
        _id = id;
    }

    public override void Execute()
    {
        PeritoDAO dao = PeritoDAOFactory.createPeritoDAO();
        _result = dao.getPerito(_id);
    }

    public override PeritoDTO GetResult()
    {
        return _result;
    }
}

}