using perito.BussinesLogic.DTOs;
using perito.Persistence.DAOs.Implementations;
using perito.Persistence.Entities;

namespace perito.Commands.Atomics.Perito
{
   
    public class ActualizarPeritoCommand : Command<PeritoDTO>
    {
        private readonly UsuarioPeritoEntity perito;
        private readonly Guid id_perito;
        private PeritoDTO _result;
        public ActualizarPeritoCommand(UsuarioPeritoEntity perito,Guid id_perito){
            this.perito=perito;
            this.id_perito=id_perito;
        }

        public override void Execute()
        {
            PeritoDAO dao=PeritoDAOFactory.createPeritoDAO();
            _result=dao.ActualizarPerito(perito,id_perito);
        }

        public override PeritoDTO GetResult()
        {
            return _result;
        }

    }
}



