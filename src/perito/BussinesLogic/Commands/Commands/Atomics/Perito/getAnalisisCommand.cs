using perito.BussinesLogic.DTOs;
using perito.Persistence.DAOs.Implementations;

namespace perito.Commands.Atomics.Perito
{

    public class getAnalisisCommand : Command<AnalisisDTO>
    {
        private readonly Guid _id;
        private AnalisisDTO _result;

        public getAnalisisCommand(Guid id)
        {
            _id = id;
        }

        public override void Execute()
        {
            AnalisisDAO dao = PeritoDAOFactory.createAnalisisDAO();
            _result = dao.getAnalisis(_id);
        }

        public override AnalisisDTO GetResult()
        {
            return _result;
        }
    }
}