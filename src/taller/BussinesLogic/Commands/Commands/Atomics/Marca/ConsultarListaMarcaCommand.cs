using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.Persistence.DAOs.Implementations;
using RCVUcabBackend.Persistence;



namespace RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Atomic{
    public class ConsultarListaMarcaCommand:Command<ICollection<MarcaCarroEntity>>{
        private readonly ICollection<MarcaCarroEntity> marca;
        private TallererEntity taller;
        private ICollection<MarcaCarroEntity> _result;

        public ConsultarListaMarcaCommand(ICollection<MarcaCarroEntity> marca,TallererEntity taller){
            this.marca=marca;
            this.taller=taller;
        }

        public override void Execute()
        {
            MarcaDB dao=TallerDAOFactory.crearMarcaDB();
            _result=dao.AsignarMarcaExistente(marca,taller);
        }

        public override ICollection<MarcaCarroEntity> GetResult()
        {
            return _result;
        }
    }
}