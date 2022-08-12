using System;
using System.Collections.Generic;
using RCVUcabBackend.BussinesLogic.DTOs;

namespace RCVUcabBackend.Persistence.DAOs.Interfaces
{
    public interface IProveedorDAO
    {
        public ProveedorDTO CreateProveedor(ProveedorDTO proveedor);
        
        public ProveedorDTO  consultarSolicitudesAsignadas(Guid id_proveedor);
    }
}