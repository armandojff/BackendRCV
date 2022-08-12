using RCVUcabBackend.BussinesLogic.DTOs;

namespace RCVUcabBackend.Persistence.DAOs.Interfaces
{
    public interface ICotizacionDAO
    {
        public CotizacionDTO createCotizacion(CotizacionDTO cotizacion);
    }
}