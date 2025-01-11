using Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces;
using Devsmartsoft.ServicioTecnicoApi.Core.Domain.RepositoryInterfaces;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Implementation
{
    public sealed class ChatBusiness : IChatBusiness
    {
        private readonly IClientGpt _clientGpt;

        public ChatBusiness(IClientGpt clientGpt)
        {
            _clientGpt = clientGpt;
        }

        public IAsyncEnumerable<string> GetGptStream(string question)
        {
            return _clientGpt.SendQuestionStream(question);
        }
    }
}
