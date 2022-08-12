using System;
using System.ComponentModel.DataAnnotations;
using backendRCVUcab.Exceptions;
using backendRCVUcab.Persistence.Entities;
using backendRCVUcab.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RCVUcabBackend.BussinesLogic.Commands;
using RCVUcabBackend.BussinesLogic.Commands.Commands.Atomics;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.Persistence.DAOs.Interfaces;

namespace RCVUcabBackend.Controllers.Proveedor
{
  
        [ApiController]
        [Route("solicitud")]
        public class SolicitudController : Controller
        {
            private readonly ISolicitudDAO _solicitudDAO;
            private readonly ILogger<SolicitudController> _logger;

            public SolicitudController(ILogger<SolicitudController> logger, ISolicitudDAO solicitudDAO)
            {
                _solicitudDAO = solicitudDAO;
                _logger = logger;
            }

            /*   [HttpGet("rabbit")]
               public ApplicationResponse<TallerDTO> rabbitMQ()
               {
                   var ressponse = new ApplicationResponse<TallerDTO>();
                   try
                   {
                       var factory = new ConnectionFactory() { HostName = "localhost" };
                       using (var connection = factory.CreateConnection())
                       using (var channel = connection.CreateModel())
                       {
                           channel.QueueDeclare(queue: "hello",
                               durable: false,
                               exclusive: false,
                               autoDelete: false,
                               arguments: null);
                           var consumer = new EventingBasicConsumer(channel);
                           consumer.Received += (model, ea) =>
                           {
                               var body = ea.Body.ToArray();
                               var message = Encoding.UTF8.GetString(body);
                               ressponse.Message = "a" + message;
                                              Console.WriteLine(" [x] Received {0}", message);
                           };
                           channel.BasicConsume(queue: "hello",
                               autoAck: true,
                               consumer: consumer);
                       }
       
                       return ressponse;
                   }
                   catch (Exception ex)
                   {
                       ressponse.Success = false;
                       ressponse.Message = ex.Message;
                       //ressponse.Exception = ex.Excepcion.ToString();
                   }
       
                   return ressponse;
               }
               */
       

            [HttpPut("declinarParticipacion/{id_solicitud}/{id_proveedor}")]
            public ApplicationResponse<SolicitudDTO> declinarParticipacion([Required][FromRoute] Guid id_solicitud,[Required][FromRoute]Guid id_proveedor)
            {
                var ressponse = new ApplicationResponse<SolicitudDTO>();
                try
                {
                    DeclineParticipacionCommand command =
                        CommandFactory.createDeclineParticipacionCommand(id_solicitud, id_proveedor);
                    command.Execute();
                    ressponse.Message = "se declinó exitosamente la participacion ";
                    ressponse.Data = command.GetResult();
                }
                catch (RCVExceptions ex)
                {
                    ressponse.Success = false;
                    ressponse.Message = ex.Mensaje;
                }
                return ressponse;
            }

            [HttpPost("create/solicitud")]
            public ApplicationResponse<SolicitudDTO> CreateSolicitud([Required] [FromBody] SolicitudDTO solicitudDto)
            {
                var ressponse = new ApplicationResponse<SolicitudDTO>();
                try
                {
                    CreateSolicitudCommand command =
                        CommandFactory.createCreateSolicitudCommand(solicitudDto);
                    command.Execute();
                    ressponse.Message = "se registro exitosamente";
                    ressponse.Data = command.GetResult();
                    if (!ModelState.IsValid)
                    {
                        ressponse.Success = false;
                        return ressponse;
                    }
                }
                catch (Exception ex)
                {
                    ressponse.Success = false;
                    ressponse.Message = ex.Message;
                    //ressponse.Exception = ex.Excepcion.ToString();
                }

                return ressponse;
            }
            
            
            
            [HttpPost("create/ordenDeCompra")]
            public ApplicationResponse<SolicitudDTO> CreateOrdenDeCompra([Required] [FromBody] SolicitudDTO solicitudDto)
            {
                var ressponse = new ApplicationResponse<SolicitudDTO>();
                try
                {
                    CreateSolicitudCommand command =
                        CommandFactory.createCreateSolicitudCommand(solicitudDto);
                    command.Execute();
                    ressponse.Message = "se registro exitosamente";
                    ressponse.Data = command.GetResult();
                    if (!ModelState.IsValid)
                    {
                        ressponse.Success = false;
                        return ressponse;
                    }
                }
                catch (Exception ex)
                {
                    ressponse.Success = false;
                    ressponse.Message = ex.Message;
                    //ressponse.Exception = ex.Excepcion.ToString();
                }

                return ressponse;
            }

        }

    }

