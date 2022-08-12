using perito.Persistence.DAOs.Implementations;

namespace perito.Commands.Atomics.Perito
{

    public class DeletePeritoCommand : Command<string>
    {
        private readonly Guid id_perito;
        private string _result;

        public DeletePeritoCommand(Guid id_perito)
        {
            this.id_perito= id_perito;
        }

        public override void Execute()
        {
            PeritoDAO dao = PeritoDAOFactory.createPeritoDAO();
            _result = dao.EliminarPerito(id_perito);
        }

        public override string GetResult()
        {
            return _result;
        }

    }
}

