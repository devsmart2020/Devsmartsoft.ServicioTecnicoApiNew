namespace Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport
{
    public sealed class TipoGastoDto
    {
        public Guid TipoGastoId { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }
    }
}
