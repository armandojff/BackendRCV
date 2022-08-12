using System;
using System.Collections.Generic;
using System.Linq;
using RCVUcabBackend.Exceptions;
using RCVUcabBackend.Persistence.Database;
using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.Persistence.Entities.ChecksEntitys;
using Microsoft.EntityFrameworkCore;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.Persistence.DAOs.Interfaces;
using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.Persistence.Entities;

namespace RCVUcabBackend.Persistence.DAOs.Implementations{
    public class TelefonoDB:ITelefono
    {
        public string mensajeError = "Ocurrio un error inesperado ";
        private static DesignTimeDbContextFactory design = new DesignTimeDbContextFactory();
        private ITallerDbContext _context= design.CreateDbContext(null);

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

        public bool verificarTelefono(TelefonoEntity telefonoValidar)
        {
            if (_context.Telefonos.Any(x => x.codigo_area == telefonoValidar.codigo_area && 
                                            x.numero_telefono==telefonoValidar.numero_telefono))
            {
                return true;   
            }
            return false;
        }

        public ICollection<TelefonoEntity> AsignarTelefonosExistente(ICollection<TelefonoEntity> telefonoValidar,UsuarioTallerEntity usuarioTaller)
        {
            ICollection<TelefonoEntity> nuevaLista=new List<TelefonoEntity>();
            var i=0;
            if(telefonoValidar!=null){
                foreach (TelefonoEntity telefonos in telefonoValidar)
                {
                    if (verificarTelefono(telefonos))
                    {
                        i++;
                        TelefonoEntity telefonoExistente = _context.Telefonos.
                            Include(b=>b.usuario_taller).
                            Where(b =>b.codigo_area==telefonos.codigo_area &&
                                    b.numero_telefono==telefonos.numero_telefono).First();
                            nuevaLista.Add(telefonoExistente);
                    }
                    else
                    {
                        telefonos.usuario_taller=usuarioTaller;
                        _context.Telefonos.Attach(telefonos);
                        _context.Telefonos.Add(telefonos);
                        _context.DbContext.SaveChanges();
                        nuevaLista.Add(telefonos);
                    }
                }
                return nuevaLista;
            }else
            {
                return null;
            }
        }

        
        public bool crearTelefonosDeLista(ICollection<TelefonoEntity> listaTelefonos){
            
            var i=0;
            try
            {
                foreach (var telefono in listaTelefonos)
                {
                    if((String.IsNullOrEmpty(telefono.codigo_area)||validarEspaciosBlancos(telefono.codigo_area)) ||
                    (String.IsNullOrEmpty(telefono.numero_telefono)||validarEspaciosBlancos(telefono.numero_telefono))){
                        mensajeError = "No se puede crear el telefono del usuario si alguno de estos datos esta vacio: codigo area o numero de telefono";
                        throw new ExcepcionTaller(mensajeError);
                    }else
                    {
                        _context.Telefonos.Add(telefono);
                        _context.DbContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionTaller(mensajeError);
            }
            return true;
        }


    }
}