using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.Persistence.DAOs.Implementations;
using RCVUcabBackend.Persistence;



namespace RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Atomic{
    public class ConsultarListaTelefonoComand:Command<ICollection<TelefonoEntity>>{
        private readonly ICollection<TelefonoEntity> telefonos;
        private readonly UsuarioTallerEntity usuarioTaller;
        private ICollection<TelefonoEntity> _result;

        public ConsultarListaTelefonoComand(ICollection<TelefonoEntity> telefonos,UsuarioTallerEntity usuarioTaller){
            this.telefonos=telefonos;
            this.usuarioTaller=usuarioTaller;
        }

        public override void Execute()
        {
            TelefonoDB dao=TallerDAOFactory.crearTelefonoDB();
            _result=dao.AsignarTelefonosExistente(telefonos,usuarioTaller);
        }

        public override ICollection<TelefonoEntity> GetResult()
        {
            return _result;
        }
    }
}