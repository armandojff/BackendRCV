using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendRCVUcab.Persistence.Entities
{

    [NotMapped]

    [Table("Marca")]
    public class MarcaEntity : BaseEntity
    {

        [MaxLength(100)][Required] public string nombre { get; set; }
        
     
        public ICollection<ProveedorEntity> proveedores { get; set; }

    }
}