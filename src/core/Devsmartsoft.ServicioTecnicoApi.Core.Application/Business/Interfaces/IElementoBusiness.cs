using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces
{
    public interface IElementoBusiness
    {
        Task<ApiResponse<ElementoDto>> Crear(ElementoDto entidad);
        Task<ApiResponse<ElementoDto>> Actualizar(ElementoDto entidad);
        Task<ApiResponse<bool>> Eliminar(string id);
        Task<ApiResponse<IEnumerable<ElementoDto>>> ConsultarLista();
    }
}
