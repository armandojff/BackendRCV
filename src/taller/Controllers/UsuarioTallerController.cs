using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.BussinesLogic.Mappers;
using RCVUcabBackend.BussinesLogic.TallerCommands;
using RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Atomic;
using RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Composes;
using RCVUcabBackend.BussinesLogic;
using RCVUcabBackend.Exceptions;



namespace RCVUcabBackend.Controllers{
    
    [ApiController]
    [Route("UsuarioTaller")]
    public class UsuarioTallerContoller:Controller
    {
        private readonly ILogger<UsuarioTallerContoller> _logger;
        public UsuarioTallerContoller(ILogger<UsuarioTallerContoller> logger){
            this._logger=logger;
        }

        [HttpPost("create/usuarioTaller/{id_taller}")]
        public string crearUsuarioTaller([Required][FromBody] crearUsuarioTallerDTO usuarioTallerDTO,[Required][FromRoute] Guid id_taller){
            try
            {
                var usuarioTallerEntidad=UsuarioTallerMapper.MapDtoToEntity(usuarioTallerDTO);
                CrearUsuarioTallerCommand command=CommandFactory.crearCrearUsuarioTallerCommand(usuarioTallerEntidad,id_taller);
                command.Execute();
                Console.WriteLine(command.GetResult());
                return "exito";   
            }
            catch (ExcepcionTaller ex)
            {
                return ex.Mensaje;
            }
        }

        [HttpPost("eliminar/usuarioTaller/{id_usuario_taller}")]
        public string eliminarUsuarioTaller([Required][FromRoute] Guid id_usuario_taller){
            try
            {
                DeleateUsuarioTallerCommand command=CommandFactory.crearDeleateUsuarioTallerCommand(id_usuario_taller);
                command.Execute();
                Console.WriteLine(command.GetResult());
                return "exito";   
            }
            catch (ExcepcionTaller ex)
            {
                return ex.Mensaje;
            }
        }

        [HttpPost("actualizar/usuarioTaller/{id_usuario_taller}")]
        public string actualizarUsuarioTaller([Required][FromBody]ActualizarUsuarioTallerDTO cambiosUsuarioTaller, [Required][FromRoute] Guid id_usuario_taller){
            try
            {
                UpdateUsuarioTallerCommand command=CommandFactory.crearUpdateUsuarioTallerCommand(UsuarioTallerMapper.MapDtoActualizarUsuarioTallerToEntity(cambiosUsuarioTaller),id_usuario_taller);
                command.Execute();
                Console.WriteLine(command.GetResult());
                return "exito";   
            }
            catch (ExcepcionTaller ex)
            {
                return ex.Mensaje;
            }
        }



    }
}