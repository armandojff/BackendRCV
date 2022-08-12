using System;
using System.Collections.Generic;

namespace RCVUcabBackend.BussinesLogic.DTOs
{
    public class CotizacionDTO
    {
        public int tiempo_de_entrega { get; set; }
        
        public double costo_total { get; set; }
        
        public Guid idSolicitud { get; set; }
        
        public Guid idUsuarioTaller { get; set; }
        
        public Guid idProvedor { get; set; }

        public List<PiezaDTO> piezas { get; set; }
    }
}