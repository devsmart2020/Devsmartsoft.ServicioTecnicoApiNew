using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Common;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;

public sealed class ServicioDto : BaseDto
{
    public Guid ServicioId { get; set; }

    public string? ConsecutivoServicio { get; set; }

    public Guid ClienteId { get; set; }

    public Guid? TecnicoId { get; set; }

    public int EstadoId { get; set; }

    public Guid ElementoId { get; set; }

    public Guid? EvidenciaId { get; set; }

    public DateTime FechaIngreso { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public DateTime? FechaEntrega { get; set; }

    public int PorcentajeAvance { get; set; }

    public decimal? ValorPagar { get; set; }

    public decimal? ValorAbono { get; set; }

    public DateTime? FechaAbono { get; set; }

    public string? QrCode { get; set; }

    public string? Descripcion { get; set; }

    public string? DescripcionReparacion { get; set; }

    public string? EvidenciaReparacionUrl { get; set; }

    public bool? Finalizada { get; set; }

    public string? NotaTecnico { get; set; }

}
