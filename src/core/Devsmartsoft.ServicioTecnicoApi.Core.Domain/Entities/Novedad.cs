namespace Devsmartsoft.ServicioTecnicoApi.Core.Domain.Entities;

public partial class Novedad
{
    public Guid NovedadId { get; set; }

    public Guid ServicioId { get; set; }

    public DateTime Fecha { get; set; }

    public string Descripcion { get; set; } = null!;

    public string? EvidenciasUrl { get; set; }

    public bool ClienteAutoriza { get; set; }

    public DateTime? FechaAprobacion { get; set; }

    public DateTime? FechaRechazo { get; set; }

    public DateTime? FechaCierre { get; set; }

    public string? NotaCliente { get; set; }

    public string? NotaCierre { get; set; }

    public Guid UsuarioCreacion { get; set; }

    public virtual Servicio Servicio { get; set; } = null!;
}
