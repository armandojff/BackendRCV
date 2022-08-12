using System;
namespace administrador.BussinesLogic.DTOs
{
    public class IncidentesDTO
    {
        public DateTime fecha {get; set;}
            public String ubicacion {get; set;}
            public String descripcion { get; set;}
            public Guid PolizaEntityId {get; set;}
    }
    
    public class IncidentesSimpleDTO
    {
        public DateTime fecha {get; set;}
        public String ubicacion {get; set;}
        public String descripcion { get; set;}
    }
}