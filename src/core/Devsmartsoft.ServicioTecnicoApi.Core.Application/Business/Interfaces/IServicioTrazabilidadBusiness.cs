using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces
{
    public interface IServicioTrazabilidadBusiness
    {
        Task<ApiResponse<ServicioTrazabilidadDto>> Crear(ServicioTrazabilidadDto entidad);
        Task<ApiResponse<ServicioTrazabilidadDto>> Actualizar(ServicioTrazabilidadDto entidad);
        Task<ApiResponse<bool>> Eliminar(string id);
        Task<ApiResponse<IEnumerable<ServicioTrazabilidadDto>>> ConsultarLista();
    }
}
