using perito.BussinesLogic.DTOs;
using perito.BussinesLogic.Mappers;
using perito.Commands;
using perito.Commands.Atomics.Perito;
using perito.Persistence.Entities;

namespace perito.Commands.Composes

{

    public class CreateAnalisisCommand : Command<AnalisisDTO>
    {
        private AnalisisDTO _result;
        private readonly AnalisisEntity analisis;

        public CreateAnalisisCommand(AnalisisEntity analisis)
        {
            this.analisis = analisis;
        }

        public override void Execute()
        {
            InsertAnalisisCommand command = CommandFactory.createCreateAnalisisCommand(analisis);
            command.Execute();
            _result = command.GetResult();
            var messageMQ = AnalisisMapper.MapDtoToEntity(_result);
            SendAnalisisToTallerCommand command2 = CommandFactory.createSendAnalisisCommand(messageMQ.Id);
            command2.Execute();
        }

        public override AnalisisDTO GetResult()
        {
            return _result;
        }
    }
}