using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.BussinesLogic.Mappers;
using RCVUcabBackend.Persistence.Entities.ChecksEntitys;

namespace RCVUcabBackend.BussinesLogic.Mappers{
    public class CotizacionMapper
    {
        public static CotizacionTallerEntity MapDtoToEntity(CrearCotizacionDTO dto){
            var taller=new CotizacionTallerEntity{
                cantidad_piezas_reparar=dto.cantidad_piezas_reparar,
                costo_reparacion=dto.costo_reparacion,
                fecha_culminacion=Convert.ToDateTime(dto.fecha_culminacion),
                fecha_inicio=Convert.ToDateTime(dto.fecha_inicio),
                estado=CheckEstadoCotizacionTaller.Activo,
                usuario_taller=null,
                idAnalisis=dto.idAnalisis
            };
            return taller;
        }
    }
}