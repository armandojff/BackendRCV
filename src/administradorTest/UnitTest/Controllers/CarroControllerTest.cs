using System;
using System.Threading.Tasks;
using administrador.BussinesLogic.DTOs;
using administrador.Controllers.Administrador;
using administrador.Persistence.DAOs.Interfaces;
using administrador.Exceptions;
using administrador.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace administradorTest.UnitTest.Controllers
{
    public class CarroControllerTest
    {
        private readonly CarroController _controller;
        private readonly Mock<ICarroDAO> _serviceMock;
        private readonly Mock<ILogger<CarroController>> _loggerMock;
        
        public CarroControllerTest()
        {
            _loggerMock = new Mock<ILogger<CarroController>>();
            _serviceMock = new Mock<ICarroDAO>();
            _controller = new CarroController(_loggerMock.Object, _serviceMock.Object);
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }
        
        /*--------------------------addCar()---------------------------*/
        /*Me registra el carro*/
        [Fact(DisplayName = "Add car")]
        public Task createCar()
        {
            _serviceMock
                .Setup(x => x.createCar(It.IsAny<CarroDTO>()))
                .Returns("Carro registrado con éxito");
            var result = _controller.addCar(It.IsAny<CarroDTO>());
            Assert.IsType<ApplicationResponse<string>>(result);
            return Task.CompletedTask;
        }
        
        /*Me trae la excepcion del método addCar*/
        [Fact(DisplayName = "Add car with excepcion")]
        public Task createCarExcepcion()
        {
            _serviceMock
                .Setup(x => x.createCar(It.IsAny<CarroDTO>()))
                .Throws(new RCVExceptions("", new Exception()));
            var ex = _controller.addCar(It.IsAny<CarroDTO>());
            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }
        
        /*--------------------------getCar()---------------------------*/
        /*Me trae su carro por placa*/
        [Fact(DisplayName = "Get car by plate")]
        public Task getCarByPlate()
        {
            _serviceMock
                .Setup(x => x.getCar(It.IsAny<string>()))
                .Returns(new CarroDTO());
            var result = _controller.getCar("");
            Assert.IsType<ApplicationResponse<CarroDTO>>(result);
            return Task.CompletedTask;
        }
        
        /*Me trae la excepción del método getCar*/
        [Fact(DisplayName = "Get car by plate with Exception")]
        public Task getCarByPlateException()
        {
            _serviceMock
                .Setup(x => x.getCar(It.IsAny<string>()))
                .Throws(new RCVExceptions("", new Exception()));
            var ex = _controller.getCar("");
            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }
    }
    
}