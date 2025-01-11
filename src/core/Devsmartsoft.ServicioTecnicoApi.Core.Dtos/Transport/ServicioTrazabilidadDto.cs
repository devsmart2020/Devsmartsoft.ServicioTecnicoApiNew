using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Common;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;

public sealed class ServicioTrazabilidadDto : BaseDto
{
    public Guid TrazabilidadId { get; set; }

    public Guid ServicioId { get; set; }

    public Guid? TecnicoId { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public DateTime? FechaEntrega { get; set; }

    public int? PorcentajeAvance { get; set; }

    public decimal? ValorPagar { get; set; }

    public decimal? ValorAbono { get; set; }

    public DateTime? FechaAbono { get; set; }

    public string? DescripcionReparacion { get; set; }

    public bool Finalizado { get; set; }
}
