namespace Devsmartsoft.ServicioTecnicoApi.Core.Domain.Entities;

public partial class Elemento
{
    public Guid ElementoId { get; set; }

    public string Tipo { get; set; } = null!;

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public string? Serial { get; set; }

    public string? Color { get; set; }

    public string? ImagenUrl { get; set; }

    public string? Descripcion { get; set; }

    public DateTime FechaCreacion { get; set; }

    public Guid UsuarioCreacion { get; set; }

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
}
