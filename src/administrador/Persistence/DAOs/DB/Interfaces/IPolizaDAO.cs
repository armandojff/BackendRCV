using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using administrador.BussinesLogic.DTOs;
using administrador.Persistence.Entities;

namespace administrador.Persistence.DAOs.Interfaces
{
    public interface IPolizaDAO
    {
        public string createPoliza(PolizaEntity poliza);
        public Task<bool> deletePolicy(Guid poliza);
        public List<PolizaAseguradoDTO> getPolicyInsured(int ci);
    }
}