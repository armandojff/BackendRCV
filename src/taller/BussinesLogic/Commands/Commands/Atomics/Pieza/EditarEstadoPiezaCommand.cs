using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.Persistence.DAOs.Implementations;
using RCVUcabBackend.Persistence;
using RCVUcabBackend.Persistence.Entities.ChecksEntitys;

namespace RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Atomic{
    
    public class EditarEstadoPiezaCommand:Command<PiezasConsultDTO>
    {
        private readonly PiezasEntity pieza;
        private readonly CheckEstadoPieza estado;
        private PiezasConsultDTO _result;

        public EditarEstadoPiezaCommand(PiezasEntity pieza,CheckEstadoPieza estado){
            this.pieza=pieza;
            this.estado=estado;
        }

        public override void Execute()
        {
            PiezasDB dao=TallerDAOFactory.crearPiezasDB();
            _result=dao.EditarEstadoPieza(pieza,estado);
        }

        public override PiezasConsultDTO GetResult()
        {
            return _result;
        }
    }
}
