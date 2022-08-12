using administrador.Persistence.DAOs.Implementations;
namespace administrador.Commands.Atomics.MarcasDAO
{
    public class createMarcaCommand : Command<string>
    {
        private readonly string _marca;
        private string _result;
        
        public createMarcaCommand(string marca)
        {
            _marca = marca;
        }
        
        public override void Execute()
        {
            Persistence.DAOs.Implementations.MarcaDAO dao = AdministradorDAOFactory.CreateMarcaDAO();
            _result = dao.createMarca(_marca);
        }

        public override string GetResult()
        {
            return _result;
        }
    }
}