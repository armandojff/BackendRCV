using perito.BussinesLogic.DTOs;
using perito.Persistence.Entities;

namespace perito.BussinesLogic.Mappers{
    public class AnalisisMapper
    {
        public static AnalisisEntity MapDtoToEntity(AnalisisDTO dto){
            var analisis=new AnalisisEntity{
                id_incidente = dto.id_incidente,
                id_perito = dto.id_perito,
                culpable = dto.culpable,
                piezas = PiezaMapper.MapListDtoToListEntity(dto.piezas)

            };
            return analisis;
        }

        public static AnalisisDTO MapEntityToDto(AnalisisEntity entity){
            var analisis=new AnalisisDTO{
                id_incidente = entity.id_incidente,
                id_perito = entity.id_perito,
                culpable = entity.culpable,
                piezas = PiezaMapper.MapListEntityToListDto(entity.piezas)
            };
            return analisis;
        }

    }
}