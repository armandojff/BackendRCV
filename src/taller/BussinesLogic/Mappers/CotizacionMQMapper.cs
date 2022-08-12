using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.BussinesLogic.DTOs.DTOMQ;

using RCVUcabBackend.BussinesLogic.Mappers;
using RCVUcabBackend.Persistence.Entities.ChecksEntitys;

namespace RCVUcabBackend.BussinesLogic.Mappers{
    public class CotizacionMQMapper
    {
        public static CotizacionMQ MapDtoToEntity(CotizacionTallerEntity dto,string fechaInicio,string fechaCulminacion){
            var cotizacionMQ=new CotizacionMQ{
                idAnalisis=dto.idAnalisis,
                idTaller=dto.usuario_taller.taller.Id,
                fecha_inicio=fechaInicio,
                fecha_culminacion=fechaCulminacion,
                costo_reparacion=(int) dto.costo_reparacion
            };
            return cotizacionMQ;
        }
    }
}