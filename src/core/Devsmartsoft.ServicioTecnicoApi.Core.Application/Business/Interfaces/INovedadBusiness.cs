using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces
{
    public interface INovedadBusiness
    {
        Task<ApiResponse<NovedadDto>> Crear(NovedadDto entidad);
        Task<ApiResponse<NovedadDto>> Actualizar(NovedadDto entidad);
        Task<ApiResponse<bool>> Eliminar(string id);
        Task<ApiResponse<IEnumerable<NovedadDto>>> ConsultarLista();
    }
}
