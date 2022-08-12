using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.Persistence.DAOs.Implementations;
using RCVUcabBackend.Persistence;

namespace RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Atomic{

    public class EliminarTallerCommand:Command<string>
    {
        private readonly Guid id_taller;
        private string _result;

        public EliminarTallerCommand(Guid id_taller){
            this.id_taller=id_taller;
        }

        public override void Execute()
        {
            TallerDB dao=TallerDAOFactory.crearTallerDB();
            _result=dao.EliminarTaller(id_taller);
        }

        public override string GetResult()
        {
            return _result;
        }
    }
}