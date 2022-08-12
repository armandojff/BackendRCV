using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using perito.BussinesLogic.DTOs;
using perito.BussinesLogic.Mappers;
using perito.Commands;
using perito.Commands.Atomics.Perito;
using perito.Commands.Composes;
using perito.Exceptions;
using perito.Persistence.DAOs.Interfaces;
using perito.Responses;

namespace perito.Controllers.Perito
{
    [ApiController]
    [Route("analisis")]
public class AnalisisController : Controller
{
        private readonly ILogger<AnalisisController> _logger;

        public AnalisisController(ILogger<AnalisisController> logger)
        {
            this._logger = logger;
        }

     
        
        [HttpDelete("eliminar/analisis/{id_analisis}")]
        public string  eliminarAnalisis([Required][FromRoute]Guid id_analisis)
        {
            try
            {
                DeleteAnalisisCommand command=CommandFactory.CreateDeleteAnalisisCommand(id_analisis);
                command.Execute();
                return command.GetResult();   
            }
            catch (RCVExceptions ex)
            {
                return ex.Message;
            }
        }
        
       
        
        

        
        [HttpPut("actualizar/analisis/{id_analisis}")]
        public AnalisisDTO editarAnalisis([Required][FromBody]AnalisisDTO analisisCambios,[Required][FromRoute]Guid id_analisis)
        {
            try
            {
                var analisisEntidad = AnalisisMapper.MapDtoToEntity(analisisCambios);
                ActualizarAnalisisCommand command =
                    CommandFactory.createActualizarAnalisisCommand(analisisEntidad, id_analisis);
                command.Execute();
                return command.GetResult();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
        
       
        
        [HttpPost("create/analisis")]

        public string createAnalisis([Required][FromBody] AnalisisDTO analisisDTO)
        {
            try
            {
                var analisisEntidad = AnalisisMapper.MapDtoToEntity(analisisDTO);
               
               CreateAnalisisCommand command = CommandFactory.CreateCreateAnalisisCommand(analisisEntidad);
               command.Execute(); 
               Console.WriteLine(command.GetResult());
               return "exito";
            }
            catch (RCVExceptions ex)
            {
                return  ex.Message;
            }

        }
        
        [HttpPost("Consultar-analisis")]
        public ApplicationResponse<AnalisisDTO> getAnalisis([FromBody] Guid id)
        {
            var response = new ApplicationResponse<AnalisisDTO>();
            try
            {
                var commandGetAnalisis = new getAnalisisCommand(id);
                commandGetAnalisis.Execute();
                response.Data = commandGetAnalisis.GetResult();
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