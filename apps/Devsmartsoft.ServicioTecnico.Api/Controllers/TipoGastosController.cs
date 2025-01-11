using Devsmartsoft.ServicioTecnico.Api.Controllers.Base;
using Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;
using Microsoft.AspNetCore.Mvc;

namespace Devsmartsoft.ServicioTecnico.Api.Controllers
{
    public sealed class TipoGastosController : BaseController
    {
        private readonly ITipoGastoBusiness _tipoGastoBusiness;

        public TipoGastosController(ITipoGastoBusiness tipoGastoBusiness)
        {
            _tipoGastoBusiness = tipoGastoBusiness;
        }

        [HttpPost("Crear")]
        public async Task<ApiResponse<TipoGastoDto>> Crear(TipoGastoDto request)
        {

            return await _tipoGastoBusiness.Crear(request);
        }

        [HttpPut("Actualizar")]
        public async Task<ApiResponse<TipoGastoDto>> Actualizar(TipoGastoDto request)
        {

            return await _tipoGastoBusiness.Actualizar(request);
        }

        [HttpDelete("Eliminar/{id}")]
        public async Task<ApiResponse<bool>> Eliminar(string id)
        {
            return await _tipoGastoBusiness.Eliminar(id);
        }

        [HttpGet("Listar")]
        public async Task<ApiResponse<IEnumerable<TipoGastoDto>>> Listar()
        {
            return await _tipoGastoBusiness.ConsultarLista();
        }
    }
}
