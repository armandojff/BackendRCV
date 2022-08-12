using administrador.BussinesLogic.DTOs;
using administrador.Commands.Atomics.IncidentesDAO;
using administrador.Persistence.Entities;

namespace administrador.Commands.Composes
{
    public class insertAccidentCommand : Command<string>
    {
        private readonly IncidentesEntity _incident;
        private string _result;

        public insertAccidentCommand(IncidentesEntity incident)
        {
            _incident = incident;
        }

        public override void Execute()
        {
            createAccidentCommand commandCreateAccident = CommandFactory.createCreateAccidentCommand(_incident);
            commandCreateAccident.Execute();
            sendAccidentCommand commandSendAccident = CommandFactory.createSendAccidentCommand(_incident.Id);
            commandSendAccident.Execute();
        }

        public override string GetResult()
        {
            return _result;
        }
    }
}