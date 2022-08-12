using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.Persistence.DAOs.Implementations;
using RCVUcabBackend.Persistence;
using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.BussinesLogic.DTOs;

namespace RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Atomic{

    public class ConsultarAnalisisPorIdCommand:Command<AnalisisEntity>
    {
        private readonly Guid Id_anlisis;
        private AnalisisEntity _result;

        public ConsultarAnalisisPorIdCommand(Guid Id_anlisis){
            this.Id_anlisis=Id_anlisis;
        }

        public override void Execute()
        {
            AnalisisDB dao=TallerDAOFactory.crearAnalisisDB();
            _result=dao.consultarAnalisisPorId(this.Id_anlisis);
        }

        public override AnalisisEntity GetResult()
        {
            return _result;
        }
    }
}