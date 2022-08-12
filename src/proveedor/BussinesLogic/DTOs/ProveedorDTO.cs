using System.Collections.Generic;
using backendRCVUcab.Persistence.Entities;

namespace RCVUcabBackend.BussinesLogic.DTOs
{
    public class ProveedorDTO
    {
       public string nombre { get; set; }
       public string direccion { get; set; } 
       public string telefono { get; set; } 
       public Tipo_Proveedor tipoProveedor { get; set; } 
       public List<MarcaDTO> marcas { get; set; }
       
       public List<SolicitudDTO> solicitudes { get; set; }
    }
}