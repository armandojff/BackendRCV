using System;
using System.Collections.Generic;
using System.Linq;
using backendRCVUcab.Exceptions;
using backendRCVUcab.Persistence.Database;
using backendRCVUcab.Persistence.Entities;
using backendRCVUcab.Persistence.Entities.ChecksEntitys;
using Microsoft.EntityFrameworkCore;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.Persistence.DAOs.Interfaces;


namespace RCVUcabBackend.Persistence.DAOs.Implementations
{
    public class CotizacionDao : ICotizacionDAO
    {
        
        public CotizacionEntity Cotizacion = new CotizacionEntity();
        
        public List<PiezaEntity> listaPiezas= new List<PiezaEntity>();
        
        private static DesignTimeDbContextFactory desing = new DesignTimeDbContextFactory();
        
        private IRCVDbContext _context = desing.CreateDbContext(null);
        
        public string mensajeError = "Error en el Dao de Cotizacion";
        
        public SolicitudDao solicitudDao = ProveedorDAOFactory.CreateSolicitudDB();

        
        
        
        public bool verificarPieza(IRCVDbContext context,PiezaDTO piezaValidar)
        {
            if (context.Piezas.Any(x => x.nombre == piezaValidar.nombre))
            {
                return true;   
            }
            return false;
        }

        public bool AsignarPiezaExistente(IRCVDbContext context,PiezaDTO piezaValidar)
        {
            if (verificarPieza( context, piezaValidar))
            {
                var pieza = context.Piezas.
                    Where(b => b.nombre.Equals(piezaValidar.nombre)).
                    First();
                this.listaPiezas.Add(pieza);
                return true;   
            }
            return false;
        }
        
        public void createCotizacionEntity(CotizacionDTO C)
        {
            var i2 = 0;
            var pieza_ent  = new PiezaEntity();
            var cot_ent = new ProveedorEntity();
            
            foreach (var piezaCotizacion in C.piezas)
            {
                if (!AsignarPiezaExistente(_context, piezaCotizacion))
                {
                    var pc=new PiezaEntity();
                    pc.nombre = piezaCotizacion.nombre;
                    pc.tipo = piezaCotizacion.tipo;
                    pc.costo = 0;
                    pc.CreatedAt=DateTime.Now;
                    pc.CreatedBy = null;
                    pc.UpdatedAt = null;
                    pc.UpdatedBy = null;
                    listaPiezas.Add(pc);
                    _context.Piezas.Add(pc);
                    i2=_context.DbContext.SaveChanges();   
                }
            }

             
            var solicitud = new SolicitudEntity();
            solicitud = solicitudDao.traerSolicitud(_context, C.idSolicitud);
            
            solicitud.estado = SolicitudCheck.Cotizado;
            _context.Solicitudes.Update(solicitud);
            var i=_context.DbContext.SaveChanges();


            this.Cotizacion.costo_total = C.costo_total;
            this.Cotizacion.piezas = listaPiezas;
            this.Cotizacion.idProveedor = C.idProvedor;
            this.Cotizacion.idAnalisis = C.idSolicitud;
            this.Cotizacion.idUsuarioTaller = C.idUsuarioTaller;
            this.Cotizacion.CreatedAt=DateTime.Now;
            this.Cotizacion.UpdatedAt = null;
            this.Cotizacion.CreatedBy = null;
            this.Cotizacion.UpdatedBy = null;
        }
        
        public CotizacionDTO createCotizacion( CotizacionDTO coti)
        {
            var i = 0;
            try
            {
                createCotizacionEntity(coti);
                var data = _context.Cotizaciones.Add(this.Cotizacion);
                i=_context.DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new RCVExceptions(mensajeError);
            }

            return coti;
        }
    }
}