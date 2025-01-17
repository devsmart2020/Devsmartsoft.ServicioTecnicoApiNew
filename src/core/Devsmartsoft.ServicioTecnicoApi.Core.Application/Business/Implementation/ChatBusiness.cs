using AutoMapper;
using Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces;
using Devsmartsoft.ServicioTecnicoApi.Core.Domain.RepositoryInterfaces;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Request;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Shared.Enums;
using Devsmartsoft.ServicioTecnicoApi.Shared.Helpers;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Implementation
{
    public sealed class ChatBusiness : BaseBusiness, IChatBusiness
    {
        #region Fields
        private readonly IClientGpt _clientGpt;
        #endregion

        #region Ctor
        public ChatBusiness(IMapper mapper, IClientGpt clientGpt) : base(mapper)
        {
            _clientGpt = clientGpt;
        }
        #endregion

        #region Methods
        public async Task<ApiResponse<string>> ProcessFileChat(ChatFileRequestDto chatFileRequest)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                string fileText = await ConvertFileToText.GetTextFromFileAsync(chatFileRequest.FileStream, chatFileRequest.FileName);
                string extension = chatFileRequest.FileName.EndsWith(".pdf") ? "pdf" : chatFileRequest.FileName.EndsWith(".doc") ?
                          "doc" : chatFileRequest.FileName.EndsWith(".docx") ? "docx" : chatFileRequest.FileName.EndsWith(".xls") ?
                          "xls" : chatFileRequest.FileName.EndsWith(".xlsx") ? "xlsx" : "txt";

                string promptFile = $"El siguiente texto proviene de un archivo adjunto tipo {extension}. Úsalo como contexto: **{fileText}** Pregunta:";
                return CreateApiResponse(promptFile, NotificationsEnum.Success);
            });
        }

        public IAsyncEnumerable<string> GetResultChat(string question)
        {
            return _clientGpt.SendQuestionStream(question);
        }

        #endregion
    }
}
