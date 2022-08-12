using administrador.BussinesLogic.DTOs;
using administrador.Controllers.Administrador;
using administrador.Persistence.DAOs.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace administradorTest.IntegralTest;

public class PolizaControllerIntegralTest
{
    private readonly PolizaController _controller;
    private readonly Mock<IIncidenteDAO> _serviceMock;
    private readonly Mock<ILogger<PolizaController>> _loggerMock;
    public PolizaControllerIntegralTest()
    {
        _loggerMock = new Mock<ILogger<PolizaController>>();
        _serviceMock = new Mock<IIncidenteDAO>();
        _controller = new PolizaController(_loggerMock.Object);
        _controller.ControllerContext = new ControllerContext();
        _controller.ControllerContext.HttpContext = new DefaultHttpContext();
        _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
    }

    [Fact(DisplayName = "Create incident")]
    public Task createPoliza()
    {
        var fecha1 = DateTime.Parse("01/01/2018");
        var fecha2 = DateTime.Parse("01/01/2023");
        var faker = new Bogus.Faker<PolizaSimpleDTO>()
            .RuleFor(x => x.tipo, f => f.Random.String2(10, "abcdefghijkmlqpo"))
            .RuleFor(x => x.vencimiento, f => f.Date.Between(fecha1, fecha2))
            .RuleFor(x => x.asegurado, f => f.Random.Int(3000000, 40000000))
            .RuleFor(x => x.placa, f => f.Random.String2(10, "abcdefghijkmlqpo"))
            .RuleFor(x => x.precio, f => f.Random.Int(3000000, 40000000))
            .RuleFor(x => x.cobertura, f => f.Random.Int(3000000, 40000000));
        var incidenteDTOFaker = faker.Generate();
        var result = _controller.addPolicy(incidenteDTOFaker);
        Assert.Equal("Poliza creada con éxito", result.Data);
        return Task.CompletedTask;
    }
}