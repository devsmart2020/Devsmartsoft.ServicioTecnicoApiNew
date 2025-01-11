using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Common;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;

public sealed class NovedadDto : BaseDto
{
    public Guid NovedadId { get; set; }

    public Guid ServicioId { get; set; }

    public DateTime Fecha { get; set; }

    public string Descripcion { get; set; } = null!;

    public string? EvidenciasUrl { get; set; }

    public bool ClienteAutoriza { get; set; }

    public DateTime? FechaAprobacion { get; set; }

    public DateTime? FechaRechazo { get; set; }

    public DateTime? FechaCierre { get; set; }

    public string? NotaCliente { get; set; }

    public string? NotaCierre { get; set; }

}
