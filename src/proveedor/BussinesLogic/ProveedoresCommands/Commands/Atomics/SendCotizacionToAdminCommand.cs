using System;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.Persistence;
using RCVUcabBackend.Persistence.DAOs.MQ;

namespace RCVUcabBackend.BussinesLogic.Commands.Commands.Atomics
{
    public class SendCotizacionToAdminCommand : Command<int>
    {
        private readonly CotizacionDTO _cotizacion;
        
        public SendCotizacionToAdminCommand(CotizacionDTO cotizacion)
        {
            _cotizacion = cotizacion;
        }

        public override void Execute()
        {
            ProveedorMQ dao = ProveedorDAOFactory.CreateProveedorMQ();
            dao.Producer(_cotizacion);
        }

        public override int GetResult()
        {
            throw new NotImplementedException();
        }
    }
}