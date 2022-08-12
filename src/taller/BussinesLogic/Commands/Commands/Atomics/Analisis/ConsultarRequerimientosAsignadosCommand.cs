using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.Persistence.DAOs.Implementations;
using RCVUcabBackend.Persistence;
using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.BussinesLogic.DTOs;

namespace RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Atomic{

    public class ConsultarRequerimientosAsignadosCommand:Command<ICollection<AnalisisConsultaDTO>>
    {
        private readonly Guid Id_anlisis;
        private ICollection<AnalisisConsultaDTO> _result;

        public ConsultarRequerimientosAsignadosCommand(Guid Id_anlisis){
            this.Id_anlisis=Id_anlisis;
        }

        public override void Execute()
        {
            AnalisisDB dao=TallerDAOFactory.crearAnalisisDB();
            _result=dao.ConsultarRequerimientosAsignados(this.Id_anlisis);
        }

        public override ICollection<AnalisisConsultaDTO> GetResult()
        {
            return _result;
        }
    }
}