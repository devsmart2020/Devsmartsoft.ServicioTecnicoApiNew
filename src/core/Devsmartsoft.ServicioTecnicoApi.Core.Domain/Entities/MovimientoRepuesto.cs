namespace Devsmartsoft.ServicioTecnicoApi.Core.Domain.Entities;

public partial class MovimientoRepuesto
{
    public int MovimientoId { get; set; }

    public Guid ServicioId { get; set; }

    public Guid RepuestoId { get; set; }

    public decimal CostoRepuesto { get; set; }

    public decimal ValorUnitarioRepuesto { get; set; }

    public decimal Cantidad { get; set; }

    public DateTime Fecha { get; set; }

    public Guid UsuarioCreacion { get; set; }

    public bool MovimientoConfirmado { get; set; }

    public virtual Repuesto Repuesto { get; set; } = null!;

    public virtual Servicio Servicio { get; set; } = null!;
}
