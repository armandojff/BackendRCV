using RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Atomic;
using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.BussinesLogic.Mappers;
using RCVUcabBackend.Persistence.Entities;

namespace RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Composes{
    public class UpdateUsuarioTallerCommand:Command<string>
    {
        private readonly UsuarioTallerEntity usuarioTallerCambios;
        private readonly Guid iDusuarioTaller;
        private string _result;

        public UpdateUsuarioTallerCommand(UsuarioTallerEntity usuarioTallerCambios,Guid iDusuarioTaller){
            this.usuarioTallerCambios=usuarioTallerCambios;
            this.iDusuarioTaller=iDusuarioTaller;
        }

        public override void Execute()
        {
            ConsultarUsuarioTallerPorIdCommand commandConsultarUsuarioTaller=new ConsultarUsuarioTallerPorIdCommand(iDusuarioTaller);
            commandConsultarUsuarioTaller.Execute();

            ConsultarListaTelefonoComand comandTelefonosExistentes=new ConsultarListaTelefonoComand(usuarioTallerCambios.Telefonos,commandConsultarUsuarioTaller.GetResult());
            comandTelefonosExistentes.Execute();
            usuarioTallerCambios.Telefonos=comandTelefonosExistentes.GetResult();
            
            ActualizarUsuarioTallerCommand commandActualizarUsuarioTaller= new ActualizarUsuarioTallerCommand(commandConsultarUsuarioTaller.GetResult(),usuarioTallerCambios);
            commandActualizarUsuarioTaller.Execute();
            _result=commandActualizarUsuarioTaller.GetResult();
        }

        public override string GetResult()
        {
            return _result;
        }
    }
}