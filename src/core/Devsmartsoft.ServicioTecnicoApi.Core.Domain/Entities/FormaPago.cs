namespace Devsmartsoft.ServicioTecnicoApi.Core.Domain.Entities;

public partial class FormaPago
{
    public Guid FormaPagoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
