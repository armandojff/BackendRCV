using RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Atomic;
using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.BussinesLogic.Mappers;
using RCVUcabBackend.Persistence.Entities;

namespace RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Composes{

    public class CrearTallerCommand:Command<TallerDTO>
    {
        private readonly TallererEntity taller;
        private TallerDTO _result;

        public CrearTallerCommand(TallererEntity taller){
            this.taller=taller;
        }

        public override void Execute()
        {
            ConsultarListaMarcaCommand comandMarcaConsulta=CommandFactory.crearConsultarListaMarcaCommand(taller.marcas,taller);
            comandMarcaConsulta.Execute();
            taller.marcas=comandMarcaConsulta.GetResult();
            InsertTallerCommand comandTallerInsert=CommandFactory.crearInsertTallerCommand(taller);
            comandTallerInsert.Execute();
            _result=comandTallerInsert.GetResult();
        }

        public override TallerDTO GetResult()
        {
            return _result;
        }
    }
}