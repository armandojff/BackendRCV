using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.Persistence.DAOs.Implementations;
using RCVUcabBackend.Persistence;
using RCVUcabBackend.Persistence.Entities.ChecksEntitys;

namespace RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Atomic{
    
    public class EditarDescripcionDeLaPiezaCommand:Command<PiezasConsultDTO>
    {
        private readonly PiezasEntity pieza;
        private readonly string descripcion_nueva;
        private PiezasConsultDTO _result;

        public EditarDescripcionDeLaPiezaCommand(PiezasEntity pieza,string descripcion_nueva){
            this.pieza=pieza;
            this.descripcion_nueva=descripcion_nueva;
        }

        public override void Execute()
        {
            PiezasDB dao=TallerDAOFactory.crearPiezasDB();
            _result=dao.EditardescripcionPieza(pieza,descripcion_nueva);
        }

        public override PiezasConsultDTO GetResult()
        {
            return _result;
        }
    }
}
