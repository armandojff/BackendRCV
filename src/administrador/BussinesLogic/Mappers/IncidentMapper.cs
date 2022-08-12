using administrador.BussinesLogic.DTOs;
using administrador.Persistence.Entities;

namespace administrador.BussinesLogic.Mappers;

public class IncidentMapper
{
    public static IncidentesEntity mapDtoToEntity(IncidentesDTO dto)
    {
        var entity = new IncidentesEntity
        {
            fecha = dto.fecha,
            ubicacion = dto.ubicacion,
            descripcion = dto.descripcion,
            PolizaEntityId = dto.PolizaEntityId
            
        };
        return entity;
    }
}