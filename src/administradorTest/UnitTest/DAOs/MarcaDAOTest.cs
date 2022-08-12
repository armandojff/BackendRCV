using System;
using System.Linq;
using System.Threading.Tasks;
using administrador.Exceptions;
using administrador.Persistence.DAOs.Implementations;
using administrador.Persistence.Database;
using administradorTest.DataSeed;
using Bogus;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
namespace administradorTest.UnitTest.DAOs
{
    public class MarcaDAOTest
    {
        private readonly MarcaDAO _dao;
        private readonly Mock<IRCVDbContext> _contextMock;
        private readonly Mock<ILogger<MarcaDAO>> _mockLogger;

        public MarcaDAOTest()
        {
            var faker = new Faker();
            _contextMock = new Mock<IRCVDbContext>();
            _mockLogger = new Mock<ILogger<MarcaDAO>>();
            _dao = new MarcaDAO(_contextMock.Object);
            _contextMock.SetupDbContextDataMarca();
        }
        
        /*-------------createMarca()------------------*/
        /*valida que me inserta un incidente con éxito*/
        [Theory (DisplayName = "Valida sí me crea una marca")]
        [InlineData("Toyota")] 
        public Task createMarcaTrue(String marca)
        {
            var result = _dao.createMarca(marca);
            Assert.Equal("Marca creada con éxito",result);
            return Task.CompletedTask;
        }
        
        /*valida la excepción del método createMarca*/
        [Fact (DisplayName = "Valida la excepción del método createMarca")]
        public Task createMarcaFalse()
        {
            var result = Assert.Throws<RCVExceptions>(()=>this._dao.createMarca(null));
            Assert.Equal("Problemas al crear la marca",result.Mensaje);
            return Task.CompletedTask;      
        }
        
        /*------------getMarca()---------------*/
        /*Valida que me trae el guid de la marca*/
        [Theory (DisplayName = "Me trae el GUID de la marca existente")]
        [InlineData("Toyota")]
        public Task getMarcaTrue(string marca)
        {
            var result = _dao.getMarca(marca);
            var guid = new Guid("3fbfe10c-2dac-4a47-9de3-a725a6de11f8");
            Assert.Equal(guid, result.ToList()[0]);
            return Task.CompletedTask;        
        }
        
        /*Valida que no existe la marca*/
        [Theory (DisplayName = "No me existe la marca")]
        [InlineData("Toyotaa")]
        public Task getMarcaFalse(string marca)
        {
            var result = _dao.getMarca(marca);
            Assert.Equal(0,result.ToList().Count);
            return Task.CompletedTask;        
        }
        
        /*Valida la excepción del método*/
        [Fact (DisplayName = "Valida la excepción de la marca")]
        public Task getMarcaExcepcion()
        {
            var result = Assert.Throws<RCVExceptions>(()=>this._dao.getMarca(null));
            Assert.Equal("Problemas al consultar la marca",result.Mensaje);
            return Task.CompletedTask;        
        }
    }
}