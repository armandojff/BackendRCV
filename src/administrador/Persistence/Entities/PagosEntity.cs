using System.ComponentModel.DataAnnotations.Schema;

namespace administrador.Persistence.Entities;

public class PagosEntity: BaseEntity
{
    public int costo { get; set; }
    public Guid AnalisisEntityId { get; set; }
    public Guid UserEntityId { get; set; }
    public DateTime fechaInicio { get; set; }
    public DateTime fechaFin { get; set; }
    public string estatus { get; set; }
}