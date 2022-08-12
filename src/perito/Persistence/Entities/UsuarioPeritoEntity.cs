using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace perito.Persistence.Entities
{
    [NotMapped]
    [Table("Usuario_perito")]
    public class UsuarioPeritoEntity:BaseEntity
    {
        [MaxLength(200)] [Required] public string nombres { get; set; }
        [MaxLength(250)] [Required] public string apellidos { get; set; }
        [MaxLength(500)] [Required] public string email { get; set; }
        [MaxLength(20)] [Required] public string contrasena { get; set; }

       // public DireccionEntity direccion { get; set; }
    }
}