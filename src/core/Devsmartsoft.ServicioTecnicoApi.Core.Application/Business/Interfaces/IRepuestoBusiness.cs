using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces
{
    public interface IRepuestoBusiness
    {
        Task<ApiResponse<RepuestoDto>> Crear(RepuestoDto entidad);
        Task<ApiResponse<RepuestoDto>> Actualizar(RepuestoDto entidad);
        Task<ApiResponse<bool>> Eliminar(string id);
        Task<ApiResponse<IEnumerable<RepuestoDto>>> ConsultarLista();
    }
}
