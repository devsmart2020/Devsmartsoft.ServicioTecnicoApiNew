namespace Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport
{
    public sealed class GastoDto
    {
        public Guid GastoId { get; set; }

        public Guid TipoGastoId { get; set; }

        public Guid? ServicioId { get; set; }

        public DateTime Fecha { get; set; }

        public string Nombre { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        public decimal Valor { get; set; }

        public bool PorPagar { get; set; }

        public DateTime? FechaPago { get; set; }

        public string? EvidenciaUrl { get; set; }

        public Guid? UsuarioCreacion { get; set; }
    }
}
