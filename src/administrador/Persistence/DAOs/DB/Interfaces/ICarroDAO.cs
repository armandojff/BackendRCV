using administrador.BussinesLogic.DTOs;

namespace administrador.Persistence.DAOs.Interfaces
{
    public interface ICarroDAO
    {
        public string createCar(CarroDTO carro);
        public CarroDTO getCar(string placa);
    }
}