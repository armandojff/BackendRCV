using administrador.BussinesLogic.DTOs;
using administrador.Controllers.Administrador;
using administrador.Persistence.DAOs.Interfaces;
using administrador.Persistence.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace administradorTest.IntegralTest;

public class IncidentControllerIntegralTest
{
    private readonly IncidenteController _controller;
    private readonly Mock<IIncidenteDAO> _serviceMock;
    private readonly Mock<ILogger<IncidenteController>> _loggerMock;
        
    public IncidentControllerIntegralTest()
    {
        _loggerMock = new Mock<ILogger<IncidenteController>>();
        _serviceMock = new Mock<IIncidenteDAO>();
        _controller = new IncidenteController(_loggerMock.Object);
        _controller.ControllerContext = new ControllerContext();
        _controller.ControllerContext.HttpContext = new DefaultHttpContext();
        _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
    }

    [Fact(DisplayName = "Create incident")]
    public Task createIncident()
    {
        var fecha1 = DateTime.Parse("01/01/2018");
        var fecha2 = DateTime.Parse("01/01/2023");
        var faker = new Bogus.Faker<IncidentesDTO>()
            .RuleFor(x => x.fecha, f => f.Date.Between(fecha1, fecha2))
            .RuleFor(x => x.descripcion, f => f.Random.String2(10, "abcdefghijkmlqpo"))
            .RuleFor(x => x.ubicacion, f => f.Random.String2(10, "abcdefghijkmlqpo"))
            .RuleFor(x => x.PolizaEntityId, f => f.Random.Guid());
        var incidenteEntityFaker = faker.Generate();
        var result = _controller.createAccident(incidenteEntityFaker);
        Assert.Equal("Incidente registrado con éxito", result.Data);
        return Task.CompletedTask;
    }
}