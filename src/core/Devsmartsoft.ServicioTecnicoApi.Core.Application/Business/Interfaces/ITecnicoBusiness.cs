using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces
{
    public interface ITecnicoBusiness
    {
        Task<ApiResponse<TecnicoDto>> Crear(TecnicoDto entidad);
        Task<ApiResponse<TecnicoDto>> Actualizar(TecnicoDto entidad);
        Task<ApiResponse<bool>> Eliminar(string docId);
        Task<ApiResponse<IEnumerable<TecnicoDto>>> ConsultarLista();
        Task<ApiResponse<TecnicoDto>> ConsultarPorDocumento(string docId);
        Task<ApiResponse<bool>> Activar(string docId);
        Task<ApiResponse<bool>> Desactivar(string docId);
        Task<ApiResponse<string>> GenerarCodigo(string docId);
        Task<ApiResponse<bool>> ValidarCodigo(TecnicoDto entidad);
    }
}
