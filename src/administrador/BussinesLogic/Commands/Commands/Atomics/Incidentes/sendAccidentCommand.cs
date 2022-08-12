using System.Reflection.Metadata.Ecma335;
using administrador.BussinesLogic.DTOs;
using administrador.Persistence.DAOs.MQ;
using administrador.Persistence.Entities;

namespace administrador.Commands.Atomics.IncidentesDAO
{
    public class sendAccidentCommand : Command<string>
    {
        private readonly Guid _response;
        public sendAccidentCommand(Guid response)
        {
            _response = response;
        }

        public override void Execute()
        {
            AdminMQ dao = AdministradorDAOFactory.createAdminMQ();
            dao.Producer(_response);
        }

        public override string GetResult()
        {
            throw new NotImplementedException();
        }
    }
}
