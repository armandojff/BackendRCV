using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace administrador.Persistence.Entities
{
    public class IncidentesEntity:BaseEntity
    {
        [Required]
        public string descripcion { get; set; }
        public string ubicacion { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime fecha { get; set; }
        [Column(name:"poliza")]
        public Guid PolizaEntityId { get; set; }
    }
}