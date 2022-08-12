using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.Persistence.DAOs.Implementations;
using RCVUcabBackend.Persistence;



namespace RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Atomic{
    public class InsertCotizacionTallerCommand:Command<string>{
        private readonly CotizacionTallerEntity cotizacion;
        private readonly string fechaInicio;
        private readonly string fechaCulminacion;
        
        private string _result;

        public InsertCotizacionTallerCommand(CotizacionTallerEntity cotizacion,string fechaInicio,string fechaCulminacion){
            this.cotizacion=cotizacion;
            this.fechaInicio=fechaInicio;
            this.fechaCulminacion=fechaCulminacion;
        }

        public override void Execute()
        {
            CotizacionDB dao=TallerDAOFactory.crearCotizacionDB();
            _result=dao.CrearCotizacionDeReparacion(cotizacion,fechaInicio,fechaCulminacion);
        }

        public override string GetResult()
        {
            return _result;
        }
    }
}