using System;
using System.Threading.Tasks;
using administrador.BussinesLogic.DTOs;
using administrador.Persistence.DAOs.Implementations;

namespace administrador.Commands.Atomics.PolizasDAO
{
    public class deletePolizaCommand : Command<Task<bool>>
    {
        private readonly Guid _poliza;
        private Task<bool> _result;
            
        public deletePolizaCommand(Guid poliza)
        {
            _poliza = poliza;
        }
            
        public override void Execute()
        {
            PolizaDAO dao = AdministradorDAOFactory.CreatePolizaDAO();
            _result = dao.deletePolicy(_poliza);
        }

        public override Task<bool> GetResult()
        {
            return _result;
        }
    }
}