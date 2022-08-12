using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.Persistence.DAOs.Implementations;
using RCVUcabBackend.Persistence;



namespace RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Atomic{
    public class InsertListaDeTelefonoCommand:Command<bool>{
        private readonly ICollection<TelefonoEntity> telefonos;
        private bool _result;

        public InsertListaDeTelefonoCommand(ICollection<TelefonoEntity> telefonos){
            this.telefonos=telefonos;
        }

        public override void Execute()
        {
            TelefonoDB dao=TallerDAOFactory.crearTelefonoDB();
            _result=dao.crearTelefonosDeLista(telefonos);
        }

        public override bool GetResult()
        {
            return _result;
        }
    }
}