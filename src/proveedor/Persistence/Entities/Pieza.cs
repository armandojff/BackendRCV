using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendRCVUcab.Persistence.Entities
{

    [NotMapped]

    [Table("Pieza")]
    public class PiezaEntity : BaseEntity
    {

        [MaxLength(100)][Required] public string nombre { get; set; }

        [MaxLength(100)] public double costo { get; set; }

        [MaxLength(100)] public string tipo { get; set; }
        
    
        public ICollection<SolicitudEntity> solicitudes { get; set; }
        
        public ICollection<OrdenDeCompraEntity> ordenes { get; set; }
        
        
        public  ICollection<CotizacionEntity> cotizaciones { get; set; }

    }
}