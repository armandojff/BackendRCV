using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using administrador.BussinesLogic.DTOs;
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
    public class CarroDAOTest
    {
        private readonly CarroDAO _dao;
        private readonly MarcaDAO _dao1;
        private readonly Mock<IRCVDbContext> _contextMock;
        private readonly Mock<ILogger<CarroDAO>> _mockLogger;

        public CarroDAOTest()
        {
            var faker = new Faker();
            _contextMock = new Mock<IRCVDbContext>();
            _mockLogger = new Mock<ILogger<CarroDAO>>();
            _dao = new CarroDAO(_contextMock.Object);
            _dao1 = new MarcaDAO(_contextMock.Object);
            _contextMock.SetupDbContextDataCarro();
            _contextMock.SetupDbContextDataMarca();
        }
        
        /*-------------createCar()------------------*/
        /*valida que me inserta un carro con éxito marca existente*/
        [Fact (DisplayName = "Valida que sí me inserta un carro (1)")]
        public Task createCarTrue()
        {
            CarroDTO car = new CarroDTO()
            {
                placa = "ABZ1058",
                marca = "Toyota",
                serial = new Guid("3fbfe10c-3ace-5e40-8da2-a725a6fa90e0"),
                fabricacion = DateTime.Parse("20/01/2020"),
                segmento = "A",
                color = "Blanco"
            };
            var result = _dao.createCar(car);
            Assert.Equal("Carro registrado con éxito",result);
            return Task.CompletedTask;
        }
        
        /*valida que me inserta un carro con éxito marca inexistente*/
        [Fact (DisplayName = "Valida que sí me inserta un carro (2)")]
        public Task createCarTrue2()
        {
            CarroDTO car = new CarroDTO()
            {
                placa = "ABZ1179",
                marca = "Chery",
                serial = new Guid("3fbfe10c-3ace-5e40-8da2-a725a6fe80f1"),
                fabricacion = DateTime.Parse("20/01/2021"),
                segmento = "A",
                color = "Azul"
            };
            var result = _dao.createCar(car);
            Assert.Equal("Carro registrado con éxito",result);
            return Task.CompletedTask;
        }
        
        /*valida la excepción del método*/
        [Fact (DisplayName = "Valida la expción al insertar un carro")]
        public Task createCarTrueFalse()
        {
            var result = Assert.Throws<RCVExceptions>(()=>this._dao.createCar(null)); 
            Assert.Equal(result.Mensaje, "Error al crear el carro");
            return Task.CompletedTask;
        }
        
        /*-------------getCar()------------------*/
        /*valida que me trae un carro con éxito*/
        [Theory (DisplayName = "Valida que sí me trae un carro")]
        [InlineData("ABZ1893")]
        public Task getCarTrue(String placa)
        {
            CarroDTO car = new CarroDTO()
            {
                placa = "ABZ1893",
                marca = "Toyota",
                serial = new Guid("3fbfe10c-2dac-4a47-9de3-a725a6de10f2"),
                fabricacion = DateTime.Parse("01/01/2018"),
                segmento = "A",
                color = "Blanco"
            };
            var result = _dao.getCar(placa);
            Assert.Equal(car.placa,result.placa);
            return Task.CompletedTask;
        }
        
        /*valida la excepción del método*/
        [Fact (DisplayName = "Valida la expción al traer un carro")]
        public Task getCarFalse()
        {
            var result = Assert.Throws<RCVExceptions>(()=>this._dao.getCar(null)); 
            Assert.Equal(result.Mensaje, "No se ha podido presentar el carro");
            return Task.CompletedTask;
        }
    }
}