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
    public static class DataSeedCarro
    {
        public static Mock<DbSet<CarrosEntity>> mockSetCarro = new Mock<DbSet<CarrosEntity>>();
        public static void SetupDbContextDataCarro(this Mock<IRCVDbContext> _mockContext)
        {
            var requests = new List<CarrosEntity>
            {
                new CarrosEntity()
                {
                    placa = "ABZ1893",
                    MarcaEntityId = new Guid("3fbfe10c-2dac-4a47-9de3-a725a6de11f8"),
                    serial = new Guid("3fbfe10c-2dac-4a47-9de3-a725a6de10f2"),
                    fabricacion = DateTime.Parse("01/01/2018"),
                    segmento = "A",
                    color = "Blanco"
                },
                new CarrosEntity()
                {
                    placa = "ABZ1057",
                    MarcaEntityId = new Guid("3fbfe10c-2dac-4a47-9de3-a725a6de11f8"),
                    serial = new Guid("3fbfe10c-2dac-4a47-9de3-a725a6de10f1"),
                    fabricacion = DateTime.Parse("01/01/2003"),
                    segmento = "C",
                    color = "Negro"
                },
            };
            _mockContext.Setup(c => c.cars).Returns(mockSetCarro.Object);
            _mockContext.Setup(c => c.DbContext.SaveChanges()).Returns(1);
            _mockContext.Setup(c => c.cars).Returns(requests.AsQueryable().BuildMockDbSet().Object);
        }
    }
}