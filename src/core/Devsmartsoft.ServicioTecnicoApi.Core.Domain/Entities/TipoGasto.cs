namespace Devsmartsoft.ServicioTecnicoApi.Core.Domain.Entities;

public partial class TipoGasto
{
    public Guid TipoGastoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Gasto> Gastos { get; set; } = new List<Gasto>();
}
