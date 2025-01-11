namespace Devsmartsoft.ServicioTecnicoApi.Core.Domain.Entities;

public partial class Evidencia
{
    public Guid EvidenciaId { get; set; }

    public Guid? ServicioId { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public DateTime Fecha { get; set; }

    public string? Ruta { get; set; }

    public Guid UsuarioCreacion { get; set; }

    public virtual Servicio? Servicio { get; set; }
}
