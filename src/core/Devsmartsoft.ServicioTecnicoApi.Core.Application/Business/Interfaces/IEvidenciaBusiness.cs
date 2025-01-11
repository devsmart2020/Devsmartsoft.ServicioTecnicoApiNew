using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces
{
    public interface IEvidenciaBusiness
    {
        Task<ApiResponse<EvidenciaDto>> Crear(EvidenciaDto entidad);
        Task<ApiResponse<EvidenciaDto>> Actualizar(EvidenciaDto entidad);
        Task<ApiResponse<bool>> Eliminar(string id);
        Task<ApiResponse<IEnumerable<EvidenciaDto>>> ConsultarLista();
    }
}
