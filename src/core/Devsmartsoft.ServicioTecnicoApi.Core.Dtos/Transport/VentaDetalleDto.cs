namespace Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;

public sealed class VentaDetalleDto
{
    public Guid VentaId { get; set; }

    public Guid ServicioId { get; set; }

    public int Cantidad { get; set; }

    public decimal Valor { get; set; }

    public string? Descripcion { get; set; }

}
