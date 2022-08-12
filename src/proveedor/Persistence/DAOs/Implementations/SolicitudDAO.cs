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
    public class SolicitudDao:ISolicitudDAO
    {
        public SolicitudEntity Solicitud = new SolicitudEntity();
        public int error = 0;
        public string mensajeError = "Ocurrio un error inesperado ";
        public ICollection<PiezaEntity> listaPiezas= new List<PiezaEntity>();
        public ICollection<ProveedorEntity> listaProveedores= new List<ProveedorEntity>();
        
        private static DesignTimeDbContextFactory desing = new DesignTimeDbContextFactory();
        private IRCVDbContext _context = desing.CreateDbContext(null);
        
        
      
        


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
        
        
        public bool verificarProveedor(IRCVDbContext context,ProveedorDTO proveedorValidar)
        {
            if (context.Proveedores.Any(x => x.nombre == proveedorValidar.nombre))
            {
                return true;   
            }
            return false;
        }

        public bool AsignarProveedorExistente(IRCVDbContext context,ProveedorDTO proveedorValidar)
        {
            if (verificarProveedor( context, proveedorValidar))
            {
                var proveedor = context.Proveedores.
                    Where(b => b.nombre.Equals(proveedorValidar.nombre)).
                    First();
                this.listaProveedores.Add(proveedor);
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

        public bool validarExistenciaSolicitud(IRCVDbContext context,SolicitudDTO solicitudValidar)
        {
            if (context.Solicitudes.Any(x => x.nombre == solicitudValidar.nombre )
                                                 
                
                )
            {
                return true;   
            }

            return false;
        }

        public void crearSolicitudEntity(SolicitudDTO S)
        {
            var i2=0;
            var ps  = new PiezaEntity();
            var prs = new ProveedorEntity();
            foreach (var piezasolicitud in S.piezas)
            {
                if (!AsignarPiezaExistente(_context, piezasolicitud))
                {
                    ps=new PiezaEntity();
                    ps.nombre = piezasolicitud.nombre;
                    ps.tipo = piezasolicitud.tipo;
                    ps.costo = 0;
                    ps.CreatedAt=DateTime.Now;
                    ps.CreatedBy = null;
                    ps.UpdatedAt = null;
                    ps.UpdatedBy = null;
                    listaPiezas.Add(ps);
                    _context.Piezas.Add(ps);
                    i2=_context.DbContext.SaveChanges();   
                }
            }
            
            foreach (var proveedorsolicitud in S.proveedores)
            {
                if (!AsignarProveedorExistente(_context, proveedorsolicitud))
                {
                    prs=new ProveedorEntity();
                    prs.nombre = proveedorsolicitud.nombre;
                    prs.direccion = proveedorsolicitud.direccion;
                    prs.telefono = proveedorsolicitud.telefono;
                    prs.CreatedAt=DateTime.Now;
                    prs.CreatedBy = null;
                    prs.UpdatedAt = null;
                    prs.UpdatedBy = null;
                    listaProveedores.Add(prs);
                }
            }

            this.Solicitud.nombre = S.nombre;
            this.Solicitud.piezas = listaPiezas;
            this.Solicitud.proveedores = listaProveedores;
            this.Solicitud.estado = SolicitudCheck.Pendiente;
            this.Solicitud.idAnalisis = S.idAnalisis;
            this.Solicitud.idUsuarioTaller = S.idUsuarioTaller;
            this.Solicitud.CreatedAt=DateTime.Now;
            this.Solicitud.UpdatedAt = null;
            this.Solicitud.CreatedBy = null;
            this.Solicitud.UpdatedBy = null;
        }

        public SolicitudDTO CreateSolicitud(SolicitudDTO solicitud)
        {
            var i=0;
            try
            {
                if (validarExistenciaSolicitud(_context,solicitud) == true)
                {
                    error++;
                    mensajeError = "No se puede crear esta solicitud porque ya existe";
                    throw new RCVExceptions(mensajeError);
                }
                if ((String.IsNullOrEmpty(solicitud.nombre)||validarEspaciosBlancos(solicitud.nombre)) ||
                    (String.IsNullOrEmpty(solicitud.estado)||validarEspaciosBlancos(solicitud.estado)) ||
                    solicitud.piezas.Count==0)
                {
                    error++;
                    mensajeError = "No se puede crar una Solicitud si alguno de estos datos esta vacio:nombre de la solicitud, estado, id Analisis y id del usuario taller ";
                    throw new RCVExceptions(mensajeError);
                }
                else
                {
                    crearSolicitudEntity(solicitud);
                    var data = _context.Solicitudes.Add(this.Solicitud);
                    i=_context.DbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new RCVExceptions(mensajeError);
            }
            return solicitud;
        }
        
        public SolicitudEntity traerSolicitud(IRCVDbContext context,Guid id_solicitud)
        {
            if (context.Solicitudes.Any(x => x.Id == id_solicitud ))
            {
                var solicitud = context.Solicitudes.
                    Where(b => b.Id==id_solicitud).
                    Single();
                return solicitud;
            }
            return null;
        }
        
          public SolicitudDTO declinarParticipacion(Guid id_solicitud,Guid id_proveedor)
          {
              var i=0;
              try
              {
                  var solicitud = new SolicitudEntity();
                      solicitud = traerSolicitud(_context, id_solicitud);

                  if (solicitud == null)
                  {
                      error++;
                      mensajeError = "No existe la solicitud";
                      throw new RCVExceptions(mensajeError);
                  }

                  
                  solicitud.estado = SolicitudCheck.Declinado;
                  _context.Solicitudes.Update(solicitud);
                  i=_context.DbContext.SaveChanges();
              }
              catch (Exception ex)
              {
                  throw new RCVExceptions(mensajeError);
              }
              return new SolicitudDTO();
          }

         
    }
}