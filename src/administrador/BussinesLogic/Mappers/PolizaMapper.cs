using administrador.BussinesLogic.DTOs;
using administrador.Persistence.Entities;

namespace administrador.BussinesLogic.Mappers;

public class PolizaMapper
{
    public static PolizaEntity mapDtoToEntity(PolizaSimpleDTO dto)
    {
        var entity = new PolizaEntity
        {
            tipo = dto.tipo,
            vencimiento = dto.vencimiento,
            precio = dto.precio,
            cobertura = dto.cobertura,
            AseguradoEntityId = dto.asegurado,
            CarrosEntityId = dto.placa
        };
        return entity;
    }
}