using perito.BussinesLogic.DTOs;
using perito.Persistence.Entities;

namespace perito.BussinesLogic.Mappers;

public class PeritoMapper
{
    public static UsuarioPeritoEntity MapDtoToEntity(PeritoDTO dto){
        var perito=new UsuarioPeritoEntity{
            nombres= dto.nombres,
            apellidos= dto.apellidos,
            contrasena= dto.contrasena,
            email = dto.email,

        };
        return perito;
    }

    public static PeritoDTO MapEntityToDto(UsuarioPeritoEntity entity){
        var perito=new PeritoDTO{
            nombres= entity.nombres,
            apellidos= entity.apellidos,
            contrasena= entity.contrasena,
            email= entity.email,
        };
        return perito;
    }
    
}