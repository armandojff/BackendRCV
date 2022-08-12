using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace perito.Persistence.Entities
{
    [NotMapped]
    [Table("DireccionEntity")]
    public class DireccionEntity: BaseEntity
    {
            [MaxLength(200)]
            public string calle { get; set; }
            [MaxLength(250)]
            public string municipio { get; set; }
            [MaxLength(250)]
            public string parroquia { get; set; }
            public ICollection<UsuarioPeritoEntity> peritos { get; set; }
        }
    }
