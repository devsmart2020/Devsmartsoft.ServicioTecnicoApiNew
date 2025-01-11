namespace Devsmartsoft.ServicioTecnicoApi.Core.Domain.Entities;

public partial class Ubicacion
{
    public int Id { get; set; }

    public Guid ClienteId { get; set; }

    public int Ciudad { get; set; }

    public string Pais { get; set; } = null!;

    public int Region { get; set; }

    public string Direccion { get; set; } = null!;

    public string DireccionCompleta { get; set; } = null!;

    public string? GeoIp { get; set; }

    public string? Observaciones { get; set; }

    public DateTime FechaCreacion { get; set; }

    public Guid? UsuarioCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public bool Estado { get; set; }
   
}
