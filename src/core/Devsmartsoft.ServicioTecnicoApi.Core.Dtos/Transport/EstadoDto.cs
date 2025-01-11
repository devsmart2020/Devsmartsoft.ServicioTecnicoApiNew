namespace Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;

public sealed class EstadoDto
{
    public int EstadoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool FinalizaServicio { get; set; }

}
