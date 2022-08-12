using System;
using System.Collections.Generic;
using Bogus;
using Microsoft.Extensions.Logging;
using Moq;
using administrador.Persistence.Database;
using administrador.Exceptions;
using administradorTest.DataSeed;
using System.Linq;
using System.Threading.Tasks;
using administrador.BussinesLogic.DTOs;
using administrador.BussinesLogic.Mappers;
using administrador.Persistence.Entities;
using Xunit;
using PolizaDAO = administrador.Persistence.DAOs.Implementations.PolizaDAO;
namespace administradorTest.UnitTest.DAOs
{
    public class PolizaDAOTest
    {
        private readonly PolizaDAO _dao;
        private readonly Mock<IRCVDbContext> _contextMock;
        private readonly Mock<ILogger<PolizaDAO>> _mockLogger;

        public PolizaDAOTest()
        {
            var faker = new Faker();
            _contextMock = new Mock<IRCVDbContext>();
            _mockLogger = new Mock<ILogger<PolizaDAO>>();
            _dao = new PolizaDAO(_contextMock.Object);
            _contextMock.SetupDbContextDataPoliza();
        }
        
        /*---------------------------createPoliza()---------------------------*/
        /*Valido que me ingresa una poliza con éxito*/
        [Theory (DisplayName = "Valida que sí me inserta una poliza nueva")]
        [InlineData("Completa")] 
        public Task CreatePolicyTrue(String tipo)
        {
            PolizaSimpleDTO policy = new PolizaSimpleDTO()
            {
                tipo = "Completa",
                vencimiento = DateTime.Parse("20/01/2020"),
                asegurado = 25872770
            };
            var result = _dao.createPoliza(PolizaMapper.mapDtoToEntity(policy));
            Assert.Equal("Poliza creada con éxito",result);
            _contextMock.Verify(m => m.DbContext.SaveChanges(), Times.Exactly(1));
            return Task.CompletedTask;
        }
        
        /*valida que no me inserte una poliza nueva*/
        [Fact(DisplayName = "Valida que NO me inserte una poliza nueva")] //acá debería traer una excepcion
        public Task CreatePolicyFalse()
        {
            var result = Assert.Throws<RCVExceptions>(()=>this._dao.createPoliza(null)); 
            Assert.Equal(result.Mensaje, "No se puede crear la poliza");
            return Task.CompletedTask;
        }
        
       /*desactiva la poliza*/ 
        [Theory (DisplayName = "Desactivar poliza")]
        [InlineData("3fbfe10c-2dac-4a47-9de3-a725a6de92c6")]
        public Task desactivarPolizaTrue(Guid guid)
        {
            var result = _dao.deletePolicy(guid);
            Assert.True(result.Result);
            return Task.CompletedTask;
        }
        
        /*----------------------------------getPolicyInsured()----------------------------------*/
        /*Valida que me trae todas las polizas de un asegurado*/
        [Theory (DisplayName = "Me trae todas las polizas de un asegurado")]
        [InlineData(25872770)]
        public List<PolizaAseguradoDTO> polizasAseguradoTrue(int ci)
        {
            var result = _dao.getPolicyInsured(ci);
            Assert.True(result.Any());
            return result;
        }
        
        /*Valida que el asegurado no tiene polizas*/
        [Theory (DisplayName = "El asegurado no tiene polizas")]
        [InlineData(25872775)]
        public Task polizasAseguradoNull(int ci)
        {
            var result = Assert.Throws<RCVExceptions>(()=>this._dao.getPolicyInsured(ci)); 
            Assert.Equal(result.MensajeSoporte, "El asegurado no tiene polizas");
            return Task.CompletedTask; 
        }
        
        /*Valida la excepción del método*/
        [Theory (DisplayName = "Valida la excepción del método")]
        [InlineData(25872775)]
        public Task polizasAseguradoExcepcion(int ci)
        {
            var result = Assert.Throws<RCVExceptions>(()=>this._dao.getPolicyInsured(ci)); 
            Assert.Equal(result.Mensaje, "No se ha podido presentar la lista de polizas");
            return Task.CompletedTask; 
        }
        /*-----------------------------------------------------------------------------------------*/
        
        /*EVAUACIÓN INDIVIDUAL EN CLASE TRAER POLIZAS CON FECHA DE VENCIMIENTO*/
        [Fact (DisplayName = "Trae polizas compradas en 2020")]
        public Task getPolizaTrue()
        {
            var fecha = DateTime.Parse("01/01/2021"); //todas con fecha de vencimiento 2021
            var result = _dao.getPolicy(fecha);
            Assert.True(result.Any()); 
            return Task.CompletedTask; 
        }
    }
}