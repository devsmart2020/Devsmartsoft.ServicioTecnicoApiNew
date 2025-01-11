using Devsmartsoft.ServicioTecnico.Api.Controllers.Base;
using Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;
using Microsoft.AspNetCore.Mvc;

namespace Devsmartsoft.ServicioTecnico.Api.Controllers
{
    public sealed class GastosController : BaseController
    {
        private readonly IGastoBusiness _gastoBusiness;

        public GastosController(IGastoBusiness gastoBusiness)
        {
            _gastoBusiness = gastoBusiness;
        }

        [HttpPost("Crear")]
        public async Task<ApiResponse<GastoDto>> Crear(GastoDto request)
        {

            return await _gastoBusiness.Crear(request);
        }

        [HttpPut("Actualizar")]
        public async Task<ApiResponse<GastoDto>> Actualizar(GastoDto request)
        {

            return await _gastoBusiness.Actualizar(request);
        }

        [HttpDelete("Eliminar/{id}")]
        public async Task<ApiResponse<bool>> Eliminar(string id)
        {
            return await _gastoBusiness.Eliminar(id);
        }

        [HttpGet("Listar")]
        public async Task<ApiResponse<IEnumerable<GastoDto>>> Listar()
        {
            return await _gastoBusiness.ConsultarLista();
        }
    }
}
