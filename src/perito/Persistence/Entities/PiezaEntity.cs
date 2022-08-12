using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace perito.Persistence.Entities
{
    [Table("Pieza")]
    public class PiezaEntity: BaseEntity
    {
        [MaxLength(100)] [Required] public string nombre { get; set; }
    }
}