using System;
using System.Collections.Generic;
using perito.Persistence.Entities;

namespace perito.BussinesLogic.DTOs
{
    public class AnalisisDTO
    {
        
        public Guid id_incidente { get; set; }
        public Guid id_perito { get; set; }
        
        public bool culpable { get; set; }
        public List<PiezaDTO> piezas { get; set; }
        
    }
}