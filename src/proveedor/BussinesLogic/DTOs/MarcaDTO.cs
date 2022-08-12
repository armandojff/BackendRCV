using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using backendRCVUcab.Persistence.Entities;
using backendRCVUcab.Persistence.Entities.ChecksEntitys;
    
namespace RCVUcabBackend.BussinesLogic.DTOs
    
{
    public class MarcaDTO
    {
        public string nombre { get; set; }
       
       List<ProveedorDTO> proveedores { get; set; }
    }
}