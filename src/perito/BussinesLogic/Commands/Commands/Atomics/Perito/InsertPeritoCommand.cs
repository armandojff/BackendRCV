using perito.BussinesLogic.DTOs;
using perito.Persistence.DAOs.Implementations;
using perito.Persistence.DAOs.Interfaces;
using perito.Persistence.Entities;

namespace perito.Commands.Atomics.Perito{

    public class InsertPeritoCommand : Command<PeritoDTO>
    {
        private readonly UsuarioPeritoEntity _perito;
        private PeritoDTO _result;

        public InsertPeritoCommand(UsuarioPeritoEntity perito)
        {
            _perito = perito;
        }

        public override void Execute()
        {
            PeritoDAO dao = PeritoDAOFactory.createPeritoDAO();
            _result = dao.CreatePerito(_perito);
        }

        public override PeritoDTO GetResult()
        {
            return _result;
        }
    }
}