using RCVUcabBackend.Persistence.DAOs.Implementations;
using RCVUcabBackend.Persistence.DAOs.MQ;
namespace RCVUcabBackend.Persistence
{
    public class TallerDAOFactory
    {
        public static TallerDB crearTallerDB(){
            return new TallerDB();
        }

        public static MarcaDB crearMarcaDB(){
            return new MarcaDB();
        }
        
        public static AnalisisDB crearAnalisisDB(){
            return new AnalisisDB();
        }

        public static PiezasDB crearPiezasDB(){
            return new PiezasDB();
        }

        public static UsuarioTallerDB crearUsuarioTallerDB(){
            return new UsuarioTallerDB();
        }

        public static TelefonoDB crearTelefonoDB(){
            return new TelefonoDB();
        }

        public static CotizacionDB crearCotizacionDB(){
            return new CotizacionDB();
        }
        

        public static proveedorPartesMQCotizacion crearProveedorPartesMQ(){
            return new proveedorPartesMQCotizacion();
        }
    }
}