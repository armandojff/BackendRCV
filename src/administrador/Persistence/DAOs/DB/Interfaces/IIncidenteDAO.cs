using System;
using System.Collections.Generic;
using administrador.BussinesLogic.DTOs;
using administrador.Persistence.Entities;

namespace administrador.Persistence.DAOs.Interfaces
{
    public interface IIncidenteDAO
    {
        public string createAccident(IncidentesEntity incident);
        /*me trae los incidentes por el ID de la poliza*/
        public List<IncidentesSimpleDTO> getAccident(Guid id);
        public string deleteAccident(Guid id);
    }
}