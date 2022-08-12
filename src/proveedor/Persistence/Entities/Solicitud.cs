using backendRCVUcab.Persistence.Entities.ChecksEntitys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendRCVUcab.Persistence.Entities
{

    [NotMapped]

    [Table("Solicitud")]
    public class SolicitudEntity : BaseEntity
    {

        [MaxLength(100)][Required] public string nombre { get; set; }
        [Required] public SolicitudCheck estado { get; set; }

        [Required] public Guid idAnalisis;

        [Required] public Guid idUsuarioTaller;
        
        public ICollection<ProveedorEntity> proveedores { get; set; }

        public ICollection<PiezaEntity> piezas { get; set; }

    }
}