using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces
{
    public interface ITipoGastoBusiness
    {
        Task<ApiResponse<TipoGastoDto>> Crear(TipoGastoDto entidad);
        Task<ApiResponse<TipoGastoDto>> Actualizar(TipoGastoDto entidad);
        Task<ApiResponse<bool>> Eliminar(string id);
        Task<ApiResponse<IEnumerable<TipoGastoDto>>> ConsultarLista();
    }
}
