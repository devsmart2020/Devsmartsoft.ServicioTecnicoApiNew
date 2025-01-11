using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Common;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;

public sealed class FormaPagoDto : BaseDto
{
    public Guid FormaPagoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }
}
