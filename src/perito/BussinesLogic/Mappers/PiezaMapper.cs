using perito.BussinesLogic.DTOs;
using perito.Persistence.Entities;

namespace perito.BussinesLogic.Mappers{

    public class PiezaMapper
    {
        public static List<PiezaDTO> MapListEntityToListDto(ICollection<PiezaEntity> listaPiezaEntity)
        {
            List<PiezaDTO> listaPiezaDTO = new List<PiezaDTO>();
            foreach (var piezaEntity in listaPiezaEntity)
            {
                listaPiezaDTO.Add(new PiezaDTO
                {
                    nombre = piezaEntity.nombre,

                });
            }

            return listaPiezaDTO;
        }


        public static ICollection<PiezaEntity> MapListDtoToListEntity(List<PiezaDTO> listaPiezaDTO)
        {
            List<PiezaEntity> listaPiezaEntity = new List<PiezaEntity>();
            foreach (var piezaDTO in listaPiezaDTO)
            {
                listaPiezaEntity.Add(new PiezaEntity
                {
                    nombre = piezaDTO.nombre,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "a",
                    UpdatedAt = DateTime.Now,
                    UpdatedBy = "a"
                });
            }

            return listaPiezaEntity;
        }
        
        public static PiezaEntity MapDtoToEntity(PiezaDTO dto){
            var pieza=new PiezaEntity{
                nombre= dto.nombre,

            };
            return pieza;
        }

        public static PiezaDTO MapEntityToDto(PiezaEntity entity){
            var pieza=new PiezaDTO{
                nombre= entity.nombre,

            };
            return pieza;
            
        }
    }
}