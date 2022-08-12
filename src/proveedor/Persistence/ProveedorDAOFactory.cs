using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.Persistence.DAOs.Implementations;
using RCVUcabBackend.Persistence.DAOs.MQ;

namespace RCVUcabBackend.Persistence
{
    public class ProveedorDAOFactory
    {
        public static ProveedorDao CreateProviderDB()
        {
            return new ProveedorDao();
        }
        
        public static CotizacionDao CreateCotizacionDB()
        {
            return new CotizacionDao();
        }
        
        public static SolicitudDao CreateSolicitudDB()
        {
            return new SolicitudDao();
        }
        
        public static ProveedorMQ CreateProveedorMQ()
        {
            return new ProveedorMQ();
        }
    }
}