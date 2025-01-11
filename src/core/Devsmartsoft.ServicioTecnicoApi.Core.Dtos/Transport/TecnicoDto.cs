using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Common;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;

public sealed class TecnicoDto : BaseDto
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

    public DateTime? FechaActualizacion { get; set; }

}
