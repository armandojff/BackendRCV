using perito.BussinesLogic.DTOs;
using perito.Persistence.DAOs.Implementations;
using perito.Persistence.DAOs.Interfaces;
using perito.Persistence.Entities;

namespace perito.Commands.Atomics.Perito
{

    public class InsertAnalisisCommand : Command<AnalisisDTO>
    {
        private readonly AnalisisEntity analisis;
        private AnalisisDTO _result;

        public InsertAnalisisCommand(AnalisisEntity analisis)
        {
            this.analisis = analisis;
        }

        public override void Execute()
        {
            AnalisisDAO dao = PeritoDAOFactory.createAnalisisDAO();
            _result = dao.CreateAnalisis(analisis);
        }

        public override AnalisisDTO GetResult()
        {
            return _result;
        }
    }
}