using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces
{
    public interface IVentaBusiness
    {
        Task<ApiResponse<VentaDto>> Crear(VentaDto entidad);
        Task<ApiResponse<VentaDto>> Actualizar(VentaDto entidad);
        Task<ApiResponse<bool>> Eliminar(string id);
        Task<ApiResponse<IEnumerable<VentaDto>>> ConsultarLista();
    }
}
