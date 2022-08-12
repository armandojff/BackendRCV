using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.BussinesLogic.DTOs;

namespace RCVUcabBackend.BussinesLogic.Mappers
{
    class TelefonoMapper
    {

        /*public static List<MarcaDTO> MapListEntityToListDto(ICollection<MarcaCarroEntity> listaMarcasEntity){
            List<MarcaDTO> listaMarcaDTO=new List<MarcaDTO>();
            foreach (var marcaEntity in listaMarcasEntity)
            {
                listaMarcaDTO.Add(new MarcaDTO{
                    nombre_marca=marcaEntity.nombre_marca,
                    
                });
            }
            return listaMarcaDTO;
        }*/


        public static ICollection<TelefonoEntity> MapListDtoToListEntity(ICollection<crearTelefonoDTO> listaTelefonosDTO){
            List<TelefonoEntity> listaTelefonosEntity=new List<TelefonoEntity>();
            if(listaTelefonosDTO!=null){
                foreach (var telefonoDTO in listaTelefonosDTO)
                {
                    listaTelefonosEntity.Add(new TelefonoEntity{
                        codigo_area=telefonoDTO.codigo_area,
                        numero_telefono=telefonoDTO.numero_telefono,
                        CreatedAt=null,
                        CreatedBy=null,
                        UpdatedAt=null,
                        UpdatedBy=null
                    });
                }
                return listaTelefonosEntity;
            }else{return null;}
        }
    }
    
}