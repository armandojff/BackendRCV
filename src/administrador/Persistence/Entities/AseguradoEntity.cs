using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace administrador.Persistence.Entities
{
    public class AseguradoEntity:BaseEntity2
    {
        [Required]
        public int ci { get; set; }
        public string primer_n { get; set; }
        public string segundo_n { get; set; }
        public string primer_a { get; set; }
        public string segundo_a { get; set; }
        public char sexo { get; set; }
        
        public List<PolizaEntity>? polizas { get; set; }
    }
}