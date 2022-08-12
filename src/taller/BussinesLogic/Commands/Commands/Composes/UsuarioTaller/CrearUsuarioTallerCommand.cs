using RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Atomic;
using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.BussinesLogic.Mappers;
using RCVUcabBackend.Persistence.Entities;

namespace RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Composes{

    public class CrearUsuarioTallerCommand:Command<crearUsuarioTallerDTO>
    {
        private readonly UsuarioTallerEntity usuarioTaller;
        private readonly Guid id_taller;
        private crearUsuarioTallerDTO _result;

        public CrearUsuarioTallerCommand(UsuarioTallerEntity usuarioTaller,Guid id_taller){
            this.usuarioTaller=usuarioTaller;
            this.id_taller=id_taller;
            
        }

        public override void Execute()
        {
            /*InsertListaDeTelefonoCommand comandTelefono=CommandFactory.crearInsertListaDeTelefonoCommand(usuarioTaller.Telefonos);
            comandTelefono.Execute();*/
            ConsultarTallerPorIdCommand comandTallerConsulta=CommandFactory.crearConsultarTallerPorIdCommand(id_taller);
            comandTallerConsulta.Execute();
            usuarioTaller.taller=comandTallerConsulta.GetResult();
            InsertUsuarioTallerCommand comandUsuarioTallerInsert=CommandFactory.crearInsertUsuarioTallerCommand(usuarioTaller);
            comandUsuarioTallerInsert.Execute();
            _result=comandUsuarioTallerInsert.GetResult();
        }

        public override crearUsuarioTallerDTO GetResult()
        {
            return _result;
        }
    }
}