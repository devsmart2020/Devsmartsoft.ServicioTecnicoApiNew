namespace Devsmartsoft.ServicioTecnicoApi.Core.Domain.Entities;

public partial class Repuesto
{
    public Guid RepuestoId { get; set; }

    public string Tipo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public string? Consecutivo { get; set; }

    public string? Serial { get; set; }

    public string? CodigoBarras { get; set; }

    public string? Descripcion { get; set; }

    public string? Ubicacion { get; set; }

    public decimal Costo { get; set; }

    public decimal ValorUnitario { get; set; }

    public decimal CantidadStock { get; set; }

    public decimal? AlertaMaximo { get; set; }

    public decimal? AlertaMinimo { get; set; }

    public DateTime FechaIngreso { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public bool Agotado { get; set; }

    public virtual ICollection<MovimientoRepuesto> MovimientoRepuestos { get; set; } = new List<MovimientoRepuesto>();
}
