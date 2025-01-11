using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces
{
    public interface IFormaPagoBusiness
    {
        Task<ApiResponse<FormaPagoDto>> Crear(FormaPagoDto entidad);
        Task<ApiResponse<FormaPagoDto>> Actualizar(FormaPagoDto entidad);
        Task<ApiResponse<bool>> Eliminar(string id);
        Task<ApiResponse<IEnumerable<FormaPagoDto>>> ConsultarLista();
    }
}
