using System.Collections.Generic;
using administrador.Persistence.Entities;
namespace administrador.BussinesLogic.DTOs
{
    public class AseguradoDTO
    {
        public int ci { get; set; }
        public string primer_n { get; set; }
        public string segundo_n { get; set; }
        public string primer_a { get; set; }
        public string segundo_a { get; set; }
        public char sexo { get; set; }
    }
    
    public class PAseguradoDTO
    {
        public int ci { get; set; }
        public string full_name { get; set; }
        // lista de polizas de un asegurado
        public List<PolizaEntity> policy { get; set; }
    }

}