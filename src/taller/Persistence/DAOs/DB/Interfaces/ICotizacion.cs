using System;
using System.Collections.Generic;
using RCVUcabBackend.Persistence.Entities.ChecksEntitys;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
namespace RCVUcabBackend.Persistence.DAOs.Interfaces
{
    public interface ICotizacion
    {
        public string CrearCotizacionDeReparacion(CotizacionTallerEntity cotizacion,string fechaInicioCoti,string fechaCulminacionCoti);
        
        /*
        public int AsosciarFaacturaConOrdenPago(Guid id_orden_pago,OrdenDePagoAsociarFacturaDTO facturaOrdenPago);
        public int crearUsuarioTaller(crearUsuarioTallerDTO usuarioTaller,Guid idTaller);

        public int EliminarUsuarioTaller(Guid id_usuario_taller);

        public int ActualizarUsuarioTaller(ActualizarUsuarioTallerDTO tallerCambios,Guid id_usuario_taller);*/

    }
}