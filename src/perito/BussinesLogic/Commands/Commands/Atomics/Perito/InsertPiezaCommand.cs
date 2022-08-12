using perito.BussinesLogic.DTOs;
using perito.Persistence.DAOs.Implementations;
using perito.Persistence.DAOs.Interfaces;
using perito.Persistence.Entities;

namespace perito.Commands.Atomics.Perito;

public class InsertPiezaCommand : Command<PiezaDTO>
{
    private readonly PiezaEntity _pieza;
    private PiezaDTO _result;

    public InsertPiezaCommand(PiezaEntity pieza)
    {
        _pieza = pieza;
    }

    public override void Execute()
    {
        PiezaDAO dao = PeritoDAOFactory.createPiezaDAO();
        _result = dao.CreatePieza(_pieza);
    }

    public override PiezaDTO GetResult()
    {
        return _result;
    }
}