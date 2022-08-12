using System;
using perito.BussinesLogic.DTOs;
using perito.Persistence.Entities;

namespace perito.Persistence.DAOs.Interfaces
{
    public interface IPiezaDAO
    {
        public PiezaDTO CreatePieza(PiezaEntity pieza);
        public string EliminarPieza(Guid  pieza);
        public PiezaDTO ActualizarPieza(PiezaEntity pieza, Guid id_pieza);
    }
}