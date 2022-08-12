using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace perito.Persistence.Entities
{
    [Table("Analisis")]
    public class AnalisisEntity: BaseEntity
    {
        [Required] public Guid id_incidente { get; set; }
        //[NotMapped] public Guid id_carro { get; set; }
        [Required] public Guid id_perito { get; set; }
        
        [Required] public bool culpable { get; set; }
        //[NotMapped] public Guid id_usuario_taller { get; set; }
        public ICollection<PiezaEntity> piezas { get; set; } //Atributo que indica la lista de piezas danadas
    }
}