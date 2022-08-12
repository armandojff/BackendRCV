using administrador.BussinesLogic.DTOs;
using administrador.Commands.Atomics;
using administrador.Persistence.Entities;

namespace administrador.Commands.Composes
{
    public class insertInsuredCommand : Command<string>
    {
        private readonly AseguradoEntity _insured;
        private string _result;

        public insertInsuredCommand(AseguradoEntity insured)
        {
            _insured = insured;
        }

        public override void Execute()
        {
            createInsuredCommand commandCreate = CommandFactory.createCreateInsuredCommand(_insured);
            commandCreate.Execute();
            _result = commandCreate.GetResult();
            sendInsuredCommand commandSend = CommandFactory.createSendInsuredCommand(_result);
            commandSend.Execute();

        }

        public override string GetResult()
        {
            return _result;
        }
    }
}