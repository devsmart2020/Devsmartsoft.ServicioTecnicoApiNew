using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces
{
    public interface IUbicacionBusiness
    {
        Task<ApiResponse<UbicacionDto>> Crear(UbicacionDto entidad);
        Task<ApiResponse<UbicacionDto>> Actualizar(UbicacionDto entidad);
        Task<ApiResponse<bool>> Eliminar(string id);
        Task<ApiResponse<IEnumerable<UbicacionDto>>> ConsultarLista();
        Task<ApiResponse<IEnumerable<UbicacionDto>>> ObtenerPorCliente(Guid id);
    }
}
