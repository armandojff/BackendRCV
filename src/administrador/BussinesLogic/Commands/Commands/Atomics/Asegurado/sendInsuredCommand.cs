using administrador.Persistence.DAOs.MQ;

namespace administrador.Commands.Atomics
{
    public class sendInsuredCommand : Command<int>
    {
        private readonly string _response;
        public sendInsuredCommand(string response)
        {
            _response = response;
        }

        public override void Execute()
        {
            AdminMQ dao = AdministradorDAOFactory.createAdminMQ();
            dao.Producer(_response);
        }

        public override int GetResult()
        {
            throw new NotImplementedException();
        }
    }
}