using System.Collections.Generic;
using administrador.BussinesLogic.DTOs;
using administrador.Persistence.DAOs.Implementations;

namespace administrador.Commands.Atomics.PolizasDAO
{
    public class getPolizaInsuredCommand : Command<List<PolizaAseguradoDTO>>
    {
        private readonly int _ci;
        private List<PolizaAseguradoDTO> _result;

        public getPolizaInsuredCommand(int ci)
        {
            _ci = ci;
        }

        public override void Execute()
        {
            PolizaDAO dao = AdministradorDAOFactory.CreatePolizaDAO();
            _result = dao.getPolicyInsured(_ci);
        }

        public override List<PolizaAseguradoDTO> GetResult()
        {
            return _result;
        }
    }
}