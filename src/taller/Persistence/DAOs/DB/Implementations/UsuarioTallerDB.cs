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
    public class UsuarioTallerDB:IUsuarioTaller
    {
        public string mensajeError = "Ocurrio un error inesperado ";
        private static DesignTimeDbContextFactory design = new DesignTimeDbContextFactory();
        private ITallerDbContext _context= design.CreateDbContext(null);

        public UsuarioTallerEntity traerUsuarioTaller(Guid id_usuario_taller)
        {
            if (_context.UsuariosTaller.Any(x => x.Id == id_usuario_taller ))
            {
                var usuarioTaller = _context.UsuariosTaller.
                    Include(b=>b.Telefonos).
                    Include(b=>b.taller).
                    Where(b => b.Id==id_usuario_taller).
                    Single();
                return usuarioTaller;
            }
            return null;
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

        public bool validarExistenciaUsuarioTaller(UsuarioTallerEntity usuarioTaller){

            if (_context.UsuariosTaller.Any(x => x.primer_nombre.Equals(usuarioTaller.primer_nombre) &&
                                                x.segundo_nombre.Equals(usuarioTaller.segundo_nombre) &&
                                                x.primer_apellido.Equals(usuarioTaller.primer_apellido) &&
                                                x.segundo_apellido.Equals(usuarioTaller.segundo_apellido) &&
                                                x.cargo.Equals(usuarioTaller.cargo) &&
                                                x.email.Equals(usuarioTaller.email)))
            {
                return true;   
            }

            return false;
        }
        public crearUsuarioTallerDTO crearUsuarioTaller(UsuarioTallerEntity usuarioTaller){
            
            var i=0;
            try
            {
                if (validarExistenciaUsuarioTaller(usuarioTaller) == true)
                {
                    
                    mensajeError = "No se puede crear este usuario del taller porque ya existe";
                    throw new ExcepcionTaller(mensajeError);
                }
                if ((String.IsNullOrEmpty(usuarioTaller.primer_nombre)||validarEspaciosBlancos(usuarioTaller.primer_nombre)) ||
                    (String.IsNullOrEmpty(usuarioTaller.segundo_nombre)||validarEspaciosBlancos(usuarioTaller.segundo_nombre)) ||
                    (String.IsNullOrEmpty(usuarioTaller.primer_apellido)||validarEspaciosBlancos(usuarioTaller.primer_apellido)) ||
                    (String.IsNullOrEmpty(usuarioTaller.segundo_apellido)||validarEspaciosBlancos(usuarioTaller.segundo_apellido)) ||
                    (String.IsNullOrEmpty(usuarioTaller.direccion)||validarEspaciosBlancos(usuarioTaller.direccion)) || 
                    (String.IsNullOrEmpty(usuarioTaller.cargo)||validarEspaciosBlancos(usuarioTaller.cargo)) || 
                    (String.IsNullOrEmpty(usuarioTaller.contraseña)||validarEspaciosBlancos(usuarioTaller.contraseña)))
                {
                    
                    mensajeError = "No se puede crar el usuaario taller si alguno de estos datos esta vacio: primer nombre,segundo nombre,primer apellido,segundo apellido,direccion,cargo,contraseña";
                    throw new ExcepcionTaller(mensajeError);
                }
                if(usuarioTaller.taller==null){
                    
                    mensajeError = "No se puede crar el usuaario taller si el taller no existe";
                    throw new ExcepcionTaller(mensajeError);
                }
                else
                {
                    _context.Talleres.Attach(usuarioTaller.taller);
                    var data = _context.UsuariosTaller.Add(usuarioTaller);
                    i=_context.DbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionTaller(mensajeError);
            }
            return new crearUsuarioTallerDTO{
                            primer_nombre=usuarioTaller.primer_nombre,
                            segundo_nombre=usuarioTaller.segundo_nombre,
                            primer_apellido=usuarioTaller.primer_apellido,
                            segundo_apellido=usuarioTaller.segundo_apellido,
                            direccion=usuarioTaller.direccion,
                            email=usuarioTaller.email,
                            contraseña=usuarioTaller.contraseña,
                            telefonos=usuarioTaller.Telefonos.Select(T=>new crearTelefonoDTO{
                                codigo_area=T.codigo_area,
                                numero_telefono=T.numero_telefono
                            }).ToList()
            };
        }

        public string EliminarUsuarioTaller(UsuarioTallerEntity usuario_taller)
        {
            var i=0;
            try
            {
                if (usuario_taller==null)
                {
                    mensajeError = "No existe el usuario del taller";
                    throw new ExcepcionTaller(mensajeError);
                }
                else
                {
                    usuario_taller.estado=CheckEstadoUsuarioTaller.Bloqueado;
                    var a=_context.UsuariosTaller.Update(usuario_taller);
                    i=_context.DbContext.SaveChanges();  
                }
   
            }catch (Exception ex)
            {
                throw new ExcepcionTaller(mensajeError);
            }
            return "Se elimino exitosamente";
        }

        public string ActualizarUsuarioTaller(UsuarioTallerEntity UsuariotallerCambios,UsuarioTallerEntity UsuariotallerSinCambios){
            var i=0;
            try
            {
                if (UsuariotallerSinCambios==null)
                {
                    mensajeError = "No existe el usuario del taller";
                    throw new ExcepcionTaller(mensajeError);
                }
                else
                {
                    if(!(String.IsNullOrEmpty(UsuariotallerCambios.primer_nombre)))
                    {
                        if (!(validarEspaciosBlancos(UsuariotallerCambios.primer_nombre)))
                        {
                            UsuariotallerSinCambios.primer_nombre = UsuariotallerCambios.primer_nombre;   
                        }
                    }
                    if(!(String.IsNullOrEmpty(UsuariotallerCambios.segundo_nombre)))
                    {
                        if (!(validarEspaciosBlancos(UsuariotallerCambios.segundo_nombre)))
                        {
                            UsuariotallerSinCambios.segundo_nombre = UsuariotallerCambios.segundo_nombre;
                        }
                    }
                    if(!(String.IsNullOrEmpty(UsuariotallerCambios.primer_apellido)))
                    {
                        if (!(validarEspaciosBlancos(UsuariotallerCambios.primer_apellido)))
                        {
                            UsuariotallerSinCambios.primer_apellido = UsuariotallerCambios.primer_apellido;   
                        }
                    }
                    if(!(String.IsNullOrEmpty(UsuariotallerCambios.segundo_apellido)))
                    {
                        if (!(validarEspaciosBlancos(UsuariotallerCambios.segundo_apellido)))
                        {
                            UsuariotallerSinCambios.segundo_apellido = UsuariotallerCambios.segundo_apellido;   
                        }
                    }
                    if(!(String.IsNullOrEmpty(UsuariotallerCambios.direccion)))
                    {
                        if (!(validarEspaciosBlancos(UsuariotallerCambios.direccion)))
                        {
                            UsuariotallerSinCambios.direccion = UsuariotallerCambios.direccion;   
                        }
                    }
                    if(!(String.IsNullOrEmpty(UsuariotallerCambios.cargo)))
                    {
                        if (!(validarEspaciosBlancos(UsuariotallerCambios.cargo)))
                        {
                            UsuariotallerSinCambios.cargo = UsuariotallerCambios.cargo;   
                        }
                    }
                    if(!(String.IsNullOrEmpty(UsuariotallerCambios.email)))
                    {
                        if (!(validarEspaciosBlancos(UsuariotallerCambios.email)))
                        {
                            UsuariotallerSinCambios.email = UsuariotallerCambios.email;   
                        }
                    }
                    if(!(String.IsNullOrEmpty(UsuariotallerCambios.contraseña)))
                    {
                        if (!(validarEspaciosBlancos(UsuariotallerCambios.contraseña)))
                        {
                            UsuariotallerSinCambios.contraseña = UsuariotallerCambios.contraseña;   
                        }
                    }

                    if (UsuariotallerCambios.Telefonos != null)
                    {
                        if (UsuariotallerCambios.Telefonos.Count != 0)
                        {
                            foreach (var telefono in UsuariotallerCambios.Telefonos)
                            {
                                UsuariotallerSinCambios.Telefonos.Add(telefono);   
                            }
                        }
                    }

                    _context.UsuariosTaller.Update(UsuariotallerSinCambios);
                    i=_context.DbContext.SaveChanges();   
                }
            }catch (Exception ex)
            {
                throw new ExcepcionTaller(mensajeError);
            }      
            return "Se actualizo exitosamente";
        }



    }
}