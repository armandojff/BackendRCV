using perito.BussinesLogic.DTOs;
using perito.Persistence.DAOs.Implementations;

namespace perito.Commands.Atomics.Perito{

    public class getPiezaCommand : Command<PiezaDTO>
    {
        private readonly Guid _id;
        private PiezaDTO _result;

        public getPiezaCommand(Guid id)
        {
            _id = id;
        }

        public override void Execute()
        {
            PiezaDAO dao = PeritoDAOFactory.createPiezaDAO();
            _result = dao.getPieza(_id);
        }

        public override PiezaDTO GetResult()
        {
            return _result;
        }
    }
}