namespace administrador.BussinesLogic.DTOs;

public class PagosDTO
{
    public string lt;
    public Guid idAnalisis {get; set;}
    public Guid idTaller {get; set;}
    public string fecha_inicio {get; set;}
    public string fecha_culminacion {get; set;}
    public int costo_reparacion {get; set;}
}