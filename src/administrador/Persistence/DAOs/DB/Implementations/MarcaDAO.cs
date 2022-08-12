using System;
using System.Collections.Generic;
using System.Linq;
using administrador.Exceptions;
using administrador.Persistence.DAOs.Interfaces;
using administrador.Persistence.Database;
using administrador.Persistence.Entities;

namespace administrador.Persistence.DAOs.Implementations
{
    public class MarcaDAO : IMarcaDAO
    {
        private static DesignTimeDbContextFactory desing = new DesignTimeDbContextFactory();
        private IRCVDbContext _context = desing.CreateDbContext(null);
        public MarcaEntity marca = new MarcaEntity();
        public string mensajeError = "Ocurrio un error inesperado en ";
        
        public MarcaDAO(IRCVDbContext context)
        {
            _context = context;
        }
        
        public MarcaDAO()
        {
            // en produción
        }
        
        /*Consulta el GUID de la marca*/
        public List<Guid> getMarca(string marca)
        {
            try
            {
                if (marca == null) {throw new RCVExceptions(mensajeError + "getMarca()");}
                var brand = _context.marca
                    .Where(p => p.marca == marca)
                    .Select(p => p.Id).ToList();
                return (brand.ToList());
            }
            catch(Exception ex){
                throw new RCVExceptions("Problemas al consultar la marca", ex);
            }
        }
        
        /*Crear la marca en la BD*/
        public string createMarca(string marca)
        {
            try
            {
                if (marca == null) {throw new RCVExceptions("Error al crear marca");}
                this.marca = new MarcaEntity()
                {
                    marca = marca
                };
                _context.marca.Add(this.marca);
                _context.DbContext.SaveChanges();
                return "Marca creada con éxito"; 
            }
            catch(Exception ex){
                throw new RCVExceptions("Problemas al crear la marca", ex);
            }
        }
    }
}