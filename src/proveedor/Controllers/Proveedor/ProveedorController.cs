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
using RCVUcabBackend.BussinesLogic.Commands.Commands.Atomics;


namespace RCVUcabBackend.Controllers.Proveedor
{
   [ApiController]
    [Route("proveedor")]
    public class ProveedorController : Controller
    {
        private readonly IProveedorDAO _proveedorDAO;
        private readonly ILogger<ProveedorController> _logger;
        
        public ProveedorController(ILogger<ProveedorController> logger, IProveedorDAO proveedorDAO)
        {
            _proveedorDAO = proveedorDAO;
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
     
     [HttpGet("consultar/solicitudesAsignadas/{id_proveedor}")]
     public ApplicationResponse<ProveedorDTO> consultarSolicitudesAsignadas([Required][FromRoute]Guid id_proveedor)
     {
         var ressponse = new ApplicationResponse<ProveedorDTO>();
         try
         {
             GetSolicitudesPorProveedorCommand command =
                 CommandFactory.createGetSolicitudesPorProveedorCommand(id_proveedor);
             command.Execute();
             ressponse.Data = command.GetResult();
         }
         catch (RCVExceptions ex)
         {
             ressponse.Success = false;
             ressponse.Message = ex.Mensaje;
         }
         return ressponse;
     }
     
     [HttpDelete("consultar/deleteProveedor/{id_proveedor}")]
     public ApplicationResponse<ProveedorDTO> deleteProvedor([Required][FromRoute]Guid id_proveedor)
     {
         var ressponse = new ApplicationResponse<ProveedorDTO>();
         try
         {
             GetSolicitudesPorProveedorCommand command =
                 CommandFactory.createGetSolicitudesPorProveedorCommand(id_proveedor);
             command.Execute();
             ressponse.Data = command.GetResult();
         }
         catch (RCVExceptions ex)
         {
             ressponse.Success = false;
             ressponse.Message = ex.Mensaje;
         }
         return ressponse;
     }
        

        [HttpPost("create/proveedor")]
        public ApplicationResponse<ProveedorDTO> CreateProveedor([Required][FromBody]ProveedorDTO proveedorDto)
        {
            var ressponse = new ApplicationResponse<ProveedorDTO>();
            try
            {
                if (proveedorDto.tipoProveedor.tipo == "de_partes")
                {
                    CreateProveedorCommand command =
                        CommandFactory.createCreateProveedorCommand(proveedorDto);
                    command.Execute();
                    ressponse.Message = "se registro exitosamente";
                    ressponse.Data = command.GetResult();
                    if (!ModelState.IsValid)
                    {
                        ressponse.Success = false;
                        return ressponse;
                    }
                }
                else
                {
                    ressponse.Success = false;
                    ressponse.Message = "Solo se admiten proveedores de partes";
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