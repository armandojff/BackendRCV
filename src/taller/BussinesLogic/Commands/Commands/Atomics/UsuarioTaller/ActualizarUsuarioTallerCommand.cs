using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.Persistence.DAOs.Implementations;
using RCVUcabBackend.Persistence;

namespace RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Atomic{
    
    public class ActualizarUsuarioTallerCommand:Command<string>
    {
        private readonly UsuarioTallerEntity usuarioTallerSinCmabios;
        private readonly UsuarioTallerEntity usuarioTallerConCmabios;
        private string _result;

        public ActualizarUsuarioTallerCommand(UsuarioTallerEntity usuarioTallerSinCmabios,UsuarioTallerEntity usuarioTallerConCmabios){
            this.usuarioTallerSinCmabios=usuarioTallerSinCmabios;
            this.usuarioTallerConCmabios=usuarioTallerConCmabios;
        }

        public override void Execute()
        {
            UsuarioTallerDB dao=TallerDAOFactory.crearUsuarioTallerDB();
            _result=dao.ActualizarUsuarioTaller(usuarioTallerConCmabios,usuarioTallerSinCmabios);
        }

        public override string GetResult()
        {
            return _result;
        }
    }
}
