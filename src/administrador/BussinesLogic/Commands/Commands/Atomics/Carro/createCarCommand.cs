using administrador.BussinesLogic.DTOs;
using administrador.Persistence.DAOs.Implementations;

namespace administrador.Commands.Atomics
{
    public class createCarCommand : Command<string>
    {
        private readonly CarroDTO _carro;
        private string _result;
        
        public createCarCommand(CarroDTO carro)
        {
            _carro = carro;
        }
        
        public override void Execute()
        {
            CarroDAO dao = AdministradorDAOFactory.CreateCarroDAO();
            _result = dao.createCar(_carro);
        }

        public override string GetResult()
        {
            return _result;
        }
    }
}