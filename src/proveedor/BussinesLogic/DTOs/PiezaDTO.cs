using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using backendRCVUcab.Persistence.Entities;
using backendRCVUcab.Persistence.Entities.ChecksEntitys;


namespace RCVUcabBackend.BussinesLogic.DTOs
{
    public class PiezaDTO
    {


            public string nombre { get; set; }

            public double costo { get; set; }

            public string tipo { get; set; }
            
            public double descuento { get; set; }
        

            public List<SolicitudDTO> solicitudes { get; set; }
            

        
    }
    
}