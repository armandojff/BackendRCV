using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.Persistence.DAOs.Implementations;
using RCVUcabBackend.Persistence;

namespace RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Atomic{
    
    public class ActualizarTallerCommand:Command<TallerDTO>
    {
        private readonly TallererEntity taller;
        private readonly Guid id_taller;
        private TallerDTO _result;

        public ActualizarTallerCommand(TallererEntity taller,Guid id_taller){
            this.taller=taller;
            this.id_taller=id_taller;
        }

        public override void Execute()
        {
            TallerDB dao=TallerDAOFactory.crearTallerDB();
            _result=dao.ActualizarTaller(taller,id_taller);
        }

        public override TallerDTO GetResult()
        {
            return _result;
        }
    }
}
