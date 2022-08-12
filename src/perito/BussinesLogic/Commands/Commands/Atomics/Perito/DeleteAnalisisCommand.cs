using perito.Persistence.DAOs.Implementations;

namespace perito.Commands.Atomics.Perito
{

    public class DeleteAnalisisCommand : Command<string>
    {
        private readonly Guid id_analisis;
        private string _result;

        public DeleteAnalisisCommand(Guid id_analisis)
        {
            this.id_analisis= id_analisis;
        }

        public override void Execute()
        {
            AnalisisDAO dao = PeritoDAOFactory.createAnalisisDAO();
            _result = dao.EliminarAnalisis(id_analisis);
        }

        public override string GetResult()
        {
            return _result;
        }
    }
}