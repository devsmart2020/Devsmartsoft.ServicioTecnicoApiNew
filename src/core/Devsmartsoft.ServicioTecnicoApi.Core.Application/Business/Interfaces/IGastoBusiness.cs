using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces
{
    public interface IGastoBusiness
    {
        Task<ApiResponse<GastoDto>> Crear(GastoDto entidad);
        Task<ApiResponse<GastoDto>> Actualizar(GastoDto entidad);
        Task<ApiResponse<bool>> Eliminar(string id);
        Task<ApiResponse<IEnumerable<GastoDto>>> ConsultarLista();
    }
}
