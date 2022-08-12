using administrador.BussinesLogic.DTOs;
using administrador.Persistence.DAOs.Interfaces;
using administrador.Persistence.Database;
using administrador.Exceptions;
using administrador.Persistence.Entities;

namespace administrador.Persistence.DAOs.Implementations
{
    public class PolizaDAO : IPolizaDAO
    {
        private static DesignTimeDbContextFactory desing = new DesignTimeDbContextFactory();
        private IRCVDbContext _context = desing.CreateDbContext(null);

        public PolizaDAO(){}
        public PolizaDAO(IRCVDbContext context)
        {
            _context = context;
        }
        
        /*Crea una poliza con su tipo: Completa/Parcial*/
        public string createPoliza(PolizaEntity poliza)
        {
            try{
                _context.poliza.Add(poliza);
                _context.DbContext.SaveChanges();
                return "Poliza creada con éxito"; 
            }
            catch(Exception ex){
                    throw new RCVExceptions("No se puede crear la poliza", ex);
            }
        }

        /*Desactivar poliza*/
        public async Task<bool> deletePolicy(Guid poliza)
        {
            try
            { 
                var policy = _context.poliza
                    .Where(p => p.Id == poliza)
                    .First();
                policy.desactivada = true;
                _context.DbContext.SaveChanges();
                return true;
            }
            catch(Exception ex){
                throw new RCVExceptions("No se puede actualizar la poliza", ex);
            }
        }
        
        
        /*Me trae las polizas de un asegurado*/
        public List<PolizaAseguradoDTO> getPolicyInsured(int ci)
        {
            try
            {
                var policy = _context.poliza
                    .Where(p => p.AseguradoEntityId == ci)
                    .Select(p => new PolizaAseguradoDTO()
                    {
                        tipo = p.tipo,
                        vencimiento = p.vencimiento,
                        estado = p.desactivada,
                        placa = p.CarrosEntityId
                    }).ToList();
                if(policy.ToList().Count == 0){
                    throw new Exception("El asegurado no tiene polizas");
                }
                return policy.ToList();
            }
            catch(Exception ex){
                throw new RCVExceptions("No se ha podido presentar la lista de polizas", ex.Message, ex);
            }
        }
        
        /*EVAUACIÓN INDIVIDUAL EN CLASE TRAER POLIZAS CON FECHA DE VENCIMIENTO*/
        public List<PolizaSimpleDTO> getPolicy(DateTime fecha) //trae todas las polizas
        {
            try
            {
                var poliza = _context.poliza
                    .Where(p => p.vencimiento == fecha)
                    .Select( p => new PolizaSimpleDTO(){
                        tipo = p.tipo,
                        vencimiento = p.vencimiento,
                        asegurado = p.AseguradoEntityId
                    }).ToList();
                if(poliza.ToList().Count == 0){
                    throw new Exception("No hay polizas, con esa fecha");
                }
                return poliza.ToList();
            }
            catch(Exception ex){
                throw new RCVExceptions("No se ha podido presentar las polizas", ex.Message, ex);
            }
        }

        public string NotImplementedException { get; set; }
    } 
}
