using backendRCVUcab.Persistence.Entities.ChecksEntitys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendRCVUcab.Persistence.Entities
{

    [NotMapped]

    [Table("OrdenDeCompra")]
    public class OrdenDeCompraEntity : BaseEntity
    {

        [Required]
        public double costo_total { get; set; }
        [Required]
        public int tiempo_de_entrega { get; set; }
        [Required]
        public CotizacionCheck estado { get; set; }
        [Required]
        public DateTime fecha_vencimiento { get; set; }

        [NotMapped]

        public Guid idAnalisis;
        [NotMapped]

        public Guid idUsuarioTaller;
        
        public Guid idUsuarioAdministrador;
     
        public  ICollection<PiezaEntity> piezas { get; set; }


    }
}