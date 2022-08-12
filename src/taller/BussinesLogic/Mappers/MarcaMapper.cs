using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.BussinesLogic.DTOs;

namespace RCVUcabBackend.BussinesLogic.Mappers
{
    class MarcaMapper
    {

        public static List<MarcaDTO> MapListEntityToListDto(ICollection<MarcaCarroEntity> listaMarcasEntity){
            List<MarcaDTO> listaMarcaDTO=new List<MarcaDTO>();
            foreach (var marcaEntity in listaMarcasEntity)
            {
                listaMarcaDTO.Add(new MarcaDTO{
                    nombre_marca=marcaEntity.nombre_marca,
                    
                });
            }
            return listaMarcaDTO;
        }


        public static ICollection<MarcaCarroEntity> MapListDtoToListEntity(List<MarcaDTO> listaMarcasDTO){
            List<MarcaCarroEntity> listaMarcaEntity=new List<MarcaCarroEntity>();
            foreach (var marcaDTO in listaMarcasDTO)
            {
                listaMarcaEntity.Add(new MarcaCarroEntity{
                    nombre_marca=marcaDTO.nombre_marca,
                    CreatedAt=null,
                    CreatedBy=null,
                    UpdatedAt=null,
                    UpdatedBy=null
                });
            }
            return listaMarcaEntity;
        }
    }
    
}