using System;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.Persistence;
using RCVUcabBackend.Persistence.DAOs.Implementations;

namespace RCVUcabBackend.BussinesLogic.Commands.Commands.Atomics
{
    public class DeclineParticipacionCommand : Command<SolicitudDTO>
    {
        private readonly Guid _id_proveedor;
        private readonly Guid _id_solicitud;
        private SolicitudDTO _result;

        public DeclineParticipacionCommand(Guid idSolicitud, Guid idProveedor)
        {
            _id_proveedor = idProveedor;
            _id_solicitud = idSolicitud;
        }

        public override void Execute()
        {
            SolicitudDao  dao = ProveedorDAOFactory.CreateSolicitudDB();
            _result = dao.declinarParticipacion(_id_solicitud,_id_proveedor);
        }

        public override SolicitudDTO GetResult()
        {
            return _result;
        }
    }
}