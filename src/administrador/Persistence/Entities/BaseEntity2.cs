using System;
namespace administrador.Persistence.Entities
{
    public class BaseEntity2
    {
        /*Para esta entidad base no necesito la ID*/
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
    }
}