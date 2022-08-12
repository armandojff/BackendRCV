using administrador.BussinesLogic.DTOs;
using administrador.Controllers.Administrador;
using administrador.Persistence.DAOs.Interfaces;
using administrador.Persistence.Entities;
using administrador.Responses;
using Bogus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace administradorTest.IntegralTest;

public class AseguradoControllerIntegralTest
{
    
    private readonly AseguradoController _controller;
    private readonly Mock<IAseguradoDAO> _serviceMock;
    private readonly Mock<ILogger<AseguradoController>> _loggerMock;
    public AseguradoDTO asegurado = It.IsAny<AseguradoDTO>();
    public PAseguradoDTO aseguradoSimple = It.IsAny<PAseguradoDTO>();
    public AseguradoEntity a = new AseguradoEntity();
    public int cedula = It.IsAny<int>();

    public AseguradoControllerIntegralTest()
    {
        _loggerMock = new Mock<ILogger<AseguradoController>>();
        _serviceMock = new Mock<IAseguradoDAO>();
        _controller = new AseguradoController(_loggerMock.Object);
        _controller.ControllerContext = new ControllerContext();
        _controller.ControllerContext.HttpContext = new DefaultHttpContext();
        _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
    }

    [Fact(DisplayName = "Add insured")]
    public Task createInsured()
    {
        var faker = new Bogus.Faker<AseguradoDTO>()
            .RuleFor(x => x.ci, f => f.Random.Int(3000000, 40000000))
            .RuleFor(x => x.sexo, f => f.Random.Char())
            .RuleFor(x => x.primer_n, f => f.Name.FirstName())
            .RuleFor(x => x.segundo_n, f => f.Name.FirstName())
            .RuleFor(x => x.primer_a, f => f.Name.LastName())
            .RuleFor(x => x.segundo_a, f => f.Name.LastName());
        var aseguradoDTOFaker = faker.Generate();
        var result = _controller.addInsured(aseguradoDTOFaker);
        Assert.Equal("Éxitoso", result.Data);
        return Task.CompletedTask;
    }
    
    [Theory(DisplayName = "Get insured")]
    [InlineData(11889533)] 
    public Task getInsured(int ci)
    {
        var result = _controller.getInsuredSpecific(ci);
        Assert.IsType<ApplicationResponse<PAseguradoDTO>>(result);
        return Task.CompletedTask;
    }
}