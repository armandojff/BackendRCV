using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.Persistence.DAOs.Implementations;
using RCVUcabBackend.Persistence.Entities.ChecksEntitys;
using RCVUcabBackend.Persistence;
using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.BussinesLogic.DTOs;

namespace RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Atomic{

    public class ConsultarRequerimientosAsignadosPorFiltroCommand:Command<ICollection<AnalisisConsultaDTO>>
    {
        private readonly Guid Id_taller;
        private readonly CheckEstadoAnalisisAccidente estado;
        private ICollection<AnalisisConsultaDTO> _result;

        public ConsultarRequerimientosAsignadosPorFiltroCommand(Guid Id_taller,CheckEstadoAnalisisAccidente estado){
            this.Id_taller=Id_taller;
            this.estado=estado;
        }

        public override void Execute()
        {
            AnalisisDB dao=TallerDAOFactory.crearAnalisisDB();
            _result=dao.ConsultarRequerimientosAsignadosPorFiltro(this.Id_taller,this.estado);
        }

        public override ICollection<AnalisisConsultaDTO> GetResult()
        {
            return _result;
        }
    }
}