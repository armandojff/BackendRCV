using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.BussinesLogic.Mappers;
using RCVUcabBackend.Persistence.Entities.ChecksEntitys;


namespace RCVUcabBackend.BussinesLogic.Mappers{
    public class UsuarioTallerMapper
    {
        public static UsuarioTallerEntity MapDtoToEntity(crearUsuarioTallerDTO dto){
            var usuarioTaller=new UsuarioTallerEntity{
                primer_nombre=dto.primer_nombre,
                primer_apellido=dto.primer_apellido,
                segundo_nombre=dto.segundo_nombre,
                segundo_apellido=dto.segundo_apellido,
                direccion=dto.direccion,
                cargo=dto.cargo,
                estado=CheckEstadoUsuarioTaller.Activo,
                email=dto.email,
                contraseña=dto.contraseña,
                taller=null,
                Telefonos=TelefonoMapper.MapListDtoToListEntity(dto.telefonos),
                cotizaciones_taller=null,
                CreatedAt=null
            };
            return usuarioTaller;
        }

        public static UsuarioTallerEntity MapDtoActualizarUsuarioTallerToEntity(ActualizarUsuarioTallerDTO dto){
            var usuarioTaller=new UsuarioTallerEntity{
                primer_nombre=dto.primer_nombre,
                primer_apellido=dto.primer_apellido,
                segundo_nombre=dto.segundo_nombre,
                segundo_apellido=dto.segundo_apellido,
                direccion=dto.direccion,
                cargo=dto.cargo,
                estado=CheckEstadoUsuarioTaller.Activo,
                email=dto.email,
                contraseña=dto.contraseña,
                taller=null,
                Telefonos=TelefonoMapper.MapListDtoToListEntity(dto.Telefonos),
                cotizaciones_taller=null,
                CreatedAt=Convert.ToDateTime(DateTime.Now.ToString())
            };
            return usuarioTaller;
        }

        /*public static TallerDTO MapEntityToDto(TallererEntity entity){
            var taller=new TallerDTO{
                nombre_taller=entity.nombre_taller,
                direccion=entity.direccion,
                RIF=entity.RIF,
                estado=entity.estado,
                Marcac_Carros=MarcaMapper.MapListEntityToListDto(entity.marcas)
            };
            return taller;
        }*/

    }
}