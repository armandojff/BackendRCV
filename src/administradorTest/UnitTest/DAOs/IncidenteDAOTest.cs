using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using administrador.BussinesLogic.DTOs;
using administrador.Exceptions;
using administrador.Persistence.DAOs.Implementations;
using administrador.Persistence.Database;
using administrador.Persistence.Entities;
using administradorTest.DataSeed;
using Bogus;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace administradorTest.UnitTest.DAOs
{
    public class IncidenteDAOTest
    {
        private readonly IncidenteDAO _dao;
        private readonly Mock<IRCVDbContext> _contextMock;
        private readonly Mock<ILogger<PolizaDAO>> _mockLogger;

        public IncidenteDAOTest()
        {
            var faker = new Faker();
            _contextMock = new Mock<IRCVDbContext>();
            _mockLogger = new Mock<ILogger<PolizaDAO>>();
            _dao = new IncidenteDAO(_contextMock.Object);
            _contextMock.SetupDbContextDataIncidente();
        }
        
        /*-------------createAccident()------------------*/
        /*valida que me inserta un incidente con éxito*/
        [Theory (DisplayName = "Valida sí me inserta un incidente")]
        [InlineData("3fbfe10c-2dac-4a47-9de3-a725a6de92c6")] 
        public Task createAccidentTrue(String id)
        {
            Guid polizaId = new Guid(id);
            IncidentesEntity incident = new IncidentesEntity()
            {
                fecha = DateTime.Parse("20/01/2020"),
                ubicacion = "Colinas de Bello Monte, Caracas",
                descripcion = "Accidente ocurrido por desperfecto mécanico",
                PolizaEntityId = polizaId,
            };
            var result = _dao.createAccident(incident);
            Assert.Equal("Incidente registrado con éxito",result);
            _contextMock.Verify(m => m.DbContext.SaveChanges(), Times.Exactly(1));
            return Task.CompletedTask;
        }
        
        /*valida que no me inserta un incidente (Excepción)*/
        [Fact(DisplayName = "Valida que no me inserta un incidente")] //acá debería traer una excepcion
        public Task createAccidentFalse()
        {
            var result = Assert.Throws<RCVExceptions>(()=>this._dao.createAccident(null)); 
            Assert.Equal(result.Mensaje, "No se puede crear el incidente");
            return Task.CompletedTask;
        }
        
        /*---------------------------getAccident()----------------------------*/
        /*Valida que me trae almenos un incidente*/
        [Theory (DisplayName = "Valida que sí me trae un incidente")]
        [InlineData("3fbfe10c-2dac-4a47-9de3-a725a6de92c6")] 
        public List<IncidentesSimpleDTO> getAccidentTrue(String id)
        {
            Guid polizaId = new Guid(id);
            var result = _dao.getAccident(polizaId);
            Assert.True(result.Any());
            return result;
        }
        
        /*Valida que la poliza no tiene incidentes*/
        [Theory (DisplayName = "Valida que no me trae un incidente")]
        [InlineData("3fbfe10c-2dac-4a47-9de3-a725a6de92c5")] 
        public Task getAccidentFalse(String id)
        {
            Guid polizaId = new Guid(id);
            var result = Assert.Throws<RCVExceptions>(()=>this._dao.getAccident(polizaId)); 
            Assert.Equal(result.MensajeSoporte, "Esta poliza no tiene incidentes registrados");
            return Task.CompletedTask; 
        }
        
        /*Valida que me ingresa en la excepción*/
        [Theory (DisplayName = "Valida la excepción en traer un incidente")]
        [InlineData("3fbfe10c-2dac-4a47-9de3-a725a6de92c5")] 
        public Task getAccidentExcepcion(String id)
        {
            Guid polizaId = new Guid(id);
            var result = Assert.Throws<RCVExceptions>(()=>this._dao.getAccident(polizaId)); 
            Assert.Equal(result.Mensaje, "No se ha podido presentar la lista de incidentes");
            return Task.CompletedTask; 
        }
        
        /*-------------------------------------deleteAccident()-----------------------------------*/
        /*valida que sí me elimina el accidente*/
        [Theory (DisplayName = "Valida que sí me elimina el accidente")]
        [InlineData("3fbfe10c-2dac-4a47-9de3-a725a6de10e6")] 
        public Task deleteAccidentTrue(String id)
        {
            Guid incidentID = new Guid(id);
            var result = _dao.deleteAccident(incidentID);
            Assert.Equal("Incidente borrado con éxito", result);
            return Task.CompletedTask; 
        }
        
        /*Valida que no elimina el accidente porque no existe*/
        [Theory (DisplayName = "Valida que no existe el incidente a eliminar")]
        [InlineData("3fbfe10c-2dac-4a47-9de3-a725a6de10e9")] 
        public Task deleteAccidentFalse(String id)
        {
            Guid incidentID = new Guid(id);
            var result = Assert.Throws<RCVExceptions>(()=>this._dao.deleteAccident(incidentID)); 
            Assert.Equal(result.MensajeSoporte, "El incidente ingresado no existe");
            return Task.CompletedTask; 
        }
        
        /*Valida la excepción general del método*/
        [Theory (DisplayName = "Valida la excepción general en el incidente")]
        [InlineData("3fbfe10c-2dac-4a47-9de3-a725a6de10e9")] 
        public Task deleteAccidentExcepcion(String id)
        {
            Guid incidentID = new Guid(id);
            var result = Assert.Throws<RCVExceptions>(()=>this._dao.deleteAccident(incidentID)); 
            Assert.Equal(result.Mensaje, "No se ha podido borrar el incidente");
            return Task.CompletedTask; 
        }
    }
}