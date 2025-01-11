using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Common;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;

public sealed class ElementoDto : BaseDto
{
    public Guid ElementoId { get; set; }

    public string Tipo { get; set; } = null!;

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public string? Serial { get; set; }

    public string? Color { get; set; }

    public string? ImagenUrl { get; set; }

    public string? Descripcion { get; set; }

}
