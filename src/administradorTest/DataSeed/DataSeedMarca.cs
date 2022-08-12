using MockQueryable.Moq;
using Moq;
using administrador.Persistence.Database;
using administrador.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using administrador.Persistence.DAOs.Implementations;
using Microsoft.EntityFrameworkCore;
namespace administradorTest.DataSeed
{
    public static class DataSeedMarca
    {
        public static Mock<DbSet<MarcaEntity>> mockSetMarca = new Mock<DbSet<MarcaEntity>>();
        public static void SetupDbContextDataMarca(this Mock<IRCVDbContext> _mockContext)
        {
            var requests = new List<MarcaEntity>
            {
                new MarcaEntity()
                {
                    Id = new Guid("3fbfe10c-2dac-4a47-9de3-a725a6de11f8"),
                    marca = "Toyota",
                    categoria = "Rústico"
                },
            };
            _mockContext.Setup(c => c.marca).Returns(mockSetMarca.Object);
            _mockContext.Setup(c => c.DbContext.SaveChanges()).Returns(1);
            _mockContext.Setup(c => c.marca).Returns(requests.AsQueryable().BuildMockDbSet().Object);
        }
    }
}