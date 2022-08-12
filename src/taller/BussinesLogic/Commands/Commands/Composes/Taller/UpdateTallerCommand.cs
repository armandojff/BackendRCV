using RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Atomic;
using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.BussinesLogic.Mappers;
using RCVUcabBackend.Persistence.Entities;

namespace RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Composes{
    public class UpdateTallerCommand:Command<TallerDTO>
    {
        private readonly TallererEntity taller;
        private readonly Guid id_taller;
        private TallerDTO _result;

        public UpdateTallerCommand(TallererEntity taller,Guid id_taller){
            this.taller=taller;
            this.id_taller=id_taller;
        }

        public override void Execute()
        {
            ConsultarListaMarcaCommand comandMarcaConsulta=CommandFactory.crearConsultarListaMarcaCommand(taller.marcas,taller);
            comandMarcaConsulta.Execute();
            taller.marcas=comandMarcaConsulta.GetResult();
            ActualizarTallerCommand comandTallerActualizar=CommandFactory.crearActualizarTallerCommand(taller,id_taller);
            comandTallerActualizar.Execute();
            _result=comandTallerActualizar.GetResult();
        }

        public override TallerDTO GetResult()
        {
            return _result;
        }
    }
}