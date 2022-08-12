using System;
using System.Collections.Generic;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.Persistence;
using RCVUcabBackend.Persistence.DAOs.Implementations;
using RCVUcabBackend.Persistence.DAOs.Interfaces;

namespace RCVUcabBackend.BussinesLogic.Commands.Commands.Atomics

{
    public class GetSolicitudesPorProveedorCommand : Command<ProveedorDTO>
    {
     
            private readonly Guid _proveedor;
            private readonly IProveedorDAO _proveedorDAO;
            private ProveedorDTO _result;
            
            public GetSolicitudesPorProveedorCommand(Guid proveedor)
            {
                _proveedor = proveedor;
            }

            public override void Execute()
            {
                ProveedorDao dao = ProveedorDAOFactory.CreateProviderDB();
                _result = dao.consultarSolicitudesAsignadas(_proveedor);
            }

            public override ProveedorDTO GetResult()
            {
                return _result;
            }
        
    
    }
}