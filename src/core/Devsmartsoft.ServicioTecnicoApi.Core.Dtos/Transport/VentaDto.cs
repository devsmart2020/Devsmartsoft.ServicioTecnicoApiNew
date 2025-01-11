using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Common;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;

public sealed class VentaDto : BaseDto
{
    public int Id { get; set; }

    public Guid VentaId { get; set; }

    public string ConsecutivoId { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public string CentroServicioNit { get; set; } = null!;

    public string CentroServicioNombre { get; set; } = null!;

    public string CentroServicioCiudad { get; set; } = null!;

    public string CentroServicioDireccion { get; set; } = null!;

    public string? CentroServicioTelefono { get; set; }

    public string? CentroServicioTelefonoAlterno { get; set; }

    public string? CentroServicioEmail { get; set; }

    public string? CentroServicioPaginaWeb { get; set; }

    public string NombreCliente { get; set; } = null!;

    public string? DocIdCliente { get; set; }

    public Guid FormaPagoId { get; set; }

    public bool Cotizacion { get; set; }
}
