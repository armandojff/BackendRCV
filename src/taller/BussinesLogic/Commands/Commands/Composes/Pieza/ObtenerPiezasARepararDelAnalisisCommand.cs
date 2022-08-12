using RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Atomic;
using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.BussinesLogic.Mappers;
using RCVUcabBackend.Persistence.Entities;

namespace RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Composes{

    public class ObtenerPiezasARepararDelAnalisisCommand:Command<ICollection<PiezasConsultDTO>>
    {
        private readonly Guid id_analisis;
        private ICollection<PiezasConsultDTO> _result;

        public ObtenerPiezasARepararDelAnalisisCommand(Guid id_analisis){
            this.id_analisis=id_analisis;
        }

        public override void Execute()
        {
            ConsultarAnalisisPorIdCommand comandMarcaConsultaAnalisis=CommandFactory.crearConsultarAnalisisPorIdCommand(id_analisis);
            comandMarcaConsultaAnalisis.Execute();
            ConsultarPiezasARepararCommand comandConsultarPiezasAFReparar=CommandFactory.crearConsultarPiezasARepararCommand(comandMarcaConsultaAnalisis.GetResult());
            comandConsultarPiezasAFReparar.Execute();
            _result=comandConsultarPiezasAFReparar.GetResult();
        }

        public override ICollection<PiezasConsultDTO> GetResult()
        {
            return _result;
        }
    }
}