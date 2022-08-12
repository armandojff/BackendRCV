using administrador.BussinesLogic.DTOs;
using administrador.Persistence.Entities;

namespace administrador.BussinesLogic.Mappers;

public class PagosMapper
{
    public static PagosEntity mapDtoToEntity(PagosDTO dto)
    {
        var entity = new PagosEntity
        {
            AnalisisEntityId = dto.idAnalisis,
            UserEntityId = dto.idTaller,
            fechaInicio =Convert.ToDateTime( dto.fecha_inicio),
            fechaFin = Convert.ToDateTime(dto.fecha_culminacion),
            costo = dto.costo_reparacion,
        };
        return entity;
    }
}