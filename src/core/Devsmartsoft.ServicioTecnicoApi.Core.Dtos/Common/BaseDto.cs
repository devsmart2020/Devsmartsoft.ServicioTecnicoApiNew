namespace Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Common
{
    public abstract class BaseDto
    {
        public DateTime? FechaCreacion { get; set; }

        public Guid? UsuarioCreacion { get; set; }

        protected BaseDto()
        {
            FechaCreacion = DateTime.UtcNow;
        }
    }
}
