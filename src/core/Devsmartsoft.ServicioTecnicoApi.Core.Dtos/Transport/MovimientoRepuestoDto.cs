namespace Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport
{
    public sealed class MovimientoRepuestoDto
    {
        public int MovimientoId { get; set; }

        public Guid ServicioId { get; set; }

        public Guid RepuestoId { get; set; }

        public decimal CostoRepuesto { get; set; }

        public decimal ValorUnitarioRepuesto { get; set; }

        public decimal Cantidad { get; set; }

        public DateTime Fecha { get; set; }

        public Guid UsuarioCreacion { get; set; }

        public bool MovimientoConfirmado { get; set; }
    }
}
