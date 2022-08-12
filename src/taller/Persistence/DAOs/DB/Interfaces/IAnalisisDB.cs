using System;
using System.Collections.Generic;
using RCVUcabBackend.Persistence.Entities.ChecksEntitys;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
namespace RCVUcabBackend.Persistence.DAOs.Interfaces
{
    public interface IAnalisis
    {
        public List<AnalisisConsultaDTO> ConsultarRequerimientosAsignados(Guid id_taller);
        public List<AnalisisConsultaDTO> ConsultarRequerimientosAsignadosPorFiltro(Guid id_taller,CheckEstadoAnalisisAccidente filtro);
        

        /*
        
        public int AsosciarFaacturaConOrdenPago(Guid id_orden_pago,OrdenDePagoAsociarFacturaDTO facturaOrdenPago);
        public int ActualizarUsuarioTaller(ActualizarUsuarioTallerDTO tallerCambios,Guid id_usuario_taller);*/

    }
}