using RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Atomic;
using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.BussinesLogic.Mappers;
using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.Persistence.Entities.ChecksEntitys;

namespace RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Composes{
    public class crearCotizacionDeAnalisisCommand:Command<string>
    {
        private readonly CotizacionTallerEntity cotizacion;

        private readonly string fechaInicio;
        private readonly string fechaCulminacion;
        private readonly Guid idUsuarioTaller;
        private string _result;

        public crearCotizacionDeAnalisisCommand(CotizacionTallerEntity cotizacion,Guid idUsuarioTaller,string fechaInicio,string fechaCulminacion){
            this.cotizacion=cotizacion;
            this.idUsuarioTaller=idUsuarioTaller;
            this.fechaInicio=fechaInicio;
            this.fechaCulminacion=fechaCulminacion;
        }

        public override void Execute()
        {
            ConsultarUsuarioTallerPorIdCommand comandUsuarioTallerConsulta=CommandFactory.crearConsultarUsuarioTallerPorIdCommand(idUsuarioTaller);
            comandUsuarioTallerConsulta.Execute();
            cotizacion.usuario_taller=comandUsuarioTallerConsulta.GetResult();
            InsertCotizacionTallerCommand ComandCrearCotizacionTaller=CommandFactory.crearInsertCotizacionTallerCommand(cotizacion,fechaInicio,fechaCulminacion);
            ComandCrearCotizacionTaller.Execute();
            _result=ComandCrearCotizacionTaller.GetResult();
            var messageMQ=CotizacionMQMapper.MapDtoToEntity(cotizacion,fechaInicio,fechaCulminacion);
            SendCotizacionCommand commandSend=CommandFactory.crearSendCotizacionCommand(messageMQ);
            commandSend.Execute();
        }

        public override string GetResult()
        {
            return _result;
        }
    }
}