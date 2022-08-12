using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using administrador.BussinesLogic.DTOs;
using administrador.Persistence.DAOs.Interfaces;
using administrador.Persistence.Database;
using administrador.Exceptions;
using administrador.Persistence.Entities;
namespace administrador.Persistence.DAOs.Implementations
{
    public class CarroDAO : ICarroDAO
    {
        private static DesignTimeDbContextFactory desing = new DesignTimeDbContextFactory();
        private IRCVDbContext _context = desing.CreateDbContext(null);

        public CarroDAO(){}
        public CarroDAO(IRCVDbContext context)
        {
            _context = context; //evaluar
        }
        
        /*Crea un carro*/
        public string createCar(CarroDTO carro)
        {
            string createBrand;
            Guid guidBrand = default; 
            try
            {
                /*busco si esa marca está registrada*/
                var getBrand = _context.marca
                    .Where(p => p.marca == carro.marca)
                    .Select(p => p.Id).ToList();
                if (getBrand.Count == 0)
                {
                    /*si no está registrada creo la marca*/
                    var marca = new MarcaEntity()
                    {
                        marca = carro.marca
                    };
                    /*Me traigo el id de la marca*/
                    guidBrand = marca.Id;
                    _context.marca.Add(marca);
                    _context.DbContext.SaveChanges();
                }
                var car = new CarrosEntity(){
                    placa = carro.placa,
                    MarcaEntityId = guidBrand,
                    serial = carro.serial,
                    fabricacion = carro.fabricacion,
                    segmento = carro.segmento,
                    color = carro.color
                };
                _context.cars.Add(car);
                _context.DbContext.SaveChanges();
                return "Carro registrado con éxito";
            }
            catch(Exception ex){
                throw new RCVExceptions("Error al crear el carro", ex);
            }
        }
        
        /*Me trae un carro por Placa*/
        public CarroDTO getCar(string placa)
        {
            try
            {
                if (placa == null) {throw new RCVExceptions("Error al consultar marca");}
                /*busco el id de la marca*/
                var brand = _context.cars
                    .Where(p => p.placa == placa)
                    .Select(p => p.MarcaEntityId).ToList();
                /*consulto el name de la marca*/
                var nameBrand = _context.marca
                    .Where(p => p.Id == brand.ToList()[0])
                    .Select(p => p.marca).ToList();
                /*traigo el carro con su nombre*/
                var car = _context.cars
                    .Where(p => p.placa == placa)
                    .Select(p => new CarroDTO()
                    {
                        placa = p.placa,
                        marca = nameBrand.ToList()[0],
                        serial = p.serial,
                        fabricacion = p.fabricacion.Value,
                        segmento = p.segmento,
                        color = p.color
                        
                    }).ToList();
                if(car.ToList().Count == 0){
                    throw new Exception("La placa no está registrada en el sistema");
                }
                return car.ToList()[0];
            }
            catch(Exception ex){
                throw new RCVExceptions("No se ha podido presentar el carro", ex.Message, ex);
            }
        }

    }
}
