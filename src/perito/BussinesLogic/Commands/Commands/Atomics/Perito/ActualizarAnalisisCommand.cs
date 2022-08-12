using perito.BussinesLogic.DTOs;
using perito.Persistence.DAOs.Implementations;
using perito.Persistence.Entities;

namespace perito.Commands.Atomics.Perito
{

    public class ActualizarAnalisisCommand : Command<AnalisisDTO>
    {
        private readonly AnalisisEntity analisis;
        private readonly Guid id_analisis;
        private AnalisisDTO _result;

        public ActualizarAnalisisCommand(AnalisisEntity analisis,Guid id_analisis){
            this.analisis=analisis;
            this.id_analisis=id_analisis;
        }

        public override void Execute()
        {
            AnalisisDAO dao=PeritoDAOFactory.createAnalisisDAO();
            _result=dao.ActualizarAnalisis(analisis,id_analisis);
        }

        public override AnalisisDTO GetResult()
        {
            return _result;
        }

    }
}