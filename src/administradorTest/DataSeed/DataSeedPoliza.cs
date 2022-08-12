using MockQueryable.Moq;
using Moq;
using administrador.Persistence.Database;
using administrador.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace administradorTest.DataSeed
{
    public static class DataSeedPoliza
    {
        public static Mock<DbSet<PolizaEntity>> mockSetPoliza = new Mock<DbSet<PolizaEntity>>();
        public static void SetupDbContextDataPoliza(this Mock<IRCVDbContext> _mockContext)
        {
            var requests = new List<PolizaEntity>
            {
                new PolizaEntity
                {
                    Id = new Guid("3fbfe10c-2dac-4a47-9de3-a725a6de92c6"),
                    tipo = "Completa",
                    compra = DateTime.Parse("01/01/2020"),
                    vencimiento = DateTime.Parse("01/01/2021"), 
                    desactivada = false,
                    AseguradoEntityId = 25872771
                },
                new PolizaEntity
                {
                    Id = new Guid("3fbfe10c-2dac-4a47-9de3-a725a6de92c4"),
                    tipo = "Completa",
                    compra = DateTime.Parse("01/01/2021"),
                    vencimiento = DateTime.Parse("01/01/2022"), 
                    desactivada = true,
                    AseguradoEntityId = 25872770
                },
            };
            _mockContext.Setup(c => c.poliza).Returns(mockSetPoliza.Object);
            _mockContext.Setup(c => c.DbContext.SaveChanges()).Returns(1);
            _mockContext.Setup(c => c.poliza).Returns(requests.AsQueryable().BuildMockDbSet().Object);
        }
    }
}