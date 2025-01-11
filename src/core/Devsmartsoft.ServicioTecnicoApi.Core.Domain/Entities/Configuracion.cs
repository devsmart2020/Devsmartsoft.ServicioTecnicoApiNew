namespace Devsmartsoft.ServicioTecnicoApi.Core.Domain.Entities;

public partial class Configuracion
{
    public Guid ConfiguracionId { get; set; }

    public string? RutaFirebase { get; set; }

    public string? RutaSeguridad { get; set; }

    public string? RutaArchivosLocal { get; set; }

    public string? GoogleServices { get; set; }
}
