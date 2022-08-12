using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using perito.BussinesLogic.DTOs;
using perito.BussinesLogic.Mappers;
using perito.Commands;
using perito.Commands.Atomics.Perito;
using perito.Exceptions;
using perito.Persistence.DAOs.Interfaces;
using perito.Responses;

namespace perito.Controllers.Perito
{
    [ApiController]
    [Route("perito")]
    public class PeritoController : Controller
    {
        private readonly IPeritoDAO _peritoDAO;
        private readonly ILogger<PeritoController> _logger;

        public PeritoController(ILogger<PeritoController> logger, IPeritoDAO peritoDAO, IDireccionDAO direccionDao, IPiezaDAO piezaDAO, IAnalisisDAO analisisDAO)
        {
            _peritoDAO = peritoDAO;
            _logger = logger;

        }

        [HttpPost("create/perito")]
        public string createPerito([Required][FromBody] PeritoDTO peritoDTO){
        try
        {
            var peritoEntidad=PeritoMapper.MapDtoToEntity(peritoDTO);
            InsertPeritoCommand command=CommandFactory.createCreatePeritoCommand(peritoEntidad);
            command.Execute();
            Console.WriteLine(command.GetResult());
            return "exito";   
        }
        catch (RCVExceptions ex)
        {
            return ex.Message;
        }
        }
        

        [HttpPut("actualizar/perito/{id_perito}")]
        public PeritoDTO editarPerito([Required][FromBody]PeritoDTO peritoCambios,[Required][FromRoute]Guid id_perito)
        {
            try
            {
                var peritoEntidad = PeritoMapper.MapDtoToEntity(peritoCambios);
                ActualizarPeritoCommand command = CommandFactory.CreateActualizarPeritoCommand(peritoEntidad, id_perito);
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
        
        
        
        [HttpDelete("eliminar/perito/{id_perito}")]
        public string eliminarPerito([Required][FromRoute]Guid id_perito)
        {
            try
            {
                DeletePeritoCommand command=CommandFactory.CreateDeletePeritoCommand(id_perito);
                command.Execute();
                return command.GetResult();   
            }
            catch (RCVExceptions ex)
            {
                return ex.Message;
            }
        }
        
        
        
        [HttpPost("Consultar-perito")]
        public ApplicationResponse<PeritoDTO> getPerito([FromBody] Guid id)
        {
            var response = new ApplicationResponse<PeritoDTO>();
            try
            {
                var commandGetPerito = new getPeritoCommand(id);
                commandGetPerito.Execute();
                response.Data = commandGetPerito.GetResult();
            }
            catch (RCVExceptions ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }
    }
        
    
}