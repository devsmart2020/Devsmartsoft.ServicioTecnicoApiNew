using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Common;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces
{
    public interface IServicioBusiness
    {
        Task<ApiResponse<ServicioDto>> Crear(ServicioDto entidad);
        Task<ApiResponse<ServicioDto>> Actualizar(ServicioDto entidad);
        Task<ApiResponse<bool>> Eliminar(string id);
        Task<ApiResponse<IEnumerable<ServicioDto>>> ConsultarLista();
        Task<ApiResponse<IEnumerable<ServicioReporteDto>>> ListarPorFiltro(SearchOrderFilterDto filter);
        Task<ApiResponse<int>> ObtenerCantidadServicios();
    }
}
