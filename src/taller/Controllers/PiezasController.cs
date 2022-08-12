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
    [Route("Pieza")]

    public class PiezasController:Controller
    {
        private readonly ILogger<PiezasController> _logger;
        public PiezasController(ILogger<PiezasController> logger){
            this._logger=logger;
        }

        [HttpGet("consultar/piezas/reparar/{id_analisis}")]
        public ICollection<PiezasConsultDTO> actualizarTaller([Required][FromRoute]Guid id_analisis){
            try
            {
                ObtenerPiezasARepararDelAnalisisCommand command=CommandFactory.crearObtenerPiezasARepararDelAnalisisCommand(id_analisis);
                command.Execute();
                return command.GetResult();   
            }
            catch (ExcepcionTaller ex)
            {
                return null;
            }
        }

        [HttpPut("editar/estado/reparar/{id_pieza}")]
        public PiezasConsultDTO repararPieza([Required][FromRoute]Guid id_pieza){
            try
            {
                ActualizarEstadoDeLaPiezaCommand command=CommandFactory.crearActualizarEstadoDeLaPiezaCommand(id_pieza,CheckEstadoPieza.reparar);
                command.Execute();
                return command.GetResult();   
            }
            catch (ExcepcionTaller ex)
            {
                return null;
            }
        }

        [HttpPut("editar/estado/comprar/{id_pieza}")]
        public PiezasConsultDTO comprarPieza([Required][FromRoute]Guid id_pieza){
            try
            {
                ActualizarEstadoDeLaPiezaCommand command=CommandFactory.crearActualizarEstadoDeLaPiezaCommand(id_pieza,CheckEstadoPieza.comprar);
                command.Execute();
                return command.GetResult();   
            }
            catch (ExcepcionTaller ex)
            {
                return null;
            }
        }

        [HttpPut("editar/descripcion/{id_pieza}")]
        public PiezasConsultDTO editarDescripcionPieza([Required][FromBody] PiezaEditDescripcionDTO nuevaDescripcion,[Required][FromRoute]Guid id_pieza){
            try
            {
                ActualizarDescripcionDeLaPiezaCommand command=CommandFactory.crearActualizarDescripcionDeLaPiezaCommand(id_pieza,nuevaDescripcion.descripcion_pieza);
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