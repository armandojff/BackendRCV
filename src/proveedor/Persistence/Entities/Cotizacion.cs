using backendRCVUcab.Persistence.Entities.ChecksEntitys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendRCVUcab.Persistence.Entities
{

    [NotMapped]

    [Table("Cotizacion")]
    public class CotizacionEntity : BaseEntity
    {
 
        [Required]
        public double costo_total { get; set; }
        [Required]
        public int tiempo_de_entrega { get; set; }
        
        [NotMapped]

        public Guid idAnalisis;
        [NotMapped]

        public Guid idUsuarioTaller;
        [NotMapped]

        [Required] public Guid idProveedor;
      
        public List<PiezaEntity> piezas { get; set; }


    }
}