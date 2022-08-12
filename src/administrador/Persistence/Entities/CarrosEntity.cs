using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace administrador.Persistence.Entities
{
    public class CarrosEntity: BaseEntity2
    {
        [Required]
        public String placa { get; set; }
        [Column(name:"marca")]
        public Guid MarcaEntityId { get; set; }
        public MarcaEntity MarcaEntity { get; set; }
        [Required] 
        public Guid serial { get; set; }
        public DateTime? fabricacion { get; set; } 
        public string? segmento { get; set; }
        public string? color { get; set; }
    }
}