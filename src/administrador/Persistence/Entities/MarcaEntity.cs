using System;
using System.ComponentModel.DataAnnotations;
namespace administrador.Persistence.Entities
{
    public class MarcaEntity: BaseEntity
    {
        public String marca { get; set; }
        public String? categoria { get; set; }
    }
}