using MockQueryable.Moq;
using Moq;
using administrador.Persistence.Database;
using administrador.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace administradorTest.DataSeed
{
    public static class DataSeedIncidente
    {
        public static Mock<DbSet<IncidentesEntity>> mockSetIncidente = new Mock<DbSet<IncidentesEntity>>();
        public static void SetupDbContextDataIncidente(this Mock<IRCVDbContext> _mockContext)
        {
            var requests = new List<IncidentesEntity>
            {
                new IncidentesEntity
                {
                    Id = new Guid("3fbfe10c-2dac-4a47-9de3-a725a6de10e6"),
                    descripcion = "Accidente por choque lateral",
                    ubicacion = "Caricuao, Caracas",
                    fecha = DateTime.Parse("01/01/2021"), 
                    PolizaEntityId = new Guid("3fbfe10c-2dac-4a47-9de3-a725a6de92c6")
                },
            };
            _mockContext.Setup(c => c.incident).Returns(mockSetIncidente.Object);
            _mockContext.Setup(c => c.DbContext.SaveChanges()).Returns(1);
            _mockContext.Setup(c => c.incident).Returns(requests.AsQueryable().BuildMockDbSet().Object);
        }
    }
}