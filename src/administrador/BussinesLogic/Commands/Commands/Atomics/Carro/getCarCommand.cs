using administrador.BussinesLogic.DTOs;
using administrador.Persistence.DAOs.Implementations;

namespace administrador.Commands.Atomics
{
    public class getCarCommand : Command<CarroDTO>
    {
        private readonly string _placa;
        private CarroDTO _result;
        
        public getCarCommand(string placa)
        {
            _placa = placa;
        }
        
        public override void Execute()
        {
            CarroDAO dao = AdministradorDAOFactory.CreateCarroDAO();
            _result = dao.getCar(_placa);
        }

        public override CarroDTO GetResult()
        {
            return _result;
        }
    }
}