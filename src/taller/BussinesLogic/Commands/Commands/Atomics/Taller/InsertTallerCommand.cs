using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.Persistence.DAOs.Implementations;
using RCVUcabBackend.Persistence;



namespace RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Atomic{
    public class InsertTallerCommand:Command<TallerDTO>{
        private readonly TallererEntity taller;
        private TallerDTO _result;

        public InsertTallerCommand(TallererEntity taller){
            this.taller=taller;
        }

        public override void Execute()
        {
            TallerDB dao=TallerDAOFactory.crearTallerDB();
            _result=dao.crearTaller(taller);
        }

        public override TallerDTO GetResult()
        {
            return _result;
        }
    }
}