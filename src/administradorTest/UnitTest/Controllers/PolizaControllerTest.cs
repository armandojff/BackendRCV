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
    public class PolizaControllerTest
    {
        private readonly PolizaController _controller;
        private readonly Mock<IPolizaDAO> _serviceMock;
        private readonly Mock<ILogger<PolizaController>> _loggerMock;
        public PolizaEntity poliza = It.IsAny<PolizaEntity>();
        public PolizaSimpleDTO _poliza = It.IsAny<PolizaSimpleDTO>();
        public Guid idGuid = new Guid();
        public int cedula = It.IsAny<int>();
        
        public PolizaControllerTest()
        {
            _loggerMock = new Mock<ILogger<PolizaController>>();
            _serviceMock = new Mock<IPolizaDAO>();
            _controller = new PolizaController(_loggerMock.Object);
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }
        
        /*--------------------------addPolicy()---------------------------*/
        /*Me registra una poliza simple sin incidentes*/
        [Fact(DisplayName = "Add policy")]
        public Task createPolicy()
        {
            _serviceMock
                .Setup(x => x.createPoliza(poliza))
                .Returns("Poliza creada con éxito");
            var result = _controller.addPolicy(_poliza);
            Assert.IsType<ApplicationResponse<string>>(result);
            return Task.CompletedTask;
        }
        
        /*Me trae la excepcion del método addPolicy*/
        [Fact(DisplayName = "Add policy with excepcion")]
        public Task createPolicyExcepcion()
        {
            _serviceMock
                .Setup(x => x.createPoliza(poliza))
                .Throws(new RCVExceptions("No se puede crear la poliza", new Exception()));
            var ex = _controller.addPolicy(_poliza);
            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }
        
        /*--------------------------deletePolicy()---------------------------*/
        /*Me desactiva una poliza*/
        [Fact(DisplayName = "Delete policy by Guid")]
        public Task deletePolicy()
        {
            _serviceMock
                .Setup(x => x.deletePolicy(idGuid))
                .Returns(new Task<bool>(() => true));
            var result = _controller.deletePolicy(idGuid);
            Assert.IsType<ApplicationResponse<Task<bool>>>(result);
            return Task.CompletedTask;
        }
        
        /*Me trae la excepcion del método deletePolicy*/
        [Fact(DisplayName = "Delete policy by Guid with excepcion")]
        public Task deletePolicyExcepcion()
        {
            _serviceMock
                .Setup(x => x.deletePolicy(idGuid))
                .Throws(new RCVExceptions("No se puede actualizar la poliza", new Exception()));
            var ex = _controller.deletePolicy(idGuid);
            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }
        
        /*--------------------------getPolicy()---------------------------*/
        /*Me consulta una poliza*/
        [Fact(DisplayName = "Get policy by ci")]
        public Task getPolicy()
        {
            _serviceMock
                .Setup(x => x.getPolicyInsured(cedula))
                .Returns(new List<PolizaAseguradoDTO>());
            var result = _controller.getPolicy(cedula);
            Assert.IsType<ApplicationResponse<List<PolizaAseguradoDTO>>>(result);
            return Task.CompletedTask;
        }
        
        /*Me trae la excepcion del método getPolicy*/
        [Fact(DisplayName = "Get policy by ci with excepcion")]
        public Task getPolicyExcepcion()
        {
            _serviceMock
                .Setup(x => x.getPolicyInsured(cedula))
                .Throws(new RCVExceptions("No se ha podido presentar la lista de polizas", new Exception()));
            var ex = _controller.getPolicy(cedula);
            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }
    }
}