using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Common;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;

public sealed class ConfiguracionDto : BaseDto
{
    public Guid ConfiguracionId { get; set; }

    public string? RutaFirebase { get; set; }

    public string? RutaSeguridad { get; set; }

    public string? RutaArchivosLocal { get; set; }

    public string? GoogleServices { get; set; }
}
