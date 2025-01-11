using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces
{
    public interface IMovimientoRepuestoBusiness
    {
        Task<ApiResponse<MovimientoRepuestoDto>> Crear(MovimientoRepuestoDto entidad);
        Task<ApiResponse<MovimientoRepuestoDto>> Actualizar(MovimientoRepuestoDto entidad);
        Task<ApiResponse<bool>> Eliminar(string id);
        Task<ApiResponse<IEnumerable<MovimientoRepuestoDto>>> ConsultarLista();
    }
}
