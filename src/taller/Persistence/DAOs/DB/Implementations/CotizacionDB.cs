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
using System.Regex;

namespace RCVUcabBackend.Persistence.DAOs.Implementations{

    public class CotizacionDB:ICotizacion
    {
        public string mensajeError = "Ocurrio un error inesperado ";
        private static DesignTimeDbContextFactory design = new DesignTimeDbContextFactory();
        private ITallerDbContext _context= design.CreateDbContext(null);

        public string CrearCotizacionDeReparacion(CotizacionTallerEntity cotizacion,string fechaInicioCoti,string fechaCulminacionCoti)
        {
            var i=0;
            var dateNow=DateTime.Now;
            var fechaInicio=new DateTime();
            var fechaCulminacion=new DateTime();
            var formatoFecha=new Regex(@"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|[2-9][0-9])\d\d$");
            var validarFormatoFechaCulminacion=true;
            var validarFormatoFechaInicio=true;
            try
            {

                if(fechaCulminacionCoti==null || fechaInicioCoti==null){
                    
                    mensajeError = "La fecha de inicio o de culminacion no pueden estar vacio";
                    throw new ExcepcionTaller(mensajeError);
                }else{
                    validarFormatoFechaCulminacion=formatoFecha.IsMatch(fechaCulminacionCoti);
                    validarFormatoFechaInicio=formatoFecha.IsMatch(fechaInicioCoti);
                }

                if(validarFormatoFechaInicio && validarFormatoFechaCulminacion){
                    fechaInicio=Convert.ToDateTime(fechaInicioCoti);
                    fechaCulminacion=Convert.ToDateTime(fechaCulminacionCoti);
                }else
                {
                    mensajeError = "La fecha de inicio o de culminacion no cumplen con el formato dd/mm/yyyy o alguno de estos esta vacio";
                    throw new ExcepcionTaller(mensajeError);
                }

                if(fechaInicio<dateNow || fechaCulminacion<dateNow){
                    
                    mensajeError = "La fecha de inicio o de culminacion no pueden ser menores a la actual";
                    throw new ExcepcionTaller(mensajeError);
                }else if(fechaInicio==fechaCulminacion){
                    
                    mensajeError = "La fecha de inicio o de culminacion no pueden ser iguales";
                    throw new ExcepcionTaller(mensajeError);
                }else if(fechaInicio>fechaCulminacion){
                    
                    mensajeError = "La fecha de inicio no puede ser una fecha despues de la de culminacion";
                    throw new ExcepcionTaller(mensajeError);
                }else if(cotizacion.costo_reparacion<=0){
                    
                    mensajeError = "El costo del precio de reparacion debe ser mayor a 0";
                    throw new ExcepcionTaller(mensajeError);
                }else if(cotizacion.usuario_taller==null){
                    
                    mensajeError = "El usuario del taller no existe";
                    throw new ExcepcionTaller(mensajeError);
                }
                else
                {
                    _context.Cotizaciones.Attach(cotizacion);
                    var dataCotizacion = _context.Cotizaciones.Add(cotizacion);
                    i=_context.DbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionTaller(mensajeError);
            }
            return "exito";
        }
    }
}