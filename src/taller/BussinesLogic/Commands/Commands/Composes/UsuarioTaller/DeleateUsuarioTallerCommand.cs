using RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Atomic;
using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.BussinesLogic.Mappers;
using RCVUcabBackend.Persistence.Entities;

namespace RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Composes{

    public class DeleateUsuarioTallerCommand:Command<string>
    {
        private readonly Guid id_usuario_taller;
        private string _result;

        public DeleateUsuarioTallerCommand(Guid id_usuario_taller){
            this.id_usuario_taller=id_usuario_taller;
            
        }

        public override void Execute()
        {
            ConsultarUsuarioTallerPorIdCommand comandConsultaUsuarioTaller=CommandFactory.crearConsultarUsuarioTallerPorIdCommand(id_usuario_taller);
            comandConsultaUsuarioTaller.Execute();
            EliminarUsuarioTallerCommand comandEliminarUsuarioTaller=CommandFactory.crearEliminarUsuarioTallerCommand(comandConsultaUsuarioTaller.GetResult());
            comandEliminarUsuarioTaller.Execute();
            _result=comandEliminarUsuarioTaller.GetResult();
        }

        public override string GetResult()
        {
            return _result;
        }
    }
}