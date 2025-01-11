namespace Devsmartsoft.ServicioTecnicoApi.Core.Domain.Entities;

public partial class ServicioTrazabilidad
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

    public virtual Servicio Servicio { get; set; } = null!;

    public virtual Tecnico? Tecnico { get; set; }
}
