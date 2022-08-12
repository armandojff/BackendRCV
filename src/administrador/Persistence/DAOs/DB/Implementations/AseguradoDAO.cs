using administrador.BussinesLogic.DTOs;
using administrador.Persistence.DAOs.Interfaces;
using administrador.Persistence.Database;
using administrador.Exceptions;
using administrador.Persistence.Entities;

namespace administrador.Persistence.DAOs.Implementations
{
    public class AseguradoDAO : IAseguradoDAO
    {
        private static DesignTimeDbContextFactory desing = new DesignTimeDbContextFactory();
        private IRCVDbContext _context = desing.CreateDbContext(null);
        
        public AseguradoDAO(){} // Para el AdministradoDAOFactory
        
        public AseguradoDAO(IRCVDbContext context)
        {
            _context = context; //evaluar
        }

        public bool valiacion(int ci) //verifico si existe un asegurado por cédula
        {
            var asegurados = _context.asegurado
                .Where(b => b.ci == ci)
                .Select(p => new PAseguradoDTO
                {
                    ci = p.ci,
                    full_name = p.primer_n + " " + p.primer_a
                });
            if(asegurados.ToList().Count == 0){
                return false;
            }
            return true;
        }
        
        /*Me permite crear un asegurado*/
        public string createInsured(AseguradoEntity insured)
        {
            int i;
            bool validacion = valiacion(insured.ci);
            if (validacion == false) // si no existe
            {
                try{
                    _context.asegurado.Add(insured);
                    _context.DbContext.SaveChanges();
                    return "Éxitoso";
                }
                catch(Exception ex){
                    throw new RCVExceptions("No se puede crear, detalles: ", ex);
                
                }
            }
            else
            {
                return "Asegurado ya existe";
            }
        }
        
        /*Me trae todos los asegurados*/
        public List<PAseguradoDTO> getInsured()
        {
            try
            {
                var asegurados = _context.asegurado
                    //.Include(insured => insured.ci)
                    .Select( p => new PAseguradoDTO{
                        ci = p.ci,
                        full_name = p.primer_n + " " + p.primer_a
                    }).ToList();
                if(asegurados.ToList().Count == 0){
                    throw new Exception("No hay asegurados");
                }
                return asegurados.ToList();
            }
            catch(Exception ex){
                throw new RCVExceptions("No se ha podido presentar la lista de asegurados", ex.Message, ex);
            }
        }
        
        /*Me trae un asegurado por número de cédula*/
        public PAseguradoDTO getInsured(int ci)
        {
            try
            {
                var asegurados = _context.asegurado
                    .Where(b => b.ci == ci)
                    .Select(p => new PAseguradoDTO
                    {
                        ci = p.ci,
                        full_name = p.primer_n + " " + p.primer_a
                    });
                if(asegurados == null){
                    throw new Exception("No existe ese asegurado");
                }
                return asegurados.ToList()[0];
            }
            catch(Exception ex)
            {
                throw new RCVExceptions("No se ha podido presentar la lista de asegurados", ex.Message, ex);
            }
        }
    }
}