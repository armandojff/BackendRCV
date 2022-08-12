using System;
using System.Collections.Generic;
using backendRCVUcab.Persistence.Entities;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.Persistence;
using RCVUcabBackend.Persistence.DAOs.Implementations;
using RCVUcabBackend.Persistence.DAOs.Interfaces;

namespace RCVUcabBackend.BussinesLogic.Commands.Commands.Atomics
{
    public class CreateProveedorCommand : Command<ProveedorDTO>
    {
  
        private readonly ProveedorDTO _proveedor;
        private readonly IProveedorDAO _proveedorDAO;
        private ProveedorDTO _result;
            
        public CreateProveedorCommand(ProveedorDTO proveedor)
        {
            _proveedor = proveedor;
        }

        public override void Execute()
        {
            ProveedorDao dao = ProveedorDAOFactory.CreateProviderDB();
            _result = dao.CreateProveedor(_proveedor);
        }

        public override ProveedorDTO GetResult()
        {
            return _result;
        }
        
    }
}