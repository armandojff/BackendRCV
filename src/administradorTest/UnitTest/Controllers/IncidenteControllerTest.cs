using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using administrador.BussinesLogic.DTOs;
using administrador.Controllers.Administrador;
using administrador.Exceptions;
using administrador.Persistence.DAOs.Interfaces;
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
    public class IncidenteControllerTest
    {
        private readonly IncidenteController _controller;
        private readonly Mock<IIncidenteDAO> _serviceMock;
        private readonly Mock<ILogger<IncidenteController>> _loggerMock;
        
        public IncidenteControllerTest()
        {
            _loggerMock = new Mock<ILogger<IncidenteController>>();
            _serviceMock = new Mock<IIncidenteDAO>();
            _controller = new IncidenteController(_loggerMock.Object);
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }
        
        /*--------------------------createAccident()---------------------------*/
        /*Me registra un incidente*/
        [Fact(DisplayName = "Add incident")]
        public Task createIncidente()
        {
            _serviceMock
                .Setup(x => x.createAccident(It.IsAny<IncidentesEntity>()))
                .Returns("Incidente registrado con éxito");
            var result = _controller.createAccident(It.IsAny<IncidentesDTO>());
            Assert.IsType<ApplicationResponse<string>>(result);
            return Task.CompletedTask;
        }
        
        /*Me trae la excepcion del método createAccident*/
        [Fact(DisplayName = "Add incident with excepcion")]
        public Task createCarExcepcion()
        {
            _serviceMock
                .Setup(x => x.createAccident(It.IsAny<IncidentesEntity>()))
                .Throws(new RCVExceptions("", new Exception()));
            var ex = _controller.createAccident(It.IsAny<IncidentesDTO>());
            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }
        
        /*--------------------------getAccident()---------------------------*/
        /*Me trae la lista de incidentes de una poliza*/
        [Fact(DisplayName = "Get incidents by guid policy")]
        public Task getIncidentByGuidPolicy()
        {
            _serviceMock
                .Setup(x => x.getAccident(It.IsAny<Guid>()))
                .Returns(new List<IncidentesSimpleDTO>());
            var result = _controller.getAccident(It.IsAny<Guid>());
            Assert.IsType<ApplicationResponse<List<IncidentesSimpleDTO>>>(result);
            return Task.CompletedTask;
        }
        
        /*Me trae la excepción del método getAccident*/
        [Fact(DisplayName = "Get incidents by guid policy with Exception")]
        public Task getIncidentByGuidPolicyExcepcion()
        {
            _serviceMock
                .Setup(x => x.getAccident(It.IsAny<Guid>()))
                .Throws(new RCVExceptions("", new Exception()));
            var ex = _controller.getAccident(It.IsAny<Guid>());
            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }
        
        /*--------------------------deleteAccident()---------------------------*/
        /*Me borra el incidente de una poliza*/
        [Fact(DisplayName = "Delete incidents by guid incident")]
        public Task deleteIncident()
        {
            _serviceMock
                .Setup(x => x.deleteAccident(It.IsAny<Guid>()))
                .Returns("");
            var result = _controller.deleteAccident(It.IsAny<Guid>());
            Assert.IsType<ApplicationResponse<string>>(result);
            return Task.CompletedTask;
        }
        
        /*Me trae la excepción del método deleteAccident*/
        [Fact(DisplayName = "Delete incidents by guid incident with Exception")]
        public Task deleteIncidentExcepcion()
        {
            _serviceMock
                .Setup(x => x.deleteAccident(It.IsAny<Guid>()))
                .Throws(new RCVExceptions("", new Exception()));
            var ex = _controller.deleteAccident(It.IsAny<Guid>());
            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }
        
    }
}