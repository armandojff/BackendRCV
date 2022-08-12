using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace administrador.Persistence.Entities
{
    public class PolizaEntity:BaseEntity
    {
        [Required]
        public string tipo { get; set; }
        [Column(TypeName = "DATE")]
        [Required]
        public DateTime compra { get; set; } 
        [Column(TypeName = "DATE")]
        [Required]
        public DateTime vencimiento { get; set; } 
        public bool desactivada { get; set; }
        public int precio { get; set; }
        public int cobertura { get; set; }
        
        [Column(name:"dni")]
        public int AseguradoEntityId { get; set; }
        public AseguradoEntity AseguradoEntity { get; set; }
        [Column(name:"placa")]
        public String? CarrosEntityId { get; set; }
        public CarrosEntity? CarrosEntity { get; set; }
    }
}