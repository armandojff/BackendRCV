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

    public class PiezasDB:IPiezas{
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

        public List<PiezasConsultDTO> ConsultarPiezasAReparar(AnalisisEntity analisis)
        {
            var listPiezsConsultar= new List<PiezasConsultDTO>();
            try
            {
                if (analisis==null)
                {
                    mensajeError = "No existe el analisis";
                    throw new ExcepcionTaller(mensajeError);
                }
                else{

                    foreach (var pieza in analisis.piezas)
                    {
                        var piezaConsulta=new PiezasConsultDTO();
                        if(pieza.estado==CheckEstadoPieza.reparar){
                            piezaConsulta.descripcion_pieza=pieza.descripcion_pieza;
                            piezaConsulta.estado=pieza.estado.ToString();
                            piezaConsulta.precio=pieza.precio;
                            listPiezsConsultar.Add(piezaConsulta);
                        }                        
                    }
                    return listPiezsConsultar;
                }
            }
            catch (Exception e)
            {
                throw new ExcepcionTaller(mensajeError);
            }
        }

        public PiezasEntity traerPieza(Guid id_pieza)
        {
            if (_context.Piezas.Any(x => x.Id == id_pieza ))
            {
                var pieza = _context.Piezas.Where(c => c.Id.Equals(id_pieza)).First();
                return pieza;
            }
            return null;
        }

        public PiezasConsultDTO EditarEstadoPieza(PiezasEntity pieza,CheckEstadoPieza estado)
        {
            var i=0;
            try
            {
                if (pieza==null)
                {
                    mensajeError = "No existe la pieza";
                    throw new ExcepcionTaller(mensajeError);
                }
                else
                {
                    pieza.estado=estado;
                    _context.Piezas.Update(pieza);
                    i=_context.DbContext.SaveChanges();   
                }
   
            }catch (Exception ex)
            {
                throw new ExcepcionTaller(mensajeError);
            }
            return _context.Piezas.Where(c => c.Id.Equals(pieza.Id)).Select(pieza=>new PiezasConsultDTO{
                descripcion_pieza=pieza.descripcion_pieza,
                estado=pieza.estado.ToString(),
                precio=pieza.precio                
            }).Single();
        }

        public PiezasConsultDTO EditardescripcionPieza(PiezasEntity PiezadescripcionVieja,string PiezadescripcionNueva)
        {
            var i=0;
            try
            {
                if (PiezadescripcionVieja==null)
                {
                    mensajeError = "No existe la pieza";
                    throw new ExcepcionTaller(mensajeError);
                }
                if ((String.IsNullOrEmpty(PiezadescripcionNueva)||validarEspaciosBlancos(PiezadescripcionNueva))){
                    mensajeError = "No se puede dejar en blanco la nueva descripcion del taller";
                    throw new ExcepcionTaller(mensajeError);
                }
                else
                {
                    PiezadescripcionVieja.descripcion_pieza=PiezadescripcionNueva;
                    _context.Piezas.Update(PiezadescripcionVieja);
                    i=_context.DbContext.SaveChanges();   
                }
   
            }catch (Exception ex)
            {
                throw new ExcepcionTaller(mensajeError);
            }
            return _context.Piezas.Where(c => c.Id.Equals(PiezadescripcionVieja.Id)).Select(pieza=>new PiezasConsultDTO{
                descripcion_pieza=pieza.descripcion_pieza,
                estado=pieza.estado.ToString(),
                precio=pieza.precio                
            }).Single();
        }
    }

}