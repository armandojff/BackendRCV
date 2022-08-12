using RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Atomic;
using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.BussinesLogic.Mappers;
using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.Persistence.Entities.ChecksEntitys;

namespace RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Composes{
    public class ActualizarEstadoDeLaPiezaCommand:Command<PiezasConsultDTO>
    {
        private readonly Guid id_pieza;
        private CheckEstadoPieza estado;
        private PiezasConsultDTO _result;

        public ActualizarEstadoDeLaPiezaCommand(Guid id_pieza,CheckEstadoPieza estado){
            this.id_pieza=id_pieza;
            this.estado=estado;
        }

        public override void Execute()
        {
            ConsultarPiezaPorIdCommand comandPiezaConsulta=CommandFactory.crearConsultarPiezaPorIdCommand(id_pieza);
            comandPiezaConsulta.Execute();
            EditarEstadoPiezaCommand comandPiezaActualizar=CommandFactory.crearEditarEstadoPiezaCommand(comandPiezaConsulta.GetResult(),estado);
            comandPiezaActualizar.Execute();
            _result=comandPiezaActualizar.GetResult();
        }

        public override PiezasConsultDTO GetResult()
        {
            return _result;
        }
    }
}