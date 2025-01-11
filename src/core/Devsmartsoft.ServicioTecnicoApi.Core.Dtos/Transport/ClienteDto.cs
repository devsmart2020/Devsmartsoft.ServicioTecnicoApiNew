using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Common;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;

public sealed class ClienteDto : BaseDto
{
    public Guid ClienteId { get; set; }

    public string DocId { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string? Apellidos { get; set; }

    public string? Telefono { get; set; }

    public string? TelefonoAlterno { get; set; } = null!;

    public string? Email { get; set; }

    public string? EmailAlterno { get; set; }

    public DateOnly FechaNacimiento { get; set; }

    public string? Pass { get; set; }

    public string? IdDispositivo { get; set; }

    public string? TipoDispositivo { get; set; }

    public string? CodigoUtilidad { get; set; }

    public bool Estado { get; set; }

    public bool AceptaPolitica { get; set; }

    public DateTime? FechaActualizacion { get; set; } 
}
