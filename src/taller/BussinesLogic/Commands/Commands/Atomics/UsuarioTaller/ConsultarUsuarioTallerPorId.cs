using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.Persistence.DAOs.Implementations;
using RCVUcabBackend.Persistence;

namespace RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Atomic{
    public class ConsultarUsuarioTallerPorIdCommand:Command<UsuarioTallerEntity>
    {
        private readonly Guid Id_usuario_taller;
        private UsuarioTallerEntity _result;

        public ConsultarUsuarioTallerPorIdCommand(Guid Id_usuario_taller){
            this.Id_usuario_taller=Id_usuario_taller;
        }

        public override void Execute()
        {
            UsuarioTallerDB dao=TallerDAOFactory.crearUsuarioTallerDB();
            _result=dao.traerUsuarioTaller(Id_usuario_taller);
        }

        public override UsuarioTallerEntity GetResult()
        {
            return _result;
        }
    }
}