using System;
using System.Collections.Generic;
using administrador.BussinesLogic.DTOs;
using administrador.Persistence.DAOs.Implementations;

namespace administrador.Commands.Atomics.IncidentesDAO
{
    public class getAccidentCommand : Command<List<IncidentesSimpleDTO>>
    {
        private readonly Guid _id;
        private List<IncidentesSimpleDTO> _result;
        
        public getAccidentCommand(Guid id)
        {
            _id = id;
        }
        
        public override void Execute()
        {
            IncidenteDAO dao = AdministradorDAOFactory.CreateIncidenteDAO();
            _result = dao.getAccident(_id);
        }

        public override List<IncidentesSimpleDTO> GetResult()
        {
            return _result;
        }
    }
}