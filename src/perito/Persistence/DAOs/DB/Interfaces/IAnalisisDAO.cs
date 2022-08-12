using System;
using perito.BussinesLogic.DTOs;
using perito.Persistence.Entities;

namespace perito.Persistence.DAOs.Interfaces
{
    public interface IAnalisisDAO
    {
        public AnalisisDTO CreateAnalisis(AnalisisEntity analisis);
        public string EliminarAnalisis(Guid analisis);
       // public AnalisisDTO ActualizarAnalisis(AnalisisEntity analisis, Guid id_analisis);
    }
}