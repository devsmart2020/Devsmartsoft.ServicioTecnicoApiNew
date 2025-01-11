using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces
{
    public interface IEstadoBusiness
    {
        Task<ApiResponse<EstadoDto>> Crear(EstadoDto entidad);
        Task<ApiResponse<EstadoDto>> Actualizar(EstadoDto entidad);
        Task<ApiResponse<bool>> Eliminar(int id);
        Task<ApiResponse<IEnumerable<EstadoDto>>> ConsultarLista();
    }
}
