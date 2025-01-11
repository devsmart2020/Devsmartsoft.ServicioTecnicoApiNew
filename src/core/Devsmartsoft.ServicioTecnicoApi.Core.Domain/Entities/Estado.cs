namespace Devsmartsoft.ServicioTecnicoApi.Core.Domain.Entities;

public partial class Estado
{
    public int EstadoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool FinalizaServicio { get; set; }

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
}
