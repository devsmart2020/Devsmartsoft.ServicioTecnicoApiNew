using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Request;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces
{
    public interface IChatBusiness
    {
        Task<ApiResponse<string>> ProcessFileChat(ChatFileRequestDto chatFileRequest);
        IAsyncEnumerable<string> GetResultChat(string question);           

    }
}
