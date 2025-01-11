using Devsmartsoft.ServicioTecnico.Api.Controllers.Base;
using Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces;
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

        [HttpPost("SendQuestion")]
        public async Task<ActionResult<string>> SendQuestion(string question)
        {
            if (string.IsNullOrWhiteSpace(question))
                return BadRequest("La pregunta no puede estar vacía.");

            // Concatenamos todos los "chunks" recibidos de GetGptStream
            var sb = new StringBuilder();

            try
            {
                await foreach (var chunk in _chatBusiness.GetGptStream(question))
                {
                    sb.Append(chunk);
                }
            }
            catch (Exception ex)
            {
                // Opcional: Manejo de excepciones: log, etc.
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  $"Ocurrió un error: {ex.Message}");
            }

            // Devolvemos la respuesta completa
            return Ok(sb.ToString());
        }
    }
}
