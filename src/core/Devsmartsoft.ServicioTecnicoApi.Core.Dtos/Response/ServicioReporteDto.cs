using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response
{
    public sealed class ServicioReporteDto
    {
        public ServicioDto Servicio { get; set; } = null!;
        public ClienteDto Cliente { get; set; } = null!;
        public ElementoDto Elemento { get; set; } = null!;
        public UbicacionDto Ubicacion { get; set; } = null!;
        public string Tecnico { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string ElementoDetalle { get; set; } = null!;

    }
}
