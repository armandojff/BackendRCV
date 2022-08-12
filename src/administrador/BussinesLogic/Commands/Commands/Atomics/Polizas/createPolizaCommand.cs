using System;
using System.Collections.Generic;
using administrador.BussinesLogic.DTOs;
using administrador.Persistence.DAOs.Implementations;
using administrador.Persistence.Entities;

namespace administrador.Commands.Atomics.PolizasDAO
{
    public class createPolizaCommand : Command<string>
    {
        private readonly PolizaEntity _poliza;
        private string _result;
            
        public createPolizaCommand(PolizaEntity poliza)
        {
            _poliza = poliza;
        }
            
        public override void Execute()
        {
            PolizaDAO dao = AdministradorDAOFactory.CreatePolizaDAO();
            _result = dao.createPoliza(_poliza);
        }

        public override string GetResult()
        {
            return _result;
        }
    }
}