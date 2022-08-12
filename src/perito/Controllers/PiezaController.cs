using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
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
    [Route("pieza")]
    public class PiezaController : Controller
    {
            private readonly IPiezaDAO _piezaDAO;
            private readonly ILogger<PiezaController> _logger;

            public PiezaController(ILogger<PiezaController> logger, IPiezaDAO piezaDAO)
            {
                _piezaDAO = piezaDAO;
                _logger = logger;

            }

            

            [HttpPost("create/pieza")]

            public string createPieza([Required] [FromBody] PiezaDTO piezaDTO)
            {
                try
                {
                    var piezaEntidad=PiezaMapper.MapDtoToEntity(piezaDTO);
                    InsertPiezaCommand command=CommandFactory.createCreatePiezaCommand(piezaEntidad);
                    command.Execute();
                    Console.WriteLine(command.GetResult());
                    return "exito";   
                }
                catch (RCVExceptions ex)
                {
                    return ex.Message;
                }
            }

            [HttpPut("actualizar/pieza/{id_pieza}")]
            public ApplicationResponse<PiezaDTO> editarPieza([Required] [FromBody] PiezaDTO piezaCambios,
                [Required] [FromRoute] Guid id_pieza)
            {
                var ressponse = new ApplicationResponse<PiezaDTO>();
                try
                {
                   // ressponse.DataInsert = _piezaDAO.ActualizarPieza(piezaCambios, id_pieza);
                    ressponse.Message = "se edito exitosamente el pieza de id=" + id_pieza;
                    ressponse.Data = null;
                }
                catch (RCVExceptions ex)
                {
                    ressponse.Success = false;
                    ressponse.Message = ex.Mensaje;
                }

                return ressponse;
            }

            [HttpDelete("eliminar/pieza/{id_pieza}")]
            public ApplicationResponse<PiezaDTO> eliminarPieza([Required] [FromRoute] Guid id_pieza)
            {
                var ressponse = new ApplicationResponse<PiezaDTO>();
                try
                {
                    //ressponse.DataInsert = _piezaDAO.EliminarPieza(id_pieza);
                    ressponse.Message = "se elimino exitosamente el pieza de id=" + id_pieza;
                    ressponse.Data = null;
                }
                catch (RCVExceptions ex)
                {
                    ressponse.Success = false;
                    ressponse.Message = ex.Mensaje;
                }

                return ressponse;
            }
            
            [HttpPost("Consultar-pieza")]
            public ApplicationResponse<PiezaDTO> getPieza([FromBody] Guid id)
            {
                var response = new ApplicationResponse<PiezaDTO>();
                try
                {
                    var commandGetPieza = new getPiezaCommand(id);
                    commandGetPieza.Execute();
                    response.Data = commandGetPieza.GetResult();
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