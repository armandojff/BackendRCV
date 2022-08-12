using administrador.BussinesLogic.DTOs;
using administrador.Persistence.Entities;

namespace administrador.BussinesLogic.Mappers;

public class AseguradoMapper
{
    public static AseguradoEntity mapDtoToEntity(AseguradoDTO dto)
    {
        var entity = new AseguradoEntity
        {
            ci = dto.ci,
            primer_n = dto.primer_n,
            primer_a = dto.primer_a,
            segundo_n = dto.segundo_n,
            segundo_a = dto.segundo_a,
            sexo = dto.sexo
        };
        return entity;
    }
}