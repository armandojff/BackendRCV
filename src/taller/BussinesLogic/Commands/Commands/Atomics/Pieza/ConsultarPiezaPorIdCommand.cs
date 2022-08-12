using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.Persistence.DAOs.Implementations;
using RCVUcabBackend.Persistence;

namespace RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Atomic{
    public class ConsultarPiezaPorIdCommand:Command<PiezasEntity>
    {
        private readonly Guid Id_pieza;
        private PiezasEntity _result;

        public ConsultarPiezaPorIdCommand(Guid Id_pieza){
            this.Id_pieza=Id_pieza;
        }

        public override void Execute()
        {
            PiezasDB dao=TallerDAOFactory.crearPiezasDB();
            _result=dao.traerPieza(Id_pieza);
        }

        public override PiezasEntity GetResult()
        {
            return _result;
        }
    }
}