using System.Collections.Generic;
using administrador.BussinesLogic.DTOs;
using administrador.Persistence.DAOs.Implementations;

namespace administrador.Commands.Atomics
{
    public class getInsuredAllCommand : Command<List<PAseguradoDTO>>
    {
        private List<PAseguradoDTO> _result;
        public getInsuredAllCommand() {}
        public override void Execute()
        {
            AseguradoDAO dao = AdministradorDAOFactory.createAseguradoDAO();
            _result = dao.getInsured();
        }

        public override List<PAseguradoDTO> GetResult()
        {
            return _result;
        }
    }
}