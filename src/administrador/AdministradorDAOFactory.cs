using administrador.Persistence.DAOs.Implementations;
using administrador.Persistence.DAOs.MQ;
using administrador.Persistence.Entities;

namespace administrador
{
    public class AdministradorDAOFactory
    {
        public static AseguradoDAO createAseguradoDAO()
        {
            return new AseguradoDAO();
        }
        
        public static CarroDAO CreateCarroDAO()
        {
            return new CarroDAO();
        }
        
        public static IncidenteDAO CreateIncidenteDAO()
        {
            return new IncidenteDAO();
        }
        
        public static MarcaDAO CreateMarcaDAO()
        {
            return new MarcaDAO();
        }
        
        public static PolizaDAO CreatePolizaDAO()
        {
            return new PolizaDAO();
        }
        
        public static PagosDAO CreatePagosDAO()
        {
            return new PagosDAO();
        }

        public static AdminMQ createAdminMQ()
        {
            return new AdminMQ();
        }
    }
}