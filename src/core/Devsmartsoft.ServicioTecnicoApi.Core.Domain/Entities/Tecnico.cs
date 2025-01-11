namespace Devsmartsoft.ServicioTecnicoApi.Core.Domain.Entities;

public partial class Tecnico
{
    public Guid TecnicoId { get; set; }

    public string DocId { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string CentroServicio { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public string Usuario { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public string? IdDispositivo { get; set; }

    public string? TipoDispositivo { get; set; }

    public string? CodigoUtilidad { get; set; }

    public bool Estado { get; set; }

    public DateTime FechaCreacion { get; set; }

    public Guid? UsuarioCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual ICollection<ServicioTrazabilidad> ServicioTrazabilidads { get; set; } = new List<ServicioTrazabilidad>();
    public virtual ICollection<Servicio> Servicios { get; set; }
}
