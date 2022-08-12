using System;
using System.Collections.Generic;
using backendRCVUcab.Persistence.Entities;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.Persistence;
using RCVUcabBackend.Persistence.DAOs.Implementations;
using RCVUcabBackend.Persistence.DAOs.Interfaces;

namespace RCVUcabBackend.BussinesLogic.Commands.Commands.Atomics
{
    public class InsertCotizacionCommand : Command<CotizacionDTO>
    {
  
        private readonly CotizacionDTO _cotizacion;
        private CotizacionDTO _result;
            
        public InsertCotizacionCommand(CotizacionDTO cotizacion)
        {
            _cotizacion = cotizacion;
        }

        public override void Execute()
        {
            CotizacionDao dao = ProveedorDAOFactory.CreateCotizacionDB();
            _result = dao.createCotizacion(_cotizacion);
        }

        public override CotizacionDTO GetResult()
        {
            return _result;
        }
        
    }
}