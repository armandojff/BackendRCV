using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.Persistence.DAOs.Implementations;
using RCVUcabBackend.Persistence;
using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.BussinesLogic.DTOs;

namespace RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Atomic{

    public class ConsultarPiezasARepararCommand:Command<ICollection<PiezasConsultDTO>>
    {
        private readonly AnalisisEntity analisis;
        private ICollection<PiezasConsultDTO> _result;

        public ConsultarPiezasARepararCommand(AnalisisEntity analisis){
            this.analisis=analisis;
        }

        public override void Execute()
        {
            PiezasDB dao=TallerDAOFactory.crearPiezasDB();
            _result=dao.ConsultarPiezasAReparar(this.analisis);
        }

        public override ICollection<PiezasConsultDTO> GetResult()
        {
            return _result;
        }
    }
}