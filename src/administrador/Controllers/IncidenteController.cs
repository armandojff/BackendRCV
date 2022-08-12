using administrador.BussinesLogic.DTOs;
using administrador.BussinesLogic.Mappers;
using administrador.Commands;
using administrador.Commands.Atomics.IncidentesDAO;
using administrador.Commands.Composes;
using administrador.Exceptions;
using administrador.Persistence.DAOs.Interfaces;
using administrador.Responses;
using Microsoft.AspNetCore.Mvc;

namespace administrador.Controllers.Administrador
{
    [ApiController]
    [Route("Incidentes")]
    public class IncidenteController : Controller
    {
        private readonly IIncidenteDAO _incidenteDAO;
        private readonly ILogger<IncidenteController> _logger;

        public IncidenteController(ILogger<IncidenteController> logger)
        {
            _logger = logger;
        }
        
        [HttpPost("Agregar")]
        public ApplicationResponse<string> createAccident([FromBody] IncidentesDTO incidente)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                var entityAcident = IncidentMapper.mapDtoToEntity(incidente);
                insertAccidentCommand commandAddIncident = CommandFactory.createInsertAccidentCommand(entityAcident);
                commandAddIncident.Execute();
                response.Data = commandAddIncident.GetResult();
            }
            catch (RCVExceptions ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }
        
        [HttpPost("Consultar")]
        public ApplicationResponse<List<IncidentesSimpleDTO>> getAccident([FromBody] Guid id) 
        {
            var response = new ApplicationResponse<List<IncidentesSimpleDTO>>();
            try
            {
                var commandGetIncident = new getAccidentCommand(id);
                commandGetIncident.Execute();
                response.Data = commandGetIncident.GetResult();
            }
            catch (RCVExceptions ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }
        
        /*Me elimina un incidente por su ID*/
        [HttpPost("Borrar")]
        public ApplicationResponse<string> deleteAccident([FromBody] Guid id) 
        {
            var response = new ApplicationResponse<string>();
            try
            {
                var commandDeleteIncident = new deleteAccidentCommand(id);
                commandDeleteIncident.Execute();
                response.Data = commandDeleteIncident.GetResult();
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