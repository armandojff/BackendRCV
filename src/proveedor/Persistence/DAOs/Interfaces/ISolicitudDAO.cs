using System;
using RCVUcabBackend.BussinesLogic.DTOs;

namespace RCVUcabBackend.Persistence.DAOs.Interfaces
{
    public interface ISolicitudDAO
    {
        public SolicitudDTO CreateSolicitud(SolicitudDTO solicitud);
        
        public SolicitudDTO declinarParticipacion(Guid id_solicitud, Guid id_proveedor);
        
    }
}