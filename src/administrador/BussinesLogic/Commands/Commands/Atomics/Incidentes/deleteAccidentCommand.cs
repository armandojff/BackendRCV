using System;
using administrador.Persistence.DAOs.Implementations;

namespace administrador.Commands.Atomics.IncidentesDAO
{
    public class deleteAccidentCommand : Command<string>
    {
        private readonly Guid _id;
        private string _result;
        
        public deleteAccidentCommand(Guid id)
        {
            _id = id;
        }
        
        public override void Execute()
        {
            IncidenteDAO dao = AdministradorDAOFactory.CreateIncidenteDAO();
            _result = dao.deleteAccident(_id);
        }

        public override string GetResult()
        {
            return _result;
        }
    }
}