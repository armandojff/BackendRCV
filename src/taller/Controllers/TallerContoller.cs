using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.BussinesLogic.Mappers;
using RCVUcabBackend.BussinesLogic.TallerCommands;
using RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Atomic;
using RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Composes;
using RCVUcabBackend.BussinesLogic;
using RCVUcabBackend.Exceptions;



namespace RCVUcabBackend.Controllers{
    
    [ApiController]
    [Route("Taller")]
    public class TallerContoller:Controller
    {
        private readonly ILogger<TallerContoller> _logger;
        public TallerContoller(ILogger<TallerContoller> logger){
            this._logger=logger;
        }

        [HttpPost("create/taller")]
        public string crearTaller([Required][FromBody] TallerDTO tallerSolicitud){
            try
            {
                var tallerEntidad=TallerMapper.MapDtoToEntity(tallerSolicitud);
                CrearTallerCommand command=CommandFactory.crearCrearTallerCommand(tallerEntidad);
                command.Execute();
                Console.WriteLine(command.GetResult());
                return "exito";   
            }
            catch (ExcepcionTaller ex)
            {
                return ex.Message;
            }
        }

        [HttpDelete("eliminar/taller/{id_taller}")]
        public string eliminarTaller([Required][FromRoute]Guid id_taller){
            try
            {
                EliminarTallerCommand command=CommandFactory.crearEliminarTallerCommand(id_taller);
                command.Execute();
                return command.GetResult();   
            }
            catch (ExcepcionTaller ex)
            {
                return ex.Message;
            }
        }

        [HttpPut("actualizar/taller/{id_taller}")]
        public TallerDTO actualizarTaller([Required][FromBody] TallerDTO tallerSolicitud,[Required][FromRoute]Guid id_taller){
            try
            {
                var tallerEntidad=TallerMapper.MapDtoToEntity(tallerSolicitud);
                UpdateTallerCommand command=CommandFactory.crearUpdateTallerCommand(tallerEntidad,id_taller);
                command.Execute();
                return command.GetResult();   
            }
            catch (ExcepcionTaller ex)
            {
                return null;
            }
        }

    }
}