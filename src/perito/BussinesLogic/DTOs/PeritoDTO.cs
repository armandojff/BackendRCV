using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using perito.Persistence.Entities;
namespace perito.BussinesLogic.DTOs
{
    public class PeritoDTO
    {
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string email { get; set; }
        public string contrasena { get; set; }
        
        public DireccionEntity direccion { get; set; }

    };
}