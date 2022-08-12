using System;
using backendRCVUcab.Persistence.Entities;
using RCVUcabBackend.BussinesLogic.Commands.Commands.Atomics;
using RCVUcabBackend.BussinesLogic.Commands.Commands.Composes;
using RCVUcabBackend.BussinesLogic.DTOs;

namespace RCVUcabBackend.BussinesLogic.Commands
{
    public class CommandFactory
    {
        public static GetSolicitudesPorProveedorCommand createGetSolicitudesPorProveedorCommand(Guid proveedor)
        {
            return new GetSolicitudesPorProveedorCommand(proveedor);
        }
        
        public static CreateCotizacionCommand createCreateCotizacionCommand(CotizacionDTO cotizacion)
        {
            return new CreateCotizacionCommand(cotizacion);
        }
        
        public static InsertCotizacionCommand createInsertCotizacionCommand(CotizacionDTO cotizacion)
        {
            return new InsertCotizacionCommand(cotizacion);
        }
        
        public static CreateProveedorCommand createCreateProveedorCommand(ProveedorDTO proveedor)
        {
            return new CreateProveedorCommand(proveedor);
        }
        public static CreateSolicitudCommand createCreateSolicitudCommand(SolicitudDTO solicitud)
        {
            return new CreateSolicitudCommand(solicitud);
        }
        
        public static DeclineParticipacionCommand createDeclineParticipacionCommand(Guid solicitud, Guid proveedor)
        {
            return new DeclineParticipacionCommand(solicitud,proveedor);
        }
        
        public static SendCotizacionToAdminCommand createSendCotizacionToAdminCommand(CotizacionDTO cotizacion)
        {
            return new SendCotizacionToAdminCommand(cotizacion);
        }
        
    }
}