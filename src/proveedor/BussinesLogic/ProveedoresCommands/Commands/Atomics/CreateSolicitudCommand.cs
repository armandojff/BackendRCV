using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.Persistence;
using RCVUcabBackend.Persistence.DAOs.Implementations;
using RCVUcabBackend.Persistence.DAOs.Interfaces;

namespace RCVUcabBackend.BussinesLogic.Commands.Commands.Atomics
{
    public class CreateSolicitudCommand : Command<SolicitudDTO>
    {
        private readonly SolicitudDTO _solicitud;
        private SolicitudDTO _result;
            
        public CreateSolicitudCommand(SolicitudDTO solicitud)
        {
            _solicitud = solicitud;
        }

        public override void Execute()
        {
            SolicitudDao  dao = ProveedorDAOFactory.CreateSolicitudDB();
            _result = dao.CreateSolicitud(_solicitud);
        }

        public override SolicitudDTO GetResult()
        {
            return _result;
        }
    }
}