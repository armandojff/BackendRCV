using administrador.BussinesLogic.DTOs;
using administrador.Commands.Atomics;
using administrador.Exceptions;
using administrador.Persistence.DAOs.Interfaces;
using administrador.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace administrador.Controllers.Administrador
{
    [ApiController]
    [Route("Carros")]
    public class CarroController: Controller
    {
        private readonly ICarroDAO _carroDAO;
        private readonly ILogger<CarroController> _logger;

        public CarroController(ILogger<CarroController> logger, ICarroDAO carroDAO)
        {
            _carroDAO = carroDAO;
            _logger = logger;
        }
        
        [HttpPost("Agregar")]
        public ApplicationResponse<string> addCar([FromBody] CarroDTO car) //add car
        {
            var response = new ApplicationResponse<string>();
            try
            {
                var commandAddCar = new createCarCommand(car);
                commandAddCar.Execute();
                response.Data = commandAddCar.GetResult();
            }
            catch (RCVExceptions ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }
        
        /*Me trae el carro por su placa*/
        [HttpPost("Consultar")]
        public ApplicationResponse<CarroDTO> getCar([FromBody] string placa)
        {
            var response = new ApplicationResponse<CarroDTO>();
            try
            {
                var commandGetCar = new getCarCommand(placa);
                commandGetCar.Execute();
                response.Data = commandGetCar.GetResult();
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