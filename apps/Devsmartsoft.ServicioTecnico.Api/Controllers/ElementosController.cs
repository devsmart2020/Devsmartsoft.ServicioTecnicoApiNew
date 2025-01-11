using Devsmartsoft.ServicioTecnico.Api.Controllers.Base;
using Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;
using Microsoft.AspNetCore.Mvc;

namespace Devsmartsoft.ServicioTecnico.Api.Controllers
{
    public sealed class ElementosController : BaseController
    {
        private readonly IElementoBusiness _elementoBusiness;

        public ElementosController(IElementoBusiness elementoBusiness)
        {
            _elementoBusiness = elementoBusiness;
        }

        [HttpPost("Crear")]
        public async Task<ApiResponse<ElementoDto>> Crear(ElementoDto request)
        {

            return await _elementoBusiness.Crear(request);
        }

        [HttpPut("Actualizar")]
        public async Task<ApiResponse<ElementoDto>> Actualizar(ElementoDto request)
        {

            return await _elementoBusiness.Actualizar(request);
        }

        [HttpDelete("Eliminar/{id}")]
        public async Task<ApiResponse<bool>> Eliminar(string id)
        {
            return await _elementoBusiness.Eliminar(id);
        }

        [HttpGet("Listar")]
        public async Task<ApiResponse<IEnumerable<ElementoDto>>> Listar()
        {
            return await _elementoBusiness.ConsultarLista();
        }
    }
}
