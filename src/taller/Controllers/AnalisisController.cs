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
    [Route("Analisis")]

    public class AnalisisController:Controller
    {
        private readonly ILogger<AnalisisController> _logger;
        public AnalisisController(ILogger<AnalisisController> logger){
            this._logger=logger;
        }

        [HttpGet("consultar/analisis/conOrdenDePago/{id_taller}")]
        public ICollection<AnalisisConsultaDTO> ConsultarRequerimientosConOrdenPago(Guid id_taller){
            try
            {
                ConsultarRequerimientosAsignadosPorFiltroCommand command=CommandFactory.crearConsultarRequerimientosAsignadosPorFiltroCommand(id_taller,CheckEstadoAnalisisAccidente.Con_Orden);
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