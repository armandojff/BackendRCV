using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.BussinesLogic.Mappers;
using RCVUcabBackend.BussinesLogic.TallerCommands;
using RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Atomic;
using RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Composes;
using RCVUcabBackend.Persistence.Entities.ChecksEntitys;
using RCVUcabBackend.BussinesLogic;
using RCVUcabBackend.Exceptions;

namespace RCVUcabBackend.Controllers{
    [ApiController]
    [Route("Cotizacion")]

    public class CotizacionController:Controller
    {
        private readonly ILogger<CotizacionController> _logger;
        public CotizacionController(ILogger<CotizacionController> logger){
            this._logger=logger;
        }

        [HttpPost("create/cotizacion")]
        public string crearCotizacion([Required][FromBody] CrearCotizacionDTO cotizacionSolicitud){
            try
            {
                var cotizacioEntidad=CotizacionMapper.MapDtoToEntity(cotizacionSolicitud);
                crearCotizacionDeAnalisisCommand command=CommandFactory.crearCrearCotizacionDeAnalisisCommandd(cotizacioEntidad,cotizacionSolicitud.usuario_taller,cotizacionSolicitud.fecha_inicio,cotizacionSolicitud.fecha_culminacion);
                command.Execute();
                Console.WriteLine(command.GetResult());
                return "exito";   
            }
            catch (ExcepcionTaller ex)
            {
                return ex.Message;
            }
        }


    }
}