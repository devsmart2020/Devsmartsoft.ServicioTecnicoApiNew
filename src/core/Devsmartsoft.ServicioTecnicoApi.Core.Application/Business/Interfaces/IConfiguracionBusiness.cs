using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces
{
    public interface IConfiguracionBusiness
    {
        Task<ApiResponse<ConfiguracionDto>> Crear(ConfiguracionDto entidad);
        Task<ApiResponse<ConfiguracionDto>> Actualizar(ConfiguracionDto entidad);
        Task<ApiResponse<bool>> Eliminar(string id);
        Task<ApiResponse<IEnumerable<ConfiguracionDto>>> ConsultarLista();
    }
}
