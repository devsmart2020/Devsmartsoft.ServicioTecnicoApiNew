using Devsmartsoft.ServicioTecnicoApi.Core.Domain.RepositoryInterfaces;
using Microsoft.AspNetCore.SignalR;

namespace Devsmartsoft.ServicioTecnicoApi.Infrastructure.Persistence.Hubs
{
    public sealed class ChatHub : Hub
    {
        private readonly IClientGpt _clientGpt;

        public ChatHub(IClientGpt clientGpt)
        {
            _clientGpt = clientGpt;
        }

        public async Task SendQuestion(string question)
        {
            try
            {
                await foreach (var chunk in _clientGpt.SendQuestionStream(question))
                {
                    // Enviamos cada pedacito de texto
                    await Clients.Caller.SendAsync("ReceiveChunk", chunk);
                }
                await Clients.Caller.SendAsync("ReceiveComplete");
            }
            catch (Exception ex)
            {
                await Clients.Caller.SendAsync("ReceiveError", ex.Message);
            }
        }
    }
}
