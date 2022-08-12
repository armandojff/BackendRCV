using Microsoft.AspNetCore.Mvc;
using administrador.BussinesLogic.DTOs;
using administrador.BussinesLogic.Mappers;
using administrador.Commands;
using administrador.Commands.Atomics;
using administrador.Exceptions;
using administrador.Persistence.DAOs.Interfaces;
using administrador.Responses;
namespace administrador.Controllers.Administrador
{
    [ApiController]
    [Route("Asegurado")]
    public class AseguradoController : Controller
    {
        private readonly IAseguradoDAO _aseguradoDAO;
        private readonly ILogger<AseguradoController> _logger;

        public AseguradoController(ILogger<AseguradoController> logger)
        {
            _logger = logger;
        }
        
        [HttpPost("Agregar")]
        public ApplicationResponse<string> addInsured([FromBody] AseguradoDTO insured)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                var entityAsegurado = AseguradoMapper.mapDtoToEntity(insured);
                createInsuredCommand commandAddIncident = CommandFactory.createCreateInsuredCommand(entityAsegurado);
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
        
        [HttpGet("Consultar-Todos")]
        public ApplicationResponse<List<PAseguradoDTO>> getInsuredAll()
        {
            var response = new ApplicationResponse<List<PAseguradoDTO>>();
            try
            {
                getInsuredAllCommand commandGetAllInsured = CommandFactory.createGetInsuredAllCommand();
                commandGetAllInsured.Execute();
                response.Data = commandGetAllInsured.GetResult();
            }
            catch (RCVExceptions ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }
        
        /*Consulta un asegurado por su CI*/
        [HttpPost("Consultar-Asegurado")]
        public ApplicationResponse<PAseguradoDTO> getInsuredSpecific([FromBody] int ci)
        {
            var response = new ApplicationResponse<PAseguradoDTO>();
            try
            {
                getInsuredCommand commandGetInsured = CommandFactory.createGetInsuredCommand(ci);
                commandGetInsured.Execute();
                response.Data = commandGetInsured.GetResult();
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