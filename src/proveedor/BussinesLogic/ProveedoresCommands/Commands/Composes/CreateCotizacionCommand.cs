using System;
using System.Collections.Generic;
using backendRCVUcab.Persistence.Entities;
using RCVUcabBackend.BussinesLogic.Commands.Commands.Atomics;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.Persistence;
using RCVUcabBackend.Persistence.DAOs.Implementations;
using RCVUcabBackend.Persistence.DAOs.Interfaces;

namespace RCVUcabBackend.BussinesLogic.Commands.Commands.Composes

{
    public class CreateCotizacionCommand : Command<CotizacionDTO>
    {
     
        private readonly CotizacionDTO _cotizacion;
        private CotizacionDTO _result;
            
        public CreateCotizacionCommand(CotizacionDTO cotizacion)
        {
            _cotizacion = cotizacion;
        }

        public override void Execute()
        {
            InsertCotizacionCommand command = CommandFactory.createInsertCotizacionCommand(_cotizacion);
            command.Execute();
            _result = command.GetResult();
            SendCotizacionToAdminCommand commanSend = CommandFactory.createSendCotizacionToAdminCommand(_result);

        }

        public override CotizacionDTO GetResult()
        {
            return _result;
        }
        
    
    }
}