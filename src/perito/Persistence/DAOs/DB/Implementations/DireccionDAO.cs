using System;
using System.Linq;
using perito.BussinesLogic.DTOs;
using perito.Exceptions;
using perito.Persistence.Database;
using perito.Persistence.Entities;

namespace perito.Persistence.DAOs.Implementations
{
    public class DireccionDAO
    {
         public readonly IRCVDbContext _context;
        public DireccionEntity Direccion = new DireccionEntity();
        public int error = 0;
        public string mensajeError = "Ocurrio un error inesperado";
        

        public DireccionDAO(IRCVDbContext context)
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
        
     
        
        public void crearDireccionEntity(DireccionDTO T)
        {
            var i2=0;
            
            this.Direccion.calle=T.calle;
            this.Direccion.municipio = T.municipio;
            this.Direccion.parroquia = T.parroquia;
            this.Direccion.UpdatedAt = null;
            this.Direccion.CreatedBy = null;
            this.Direccion.UpdatedBy = null;
        }
        
        public int CreateDireccion(DireccionDTO direccion)
        {
            var i = 0;

            crearDireccionEntity(direccion);
                    var data = _context.direcciones.Add(this.Direccion);
                    i=_context.DbContext.SaveChanges();
                
            
            return i;
        }
        
        
        
        

      
        
    
    }
}