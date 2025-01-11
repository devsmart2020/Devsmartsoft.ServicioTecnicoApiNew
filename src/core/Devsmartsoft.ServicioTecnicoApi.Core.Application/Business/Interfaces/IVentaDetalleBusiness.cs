using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces
{
    public interface IVentaDetalleBusiness
    {
        Task<ApiResponse<bool>> Crear(IEnumerable<VentaDetalleDto> entidad);
        Task<ApiResponse<VentaDetalleDto>> Actualizar(VentaDetalleDto entidad);
        Task<ApiResponse<bool>> Eliminar(string id);
        Task<ApiResponse<IEnumerable<VentaDetalleDto>>> ConsultarLista(Guid ventaId);
    }
}
