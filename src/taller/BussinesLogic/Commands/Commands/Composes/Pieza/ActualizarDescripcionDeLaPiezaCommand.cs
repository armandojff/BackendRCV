using RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Atomic;
using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.BussinesLogic.Mappers;
using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.Persistence.Entities.ChecksEntitys;

namespace RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Composes{
    public class ActualizarDescripcionDeLaPiezaCommand:Command<PiezasConsultDTO>
    {
        private readonly Guid id_pieza;
        private string nuevaDescripcion;
        private PiezasConsultDTO _result;

        public ActualizarDescripcionDeLaPiezaCommand(Guid id_pieza,string nuevaDescripcion){
            this.id_pieza=id_pieza;
            this.nuevaDescripcion=nuevaDescripcion;
        }

        public override void Execute()
        {
            ConsultarPiezaPorIdCommand comandPiezaConsulta=CommandFactory.crearConsultarPiezaPorIdCommand(id_pieza);
            comandPiezaConsulta.Execute();
            EditarDescripcionDeLaPiezaCommand comandPiezaActualizar=CommandFactory.crearEditarDescripcionDeLaPiezaCommand(comandPiezaConsulta.GetResult(),nuevaDescripcion);
            comandPiezaActualizar.Execute();
            _result=comandPiezaActualizar.GetResult();
        }

        public override PiezasConsultDTO GetResult()
        {
            return _result;
        }
    }
}