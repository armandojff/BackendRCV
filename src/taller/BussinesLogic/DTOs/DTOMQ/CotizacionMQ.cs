using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using RCVUcabBackend.Persistence.Entities.ChecksEntitys;

namespace RCVUcabBackend.BussinesLogic.DTOs.DTOMQ
{
    public class CotizacionMQ
    {
    public Guid idAnalisis { get; set; }
    public Guid idTaller{ get; set; }

    public string fecha_inicio{get;set;}
    public string fecha_culminacion{get;set;}
    public int costo_reparacion { get; set; }
    }
}