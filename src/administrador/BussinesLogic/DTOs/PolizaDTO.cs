using System;
namespace administrador.BussinesLogic.DTOs
{
    public class PolizaSimpleDTO
    {
        public string tipo {get; set;}
        public DateTime vencimiento {get; set;}
        public int asegurado {get; set;}
        public String placa {get; set;}
        public int precio {get; set;}
        public int cobertura {get; set;}
    }
    public class PolizaAseguradoDTO
    {
        public string tipo {get; set;}
        public DateTime vencimiento {get; set;}
        public bool estado {get; set;}
        public String placa {get; set;}
    }
}