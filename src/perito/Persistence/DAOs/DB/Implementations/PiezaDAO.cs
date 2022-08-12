using System;
using System.Data.Entity;
using System.Linq;
using perito.BussinesLogic.DTOs;
using perito.Exceptions;
using perito.Persistence.DAOs.Interfaces;
using perito.Persistence.Database;
using perito.Persistence.Entities;

namespace perito.Persistence.DAOs.Implementations
{
    public class PiezaDAO:IPiezaDAO
    {
        private static DesignTimeDbContextFactory desing = new DesignTimeDbContextFactory();
        private IRCVDbContext _context = desing.CreateDbContext(null);
        public PiezaEntity Pieza = new PiezaEntity();
        public int error = 0;
        public string mensajeError = "Ocurrio un error inesperado";
        
        public PiezaDAO(){}
        public PiezaDAO(IRCVDbContext context)
        {
            _context = context;
        }
        
        public bool validarEspaciosBlancos(string texto)
        {
            var cantidad_espacios = 0;
            foreach (var caracter in texto)
            {
                if (caracter.Equals(' '))
                {
                    cantidad_espacios++;
                    Console.WriteLine(caracter); 
                }
            }

            if (cantidad_espacios == texto.Length)
            {
                return true;
            }

            return false;
        }
        
        public bool validarExistenciaPieza(IRCVDbContext context,PiezaEntity piezaValidar)
        {
            if (context.piezas.Any(x => x.nombre == piezaValidar.nombre)
                )
               
            {
                return true;   
            }

            return false;
        }
        
        public PiezaDTO CreatePieza(PiezaEntity piezanew)
        {
            var i=0;
            try
            {
                if (validarExistenciaPieza(_context,piezanew) == true)
                {
                    error++;
                    mensajeError = "No se puede crear este pieza porque ya existe";
                    throw new RCVExceptions(mensajeError);
                }
                if ((String.IsNullOrEmpty(piezanew.nombre)||validarEspaciosBlancos(piezanew.nombre)))
                    
                {
                    error++;
                    mensajeError = "No se puede crear una pieza si alguno de estos datos esta vacio:nombres de la pieza";
                    throw new RCVExceptions(mensajeError);
                }
                else
                {
                    var data = _context.piezas.Add(this.Pieza);
                    i = _context.DbContext.SaveChanges();
                    var dataRespuesta = _context.piezas.Include(pieza=>pieza).Where(pieza => pieza.Id.Equals(piezanew.Id))
                        .Select(pieza => new PiezaDTO
                        {
                            nombre = pieza.nombre,
                        });
                    return dataRespuesta.First();
                }
            }
            catch (Exception ex)
            {
                throw new RCVExceptions(mensajeError);
            }

        }
        
        public PiezaEntity traerPieza(IRCVDbContext context,Guid id_pieza)
        {
            if (context.piezas.Any(x => x.Id == id_pieza ))
            {
                var pieza = context.piezas.
                    Where(b => b.Id==id_pieza).
                    Single();
                return pieza;
            }
            return null;
        }
        
        public string EliminarPieza(Guid id_pieza)
        {
            var i=0;
            
            var data =traerPieza(_context,id_pieza);
               
            var a=_context.piezas.Remove(data);
            i=_context.DbContext.SaveChanges();   
                
   
            
            return "Se elimino correctamente";
        }
        
        public PiezaDTO getPieza(Guid id)
        {
            try
            {
                var pieza = _context.piezas
                    .Where(b => b.Id == id)
                    .Select(p => new PiezaDTO
                    {
                        
                        nombre = p.nombre
                    });
                if(pieza == null){
                    throw new Exception("No existe ese pieza");
                }
                return pieza.ToList()[0];
            }
            catch(Exception ex)
            {
                throw new RCVExceptions("No se ha podido presentar la lista de piezas", ex.Message, ex);
            }
        }
        
       public PiezaDTO ActualizarPieza(PiezaEntity piezaCambios,Guid id_pieza)
        {
            
            var data =traerPieza(_context,id_pieza);
            data.nombre = piezaCambios.nombre;
            _context.piezas.Update(data);
            _context.DbContext.SaveChanges();   
            return _context.piezas.Where(x=>x.Id==data.Id).Select(x=>new PiezaDTO
            {
                nombre = x.nombre
                
            }).Single();
        }
        
        
    }
}