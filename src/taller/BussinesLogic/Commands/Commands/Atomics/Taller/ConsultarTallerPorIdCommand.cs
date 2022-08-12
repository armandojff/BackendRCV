using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.Persistence.DAOs.Implementations;
using RCVUcabBackend.Persistence;

namespace RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Atomic{
    public class ConsultarTallerPorIdCommand:Command<TallererEntity>
    {
        private readonly Guid Id_taller;
        private TallererEntity _result;

        public ConsultarTallerPorIdCommand(Guid Id_taller){
            this.Id_taller=Id_taller;
        }

        public override void Execute()
        {
            TallerDB dao=TallerDAOFactory.crearTallerDB();
            _result=dao.traerTaller(Id_taller);
        }

        public override TallererEntity GetResult()
        {
            return _result;
        }
    }
}