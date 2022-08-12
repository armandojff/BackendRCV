using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using backendRCVUcab.Persistence.Entities;
using backendRCVUcab.Persistence.Entities.ChecksEntitys;


namespace RCVUcabBackend.BussinesLogic.DTOs
{
    public class SolicitudDTO
    {
        public string nombre { get; set; }
        
        public string estado { get; set; }
        public Guid idAnalisis { get; set; }
        
        public Guid idUsuarioTaller { get; set; }

        public List<ProveedorDTO> proveedores { get; set; }
    
        public List<PiezaDTO> piezas { get; set; }
    }
}