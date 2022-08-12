using administrador.BussinesLogic.DTOs;
using administrador.Persistence.DAOs.Implementations;
using administrador.Persistence.Entities;

namespace administrador.Commands.Atomics
{
    public class createInsuredCommand : Command<string>
    {
        private readonly AseguradoEntity _insured;
        private string _result;
        
        public createInsuredCommand(AseguradoEntity insured)
        {
            _insured = insured;
        }
        
        public override void Execute()
        {
            AseguradoDAO dao = AdministradorDAOFactory.createAseguradoDAO();
            _result = dao.createInsured(_insured);
        }

        public override string GetResult()
        {
            return _result;
        }
    }
}