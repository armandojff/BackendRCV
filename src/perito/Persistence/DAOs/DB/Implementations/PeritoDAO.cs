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
    public class PeritoDAO:IPeritoDAO
    {
        private static DesignTimeDbContextFactory desing = new DesignTimeDbContextFactory();
        //public readonly IRCVDbContext _context;
        private IRCVDbContext _context = desing.CreateDbContext(null);
        public UsuarioPeritoEntity Perito = new UsuarioPeritoEntity();
        public int error = 0;
        public string mensajeError = "Ocurrio un error inesperado";
        
        public PeritoDAO(){}

        public PeritoDAO(IRCVDbContext context)
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
        
        public bool validarExistenciaPerito(IRCVDbContext context,UsuarioPeritoEntity peritoValidar)
        {
            if (context.peritos.Any(x => x.nombres == peritoValidar.nombres && 
                                          x.apellidos.Equals(peritoValidar.apellidos) &&
                                          x.email.Equals(peritoValidar.email) &&
                                          x.contrasena.Equals(peritoValidar.contrasena)
                )
               )
            {
                return true;   
            }

            return false;
        }
       
        public void crearPeritoEntity(PeritoDTO T)
        {
            
            this.Perito.nombres=T.nombres;
            this.Perito.apellidos = T.apellidos;
            this.Perito.email = T.email;
            this.Perito.contrasena = T.contrasena;
            this.Perito.CreatedAt=DateTime.Now;
            this.Perito.UpdatedAt = null;
            this.Perito.CreatedBy = null;
            this.Perito.UpdatedBy = null;
        }

        public PeritoDTO CreatePerito(UsuarioPeritoEntity peritonew)
        {
            var i = 0;
            try
            {
                if (validarExistenciaPerito(_context, peritonew) == true)
                {
                    error++;
                    mensajeError = "No se puede crear este perito porque ya existe";
                    throw new RCVExceptions(mensajeError);
                }

                if ((String.IsNullOrEmpty(peritonew.nombres) || validarEspaciosBlancos(peritonew.nombres)) ||
                    (String.IsNullOrEmpty(peritonew.apellidos) || validarEspaciosBlancos(peritonew.apellidos)) ||
                    (String.IsNullOrEmpty(peritonew.email) || validarEspaciosBlancos(peritonew.email)) ||
                    (String.IsNullOrEmpty(peritonew.contrasena) || validarEspaciosBlancos(peritonew.contrasena)))

                {
                    error++;
                    mensajeError =
                        "No se puede crar un perito si alguno de estos datos esta vacio:nombres del perito, apellidos del perito, email y contrasena de perito";
                    throw new RCVExceptions(mensajeError);
                }
                else
                {
                    var data = _context.peritos.Add(peritonew);
                    i = _context.DbContext.SaveChanges();
                    var dataRespuesta = _context.peritos.Include(perito=>perito).Where(perito => perito.Id.Equals(peritonew.Id))
                        .Select(perito => new PeritoDTO
                        {
                            nombres = perito.nombres,
                            apellidos = perito.apellidos,
                            email = perito.email,
                            contrasena = perito.contrasena,
                        });
                    return dataRespuesta.First();
                }
            }
            catch (Exception ex)
            {
                throw new RCVExceptions(mensajeError);
            }

        }



        public UsuarioPeritoEntity traerPerito(IRCVDbContext context,Guid id_perito)
        {
            if (context.peritos.Any(x => x.Id == id_perito ))
            {
                var perito = context.peritos.
                    Where(b => b.Id==id_perito).
                    Single();
                return perito;
            }
            return null;
        }
        
        public string EliminarPerito(Guid id_perito)
        {
            var i=0;
            
            var data =traerPerito(_context,id_perito);
               
            var a=_context.peritos.Remove(data);
            i=_context.DbContext.SaveChanges();   
                
   
            
            return "Se elimino exitosamente";
        }
        
        public PeritoDTO getPerito(Guid id)
        {
            try
            {
                var peritos = _context.peritos
                    .Where(b => b.Id == id)
                    .Select(p => new PeritoDTO
                    {
                        
                        nombres = p.nombres
                    });
                if(peritos == null){
                    throw new Exception("No existe ese perito");
                }
                return peritos.ToList()[0];
            }
            catch(Exception ex)
            {
                throw new RCVExceptions("No se ha podido presentar la lista de peritos", ex.Message, ex);
            }
        }
        
        public PeritoDTO ActualizarPerito(UsuarioPeritoEntity peritoCambios,Guid id_perito)
        {
            
            var data =traerPerito(_context,id_perito);
               
                    
            data.nombres = peritoCambios.nombres;   
                       
                    
            data.apellidos = peritoCambios.apellidos;
                      
            data.email = peritoCambios.email;   
                      
            data.contrasena = peritoCambios.contrasena;
                        


            _context.peritos.Update(data);
            _context.DbContext.SaveChanges();
            return _context.peritos.Where(x=>x.Id==data.Id).Select(x=>new PeritoDTO
            {
                nombres = x.nombres,
                apellidos = x.apellidos,
                email = x.email,
                contrasena = x.contrasena,
                
            }).Single();
        }

      
        
    }
}