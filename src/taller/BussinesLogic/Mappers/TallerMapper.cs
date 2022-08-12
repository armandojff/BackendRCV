using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.BussinesLogic.Mappers;


namespace RCVUcabBackend.BussinesLogic.Mappers{
    public class TallerMapper
    {
        public static TallererEntity MapDtoToEntity(TallerDTO dto){
            var taller=new TallererEntity{
                nombre_taller=dto.nombre_taller,
                direccion=dto.direccion,
                cumplimiento=0,
                RIF=dto.RIF,
                estado=0,
                marcas=MarcaMapper.MapListDtoToListEntity(dto.Marcac_Carros),
                CreatedAt=null,
                UsuariosTaller=null

            };
            return taller;
        }

        public static TallerDTO MapEntityToDto(TallererEntity entity){
            var taller=new TallerDTO{
                nombre_taller=entity.nombre_taller,
                direccion=entity.direccion,
                RIF=entity.RIF,
                estado=entity.estado,
                Marcac_Carros=MarcaMapper.MapListEntityToListDto(entity.marcas)
            };
            return taller;
        }

    }
}