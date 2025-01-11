using Devsmartsoft.ServicioTecnicoApi.Core.Domain.RepositoryInterfaces;
using Devsmartsoft.ServicioTecnicoApi.Shared.Constants;
using OpenAI.Chat;
using System.Text;

namespace Devsmartsoft.ServicioTecnicoApi.Infrastructure.Persistence.OpenAI
{
    public sealed class ClientGpt : IClientGpt
    {
        private readonly string _model = ConfigConstants.ModelOpenAI;
        private readonly string _apiKey = ConfigConstants.ApiKeyOpenAI;
        private readonly ChatClient _client;
        private List<ChatMessage> _messages = new();

        public ClientGpt()
        {
            _client = new ChatClient(_model, _apiKey);
        }

        public async IAsyncEnumerable<string> SendQuestionStream(string question)
        {
            _messages.Add(new UserChatMessage(question));
            StringBuilder sb = new StringBuilder();
            System.ClientModel.CollectionResult<StreamingChatCompletionUpdate> stream;
            try
            {
                stream = _client.CompleteChatStreaming(_messages);
            }
            catch (Exception)
            {
                yield break;
            }

            foreach (StreamingChatCompletionUpdate update in stream)
            {
                // Cada 'update' puede traer múltiples trozos (chunks)
                foreach (ChatMessageContentPart? content in update.ContentUpdate)
                {
                    string chunk = content.Text;
                    sb.Append(chunk);
                    yield return chunk;
                }
            }

            if (sb.Length > 0)
            {
                _messages.Add(new AssistantChatMessage(sb.ToString()));
            }

            // 7. (Opcional) Aquí podrías "yield return" un token indicando fin, 
            //    o simplemente terminar el método.
        }
    }
}
