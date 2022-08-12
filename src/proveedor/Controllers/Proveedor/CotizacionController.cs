using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using backendRCVUcab.Exceptions;
using backendRCVUcab.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.Persistence.DAOs.Interfaces;
using System.Text;
using RCVUcabBackend.BussinesLogic.Commands;
using RCVUcabBackend.BussinesLogic.Commands.Commands.Composes;

namespace RCVUcabBackend.Controllers.Proveedor
{

        [ApiController]
        [Route("cotizacion")]
        public class CotizacionController : Controller
        {
            private readonly ICotizacionDAO _cotizacionDAO;
            private readonly ILogger<CotizacionController> _logger;
        
            public CotizacionController(ILogger<CotizacionController> logger, ICotizacionDAO cotizacionDAO)
            {
                _cotizacionDAO = cotizacionDAO;
                _logger = logger;
            }
            
            [HttpPost("create/Cotizacion")]
            public ApplicationResponse<CotizacionDTO> CreateProveedor([Required][FromBody]CotizacionDTO cotizacionDto)
            {
                var ressponse = new ApplicationResponse<CotizacionDTO>();
                try
                {
                    CreateCotizacionCommand command = CommandFactory.createCreateCotizacionCommand(cotizacionDto);
                    command.Execute();
                    ressponse.Data = cotizacionDto;

                } catch (RCVExceptions ex)
                {
                    ressponse.Success = false;
                    ressponse.Message = ex.Mensaje;
                }
                return ressponse;
               
            }
            

        
    }
}