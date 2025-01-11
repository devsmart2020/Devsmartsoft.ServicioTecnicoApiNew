using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Common;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;

public partial class EvidenciaDto : BaseDto
{
    public Guid EvidenciaId { get; set; }

    public Guid? ServicioId { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public DateTime Fecha { get; set; }

    public string? Ruta { get; set; }
}
