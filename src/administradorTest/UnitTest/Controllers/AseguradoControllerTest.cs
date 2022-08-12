using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using administrador.BussinesLogic.DTOs;
using administrador.Controllers.Administrador;
using administrador.Persistence.DAOs.Interfaces;
using administrador.Exceptions;
using administrador.Persistence.Entities;
using administrador.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
namespace administradorTest.UnitTest.Controllers
{
    public class AseguradoControllerTest
    {
        private readonly AseguradoController _controller;
        private readonly Mock<IAseguradoDAO> _serviceMock;
        private readonly Mock<ILogger<AseguradoController>> _loggerMock;
        public AseguradoEntity asegurado = It.IsAny<AseguradoEntity>();
        public AseguradoDTO aseguradoDTO = It.IsAny<AseguradoDTO>();
        public PAseguradoDTO aseguradoSimple = It.IsAny<PAseguradoDTO>();
        public int cedula = It.IsAny<int>();
    
        public AseguradoControllerTest()
        {
            _loggerMock = new Mock<ILogger<AseguradoController>>();
            _serviceMock = new Mock<IAseguradoDAO>();
            _controller = new AseguradoController(_loggerMock.Object);
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }
        
        /*--------------------------addInsured()---------------------------*/
        /*Me registra una asegurado*/
        [Fact(DisplayName = "Add insured")]
        public Task createInsured()
        {
            _serviceMock
                .Setup(x => x.createInsured(asegurado))
                .Returns("Éxitoso");
            var result = _controller.addInsured(aseguradoDTO);
            Assert.IsType<ApplicationResponse<string>>(result);
            return Task.CompletedTask;
        }
        
        /*Me trae la excepcion del método addInsured*/
        [Fact(DisplayName = "Add insured with excepcion")]
        public Task createInsuredExcepcion()
        {
            _serviceMock
                .Setup(x => x.createInsured(asegurado))
                .Throws(new RCVExceptions("No se puede crear, detalles: ", new Exception()));
            var ex = _controller.addInsured(aseguradoDTO);
            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }
        
        /*--------------------------getInsuredAll()---------------------------*/
        /*Me consulta todos los asegurado*/
        [Fact(DisplayName = "Get insured all")]
        public Task getInsuredAll()
        {
            _serviceMock
                .Setup(x => x.getInsured())
                .Returns(new List<PAseguradoDTO>());
            var result = _controller.getInsuredAll();
            Assert.IsType<List<PAseguradoDTO>>(result);
            return Task.CompletedTask;
        }
        
        /*Me trae la excepcion del método getInsuredAll*/
        [Fact(DisplayName = "Get insured all with excepcion")]
        public Task getInsuredAllExcepcion()
        {
            _serviceMock
                .Setup(x => x.getInsured())
                .Throws(new RCVExceptions("No hay asegurados", new Exception()));
            var ex = _controller.getInsuredAll();
            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }
        
        /*--------------------------getInsuredSpecific()---------------------------*/
        /*Me consulta un asegurado*/
        [Fact(DisplayName = "Get insured specific")]
        public Task getInsuredSpecific()
        {
            _serviceMock
                .Setup(x => x.getInsured(cedula))
                .Returns(aseguradoSimple);
            var result = _controller.getInsuredSpecific(cedula);
            Assert.IsType<ApplicationResponse<PAseguradoDTO>>(result);
            return Task.CompletedTask;
        }
        
        /*Me trae la excepcion del método getInsuredSpecific*/
        [Fact(DisplayName = "Get insured specific with excepcion")]
        public Task getInsuredSpecificExcepcion()
        {
            _serviceMock
                .Setup(x => x.getInsured(cedula))
                .Throws(new RCVExceptions("No se ha podido presentar la lista de asegurados", new Exception()));
            var ex = _controller.getInsuredSpecific(cedula);
            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }
    }
}