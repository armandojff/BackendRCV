using administrador.BussinesLogic.DTOs;
using administrador.Persistence.DAOs.MQ;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;

namespace administrador.Commands.Atomics.Pagos;

public class consumerPagoCommand : Command<PagosDTO>
{
    private PagosDTO _response;
    public consumerPagoCommand()
    {
    }

    public override void Execute()
    {
        AdminMQ dao = AdministradorDAOFactory.createAdminMQ();
        string st=dao.Consumer();
        _response = JsonConvert.DeserializeObject<PagosDTO>(st);
    }

    public override PagosDTO GetResult()
    {
        return _response;
    }
}