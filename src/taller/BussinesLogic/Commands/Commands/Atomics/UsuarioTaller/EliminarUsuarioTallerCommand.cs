using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.Persistence.DAOs.Implementations;
using RCVUcabBackend.Persistence;

namespace RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Atomic{

    public class EliminarUsuarioTallerCommand:Command<string>
    {
        private readonly UsuarioTallerEntity usuario_taller;
        private string _result;

        public EliminarUsuarioTallerCommand(UsuarioTallerEntity usuario_taller){
            this.usuario_taller=usuario_taller;
        }

        public override void Execute()
        {
            UsuarioTallerDB dao=TallerDAOFactory.crearUsuarioTallerDB();
            _result=dao.EliminarUsuarioTaller(usuario_taller);
        }

        public override string GetResult()
        {
            return _result;
        }
    }
}