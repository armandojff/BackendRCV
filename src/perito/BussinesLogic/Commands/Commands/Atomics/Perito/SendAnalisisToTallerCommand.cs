using perito.BussinesLogic.DTOs;
using perito.Persistence.DAOs.MQ;

namespace perito.Commands.Atomics.Perito{

    public class SendAnalisisToTallerCommand : Command<Guid>
    {
        private readonly Guid _response;
        

            public SendAnalisisToTallerCommand(Guid response)
            {
                _response = response;
            }

            public override void Execute()
            {
                AdminMQ dao = PeritoDAOFactory.createAnalisisMQ();
                dao.Producer(_response);
            }

            public override Guid GetResult()
            {
                throw new NotImplementedException();
            }
        
    }

}