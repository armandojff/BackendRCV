using System;
using perito.BussinesLogic.DTOs;
using perito.Persistence.DAOs.Implementations;
using perito.Persistence.Entities;

namespace perito.Persistence.DAOs.Interfaces
{
    public interface IPeritoDAO
    {
        public PeritoDTO CreatePerito(UsuarioPeritoEntity perito);
        
        public string EliminarPerito(Guid perito);
        public PeritoDTO ActualizarPerito(UsuarioPeritoEntity perito, Guid id_perito);
    }
}