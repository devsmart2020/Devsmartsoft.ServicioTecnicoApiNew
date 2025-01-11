using Devsmartsoft.ServicioTecnico.Api.Controllers.Base;
using Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;
using Microsoft.AspNetCore.Mvc;

namespace Devsmartsoft.ServicioTecnico.Api.Controllers
{
    public sealed class FormaPagosController : BaseController
    {
        private readonly IFormaPagoBusiness _formaPagoBusiness;

        public FormaPagosController(IFormaPagoBusiness formaPagoBusiness)
        {
            _formaPagoBusiness = formaPagoBusiness;
        }

        [HttpPost("Crear")]
        public async Task<ApiResponse<FormaPagoDto>> Crear(FormaPagoDto request)
        {

            return await _formaPagoBusiness.Crear(request);
        }

        [HttpPut("Actualizar")]
        public async Task<ApiResponse<FormaPagoDto>> Actualizar(FormaPagoDto request)
        {

            return await _formaPagoBusiness.Actualizar(request);
        }

        [HttpDelete("Eliminar/{id}")]
        public async Task<ApiResponse<bool>> Eliminar(string id)
        {
            return await _formaPagoBusiness.Eliminar(id);
        }

        [HttpGet("Listar")]
        public async Task<ApiResponse<IEnumerable<FormaPagoDto>>> Listar()
        {
            return await _formaPagoBusiness.ConsultarLista();
        }
    }
}
