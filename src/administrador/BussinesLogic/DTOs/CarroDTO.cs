using System;
namespace administrador.BussinesLogic.DTOs
{
    public class CarroDTO
    {
        public string placa { get; set; }
        public String marca { get; set; }
        public Guid serial { get; set; }
        public DateTime fabricacion { get; set; } 
        public string segmento { get; set; }
        public string color { get; set; }
    }
}