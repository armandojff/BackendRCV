using System.Collections.Generic;
using administrador.BussinesLogic.DTOs;
using administrador.Persistence.Entities;

namespace administrador.Persistence.DAOs.Interfaces
{
    public interface IAseguradoDAO
    {
        public string createInsured(AseguradoEntity insured); // me crea un asegurado
        public List<PAseguradoDTO> getInsured(); // me trae todos los asegurados
        public PAseguradoDTO getInsured(int ci); // me trae un asegurado especifico
    }
}