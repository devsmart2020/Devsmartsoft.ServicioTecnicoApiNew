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

        public ClientGpt()
        {
            _client = new ChatClient(_model, _apiKey);
        }

        public async IAsyncEnumerable<string> SendQuestionStream(string question)
        {
            StringBuilder sb = new();
            System.ClientModel.CollectionResult<StreamingChatCompletionUpdate> stream;
            try
            {
                stream = _client.CompleteChatStreaming(question);
            }
            catch (Exception)
            {
                yield break;
            }

            foreach (StreamingChatCompletionUpdate update in stream)
            {
                foreach (ChatMessageContentPart? content in update.ContentUpdate)
                {
                    string chunk = content.Text;
                    sb.Append(chunk);
                    yield return chunk;
                }
            }

            if (sb.Length > 0)
            {
                sb.AppendLine(sb.ToString());
            }
        }
    }
}
