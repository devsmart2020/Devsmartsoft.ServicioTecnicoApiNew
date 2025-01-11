using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces
{
    public interface IClienteBusiness
    {
        Task<ApiResponse<ClienteDto>> Crear(ClienteDto cliente);
        Task<ApiResponse<ClienteDto>> Actualizar(ClienteDto cliente);
        Task<ApiResponse<bool>> Eliminar(string docId);
        Task<ApiResponse<IEnumerable<ClienteDto>>> ConsultarLista();
        Task<ApiResponse<ClienteDto>> ConsultarPorDocumento(string docId);
        Task<ApiResponse<bool>> ActivarCliente(string docId);
        Task<ApiResponse<string>> GenerarCodigo(string docId);
        Task<ApiResponse<bool>> ValidarCodigo(ClienteDto cliente);
    }
}
