using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.BussinesLogic.DTOs.DTOMQ;
using RCVUcabBackend.Persistence;
using RCVUcabBackend.Persistence.DAOs.MQ;

namespace RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Atomic{
    public class SendCotizacionCommand: Command<int>
    {
        private readonly CotizacionMQ _quotation;
        public SendCotizacionCommand(CotizacionMQ quotation)
        {
            _quotation = quotation;
        }

        public override void Execute()
        {
            proveedorPartesMQCotizacion dao = TallerDAOFactory.crearProveedorPartesMQ();
            dao.Producer(_quotation);
        }

        public override int GetResult()
        {
            throw new NotImplementedException();
        }
    }
}