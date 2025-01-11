namespace Devsmartsoft.ServicioTecnicoApi.Core.Domain.Entities;

public partial class Servicio
{
    public Guid ServicioId { get; set; }

    public string ConsecutivoServicio { get; set; } = null!;

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

    public Guid UsuarioCreacion { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Elemento Elemento { get; set; } = null!;

    public virtual Estado Estado { get; set; } = null!;

    public virtual Tecnico Tecnico { get; set; } = null!;

    public virtual ICollection<Evidencia> Evidencia { get; set; } = new List<Evidencia>();

    public virtual ICollection<MovimientoRepuesto> MovimientoRepuestos { get; set; } = new List<MovimientoRepuesto>();

    public virtual ICollection<Novedad> Novedads { get; set; } = new List<Novedad>();

    public virtual ICollection<ServicioTrazabilidad> ServicioTrazabilidads { get; set; } = new List<ServicioTrazabilidad>();

    public virtual ICollection<VentaDetalle> VentaDetalles { get; set; } = new List<VentaDetalle>();
}
