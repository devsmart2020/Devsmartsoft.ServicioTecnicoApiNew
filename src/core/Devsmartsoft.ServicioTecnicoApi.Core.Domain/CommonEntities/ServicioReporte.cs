using Devsmartsoft.ServicioTecnicoApi.Core.Domain.Entities;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Domain.CommonEntities
{
    public sealed class ServicioReporte
    {
        public Servicio Servicio { get; set; } = null!;
        public Cliente Cliente { get; set; } = null!;
        public Elemento Elemento { get; set; } = null!;
        public Ubicacion Ubicacion { get; set; } = null!;
        public string Tecnico { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string ElementoDetalle { get; set; } = null!;
        
    }
}
