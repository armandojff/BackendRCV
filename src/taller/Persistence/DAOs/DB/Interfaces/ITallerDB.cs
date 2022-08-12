using System;
using System.Collections.Generic;
using RCVUcabBackend.Persistence.Entities.ChecksEntitys;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
namespace RCVUcabBackend.Persistence.DAOs.Interfaces
{
    public interface ITallerDB
    {
        public TallerDTO crearTaller(TallererEntity taller);
        public string EliminarTaller(Guid id_taller);
        public TallerDTO ActualizarTaller(TallererEntity tallerCambios,Guid id_taller);
    }
}