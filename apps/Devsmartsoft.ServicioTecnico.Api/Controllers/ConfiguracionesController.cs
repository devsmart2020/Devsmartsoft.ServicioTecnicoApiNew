using Devsmartsoft.ServicioTecnico.Api.Controllers.Base;
using Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;
using Microsoft.AspNetCore.Mvc;

namespace Devsmartsoft.ServicioTecnico.Api.Controllers
{
    public sealed class ConfiguracionesController : BaseController
    {
        private readonly IConfiguracionBusiness _configuracionBusiness;

        public ConfiguracionesController(IConfiguracionBusiness configuracionBusiness)
        {
            _configuracionBusiness = configuracionBusiness;
        }

        [HttpPost("Crear")]
        public async Task<ApiResponse<ConfiguracionDto>> Crear(ConfiguracionDto request)
        {

            return await _configuracionBusiness.Crear(request);
        }

        [HttpPut("Actualizar")]
        public async Task<ApiResponse<ConfiguracionDto>> Actualizar(ConfiguracionDto request)
        {

            return await _configuracionBusiness.Actualizar(request);
        }

        [HttpDelete("Eliminar/{id}")]
        public async Task<ApiResponse<bool>> Eliminar(string id)
        {
            return await _configuracionBusiness.Eliminar(id);
        }

        [HttpGet("Listar")]
        public async Task<ApiResponse<IEnumerable<ConfiguracionDto>>> Listar()
        {
            return await _configuracionBusiness.ConsultarLista();
        }
    }
}
