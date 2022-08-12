using System;
using System.Collections.Generic;
using RCVUcabBackend.Persistence.Entities.ChecksEntitys;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
namespace RCVUcabBackend.Persistence.DAOs.Interfaces{
    public interface ITelefono
    {
        public bool crearTelefonosDeLista(ICollection<TelefonoEntity> listaTelefonos);
        
    }
}