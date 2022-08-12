using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.Persistence.DAOs.Implementations;
using RCVUcabBackend.Persistence;



namespace RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Atomic{
    public class InsertUsuarioTallerCommand:Command<crearUsuarioTallerDTO>{
        private readonly UsuarioTallerEntity usuarioTaller;
        private crearUsuarioTallerDTO _result;

        public InsertUsuarioTallerCommand(UsuarioTallerEntity usuarioTaller){
            this.usuarioTaller=usuarioTaller;
        }

        public override void Execute()
        {
            UsuarioTallerDB dao=TallerDAOFactory.crearUsuarioTallerDB();
            _result=dao.crearUsuarioTaller(usuarioTaller);
        }

        public override crearUsuarioTallerDTO GetResult()
        {
            return _result;
        }
    }
}