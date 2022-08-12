using System;
using Bogus;
using Microsoft.Extensions.Logging;
using Moq;
using administrador.Persistence.Database;
using administrador.Exceptions;
using administradorTest.DataSeed;
using System.Linq;
using System.Threading.Tasks;
using administrador;
using administrador.BussinesLogic.DTOs;
using administrador.Persistence.Entities;
using Xunit;
using AseguradoDAO = administrador.Persistence.DAOs.Implementations.AseguradoDAO;

namespace administradorTest.UnitTest.DAOs
{
    public class AseguradoDAOTest
    {
        private readonly AseguradoDAO _dao;
        private readonly Mock<IRCVDbContext> _contextMock;
        private readonly Mock<ILogger<AseguradoDAO>> _mockLogger;

        public AseguradoDAOTest()
        {
            var faker = new Faker();
            _contextMock = new Mock<IRCVDbContext>();
            _mockLogger = new Mock<ILogger<AseguradoDAO>>();
            _dao = new AseguradoDAO(_contextMock.Object);
            _contextMock.SetupDbContextDataAsegurado();
        }
        
        [Fact(DisplayName = "Consulta si hay algún asegurado")]
        public Task GetInsureTrue()
        {
            var result = _dao.getInsured();
            var isNoEmpty = result.Any(); //true si hay algún valor
            Assert.True(isNoEmpty); 
            return Task.CompletedTask; //es asincrono
        }

        [Theory (DisplayName = "Cuántos asegurados hay")] 
        [InlineData(2)]
        public Task GetInsuredCount(int value)
        {
            var result = _dao.getInsured().Count;
            Assert.Equal(value,result); 
            return Task.CompletedTask; 
        }
        
        [Theory (DisplayName = "Asegurado por DNI (Existe)")]
        [InlineData(25872770)] 
        public Task GetInsuredDNIT(int dni)
        {
            var result = _dao.getInsured(dni);
            var cedula = result.ci;
            Assert.Equal(dni,cedula); 
            return Task.CompletedTask; 
        }
        
        [Theory (DisplayName = "Asegurado por DNI (No Existe)")]
        [InlineData(25872775)] 
        public Task GetInsuredDNIF(int dni)
        {
            //en el dao solo se prueban los datos
            //en el controlador sí se puede mockear
            var result = Assert.Throws<RCVExceptions>(()=>this._dao.getInsured(dni)); //acá debería traer una excepcion
            Assert.Equal(result.Mensaje, "No se ha podido presentar la lista de asegurados");
            return Task.CompletedTask; 
        }
        
        [Theory (DisplayName = "Valida si me inserta un asegurado")]
        [InlineData(25872771)] 
        public Task CreateInsureTrue(int dni)
        {
            AseguradoEntity insured = new AseguradoEntity()
            {
                ci = dni,
                primer_n = "Adrián",
                segundo_n = "David",
                primer_a = "Garcia",
                segundo_a = "Espinoza",
                sexo = 'm'
            };
            String result = _dao.createInsured(insured);
            String expected = "Éxitoso";
            Assert.Equal(expected,result);
            _contextMock.Verify(m => m.DbContext.SaveChanges(), Times.Exactly(1));
            return Task.CompletedTask;
        }
        
        [Fact(DisplayName = "Valida no me inserta un asegurado")] //acá debería traer una excepcion
        public Task CreateInsureFalse()
        {
            //AseguradoDTO dto = new AseguradoDTO();
            var result = Assert.Throws<RCVExceptions>(()=>_dao.createInsured(null)); 
            Assert.Equal("No se puede crear, detalles: ",result.Mensaje);
            return Task.CompletedTask;
        }
    }
}

