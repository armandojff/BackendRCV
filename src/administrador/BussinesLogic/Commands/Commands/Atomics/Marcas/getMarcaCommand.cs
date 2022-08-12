using System;
using System.Collections.Generic;
using administrador.Persistence.DAOs.Implementations;
namespace administrador.Commands.Atomics.MarcaDAO
{
    public class getMarcaCommand : Command<List<Guid>>
    {
        private readonly string _marca;
        private List<Guid> _result;
        
        public getMarcaCommand(string marca)
        {
            _marca = marca;
        }
        
        public override void Execute()
        {
            Persistence.DAOs.Implementations.MarcaDAO dao = AdministradorDAOFactory.CreateMarcaDAO();
            _result = dao.getMarca(_marca);
        }

        public override List<Guid> GetResult()
        {
            return _result;
        }
    }
}