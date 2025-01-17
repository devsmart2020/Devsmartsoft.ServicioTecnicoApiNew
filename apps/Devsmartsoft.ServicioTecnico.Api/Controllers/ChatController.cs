using Devsmartsoft.ServicioTecnico.Api.Controllers.Base;
using Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Request;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Shared.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Devsmartsoft.ServicioTecnico.Api.Controllers
{
    public sealed class ChatController : BaseController
    {
        private readonly IChatBusiness _chatBusiness;

        public ChatController(IChatBusiness chatBusiness)
        {
            _chatBusiness = chatBusiness;
        }

        [HttpPost("ProcessFileChat")]      
        public async Task<ApiResponse<string>> ProcessFileChat(IFormFile file)
        {
            if (file == null)
            {
                return new ApiResponse<string>
                {
                    NotificationType = NotificationsEnum.Error,
                    Messages = new List<string> { "File is required." }
                };
            }

            ChatFileRequestDto chatFileRequest = new()
            {
                FileStream = file.OpenReadStream(),
                FileName = file.FileName
            };           
            return await _chatBusiness.ProcessFileChat(chatFileRequest);
        }

        [HttpPost("GetResultChat")]
        public async Task<IActionResult> SendQuestion(string question)
        {
            StringBuilder sb = new();
            try
            {
                await foreach (var chunk in _chatBusiness.GetResultChat(question))
                {
                    sb.Append(chunk);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  $"Ocurrió un error: {ex.Message}");
            }
            return Ok(sb.ToString());
        }
    }
}
