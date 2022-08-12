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

namespace RCVUcabBackend.Persistence.DAOs.Implementations
{
    public class TallerDB:ITallerDB
    {   
        public string mensajeError = "Ocurrio un error inesperado ";
        private static DesignTimeDbContextFactory design = new DesignTimeDbContextFactory();
        private ITallerDbContext _context= design.CreateDbContext(null);

        public bool validarExistenciaTaller(TallererEntity tallerValidar)
        {
            if (_context.Talleres.Any(x => x.nombre_taller == tallerValidar.nombre_taller && 
                                                    x.direccion.Equals(tallerValidar.direccion) &&
                                                    x.RIF.Equals(tallerValidar.RIF)
                )
                )
            {
                return true;   
            }

            return false;
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

        public bool verificarMarca(MarcaCarroEntity marcaValidar)
        {
            if (_context.Marcas.Any(x => x.nombre_marca == marcaValidar.nombre_marca))
            {
                return true;   
            }
            return false;
        }

        public TallererEntity traerTaller(Guid id_taller)
        {
            if (_context.Talleres.Any(x => x.Id == id_taller ))
            {
                var taller = _context.Talleres.
                    Where(b => b.Id==id_taller).
                    First();
                return taller;
            }
            return null;
        }

        public TallerDTO crearTaller(TallererEntity tallerNuevo)
        {
            try
            {
                if (validarExistenciaTaller(tallerNuevo) == true)
                {
                    mensajeError = "No se puede crear este taller porque ya existe";
                    throw new ExcepcionTaller(mensajeError);
                }else if ((String.IsNullOrEmpty(tallerNuevo.direccion)||validarEspaciosBlancos(tallerNuevo.direccion)) ||
                    (String.IsNullOrEmpty(tallerNuevo.nombre_taller)||validarEspaciosBlancos(tallerNuevo.nombre_taller)) ||
                    (String.IsNullOrEmpty(tallerNuevo.RIF)||validarEspaciosBlancos(tallerNuevo.RIF)) ||
                    tallerNuevo.marcas.Count == 0)
                {
                    mensajeError = "No se puede crar un taller si alguno de estos datos esta vacio:nombre del taller, direccrioon, RIF y marcas de carros";
                    throw new ExcepcionTaller(mensajeError);
                }else
                {
                    foreach (var marca in tallerNuevo.marcas)
                    {
                        if(verificarMarca(marca)){
                            _context.Marcas.Attach(marca);
                        }
                    }
                    _context.Talleres.Add(tallerNuevo);
                    _context.DbContext.SaveChanges();
                    var dataRespuesta=_context.Talleres.
                    Include(taller=> taller.marcas).
                    Where(taller=>taller.Id.Equals(tallerNuevo.Id)).
                    Select(taller=>new TallerDTO{
                        nombre_taller=taller.nombre_taller,
                        direccion=taller.direccion,
                        RIF=taller.RIF,
                        estado=taller.estado,
                        Marcac_Carros=taller.marcas.Select(marca=> new MarcaDTO{
                            nombre_marca=marca.nombre_marca
                        }).ToList()
                    });
                    return dataRespuesta.First();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                throw new ExcepcionTaller(mensajeError);
            }
        }

        public string EliminarTaller(Guid id_taller)
        {
            var i=0;
            try
            {
                var data =traerTaller(id_taller);
                if (data==null)
                {
                    mensajeError = "No existe el talled";
                    throw new ExcepcionTaller(mensajeError);
                }
                else
                {
                    var a=_context.Talleres.Remove(data);
                    i=_context.DbContext.SaveChanges();   
                    return "Se elimino exitosamente";
                }
   
            }catch (Exception ex)
            {
                throw new ExcepcionTaller(mensajeError);
            }
        }

        public TallerDTO ActualizarTaller(TallererEntity tallerCambios,Guid id_taller)
        {
            try
            {
                var data =traerTaller(id_taller);
                if (data==null)
                {
                    mensajeError = "No existe el talled";
                    throw new ExcepcionTaller(mensajeError);
                }
                else
                {
                    if(!(String.IsNullOrEmpty(tallerCambios.direccion)))
                    {
                        if (!(validarEspaciosBlancos(tallerCambios.direccion)))
                        {
                            data.direccion = tallerCambios.direccion;   
                        }
                    }
                    if(!(String.IsNullOrEmpty(tallerCambios.nombre_taller)))
                    {
                        if (!(validarEspaciosBlancos(tallerCambios.nombre_taller)))
                        {
                            data.nombre_taller = tallerCambios.nombre_taller;
                        }
                    }
                    if(!(String.IsNullOrEmpty(tallerCambios.RIF)))
                    {
                        if (!(validarEspaciosBlancos(tallerCambios.RIF)))
                        {
                            data.RIF = tallerCambios.RIF;   
                        }
                    }
                    if(!(String.IsNullOrEmpty(tallerCambios.RIF)))
                    {
                        if (!(validarEspaciosBlancos(tallerCambios.RIF)))
                        {
                            data.estado = tallerCambios.estado;   
                        }
                    }

                    if (tallerCambios.marcas != null)
                    {
                        if (tallerCambios.marcas.Count != 0)
                        {
                            data.marcas=tallerCambios.marcas;
                        }
                    }

                    _context.Talleres.Update(data);
                    _context.DbContext.SaveChanges();
                    return _context.Talleres.
                    Where(x=>x.Id==data.Id).
                    Select(x=>new TallerDTO{
                        nombre_taller=x.nombre_taller,
                        direccion=x.direccion,
                        RIF=x.RIF,
                        estado=x.estado,
                        Marcac_Carros=x.marcas.Select(marca=> new MarcaDTO{
                            nombre_marca=marca.nombre_marca
                        }).ToList()
                    }).Single();
                }
   
            }catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        
    }
}