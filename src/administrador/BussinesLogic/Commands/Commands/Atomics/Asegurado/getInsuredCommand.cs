using System.Collections.Generic;
using administrador.BussinesLogic.DTOs;
using administrador.Persistence.DAOs.Implementations;

namespace administrador.Commands.Atomics
{
    public class getInsuredCommand : Command<PAseguradoDTO>
    {
        private readonly int _ci;
        private PAseguradoDTO _result;
        
        public getInsuredCommand(int ci)
        {
            _ci = ci;
        }
        
        public override void Execute()
        {
            AseguradoDAO dao = AdministradorDAOFactory.createAseguradoDAO();
            _result = dao.getInsured(_ci);
        }

        public override PAseguradoDTO GetResult()
        {
            return _result;
        }
    }
}