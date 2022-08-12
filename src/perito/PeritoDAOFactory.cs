using perito.BussinesLogic.DTOs;
using perito.Persistence.DAOs.Implementations;
using perito.Persistence.DAOs.MQ;
using perito.Persistence.Entities;

namespace perito{

public class PeritoDAOFactory
{
    
    public static PeritoDAO createPeritoDAO()
    {
        return new PeritoDAO();
    }
        
    public static PiezaDAO createPiezaDAO()
    {
        return new PiezaDAO();
    }
        
    public static AnalisisDAO createAnalisisDAO()
    {
        return new AnalisisDAO();
    }

    public static PeritoMQ createPeritoMQ()
    {
        return new PeritoMQ();
    }
    
    public static AdminMQ createAnalisisMQ()
    {
        return new AdminMQ();
    }
    
}
}