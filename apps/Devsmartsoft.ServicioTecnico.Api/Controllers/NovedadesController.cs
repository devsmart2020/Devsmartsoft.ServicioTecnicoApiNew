using Devsmartsoft.ServicioTecnico.Api.Controllers.Base;
using Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;
using Microsoft.AspNetCore.Mvc;

namespace Devsmartsoft.ServicioTecnico.Api.Controllers
{
    public sealed class NovedadesController : BaseController
    {
        private readonly INovedadBusiness _novedadBusiness;

        public NovedadesController(INovedadBusiness novedadBusiness)
        {
            _novedadBusiness = novedadBusiness;
        }

        [HttpPost("Crear")]
        public async Task<ApiResponse<NovedadDto>> Crear(NovedadDto request)
        {

            return await _novedadBusiness.Crear(request);
        }

        [HttpPut("Actualizar")]
        public async Task<ApiResponse<NovedadDto>> Actualizar(NovedadDto request)
        {

            return await _novedadBusiness.Actualizar(request);
        }

        [HttpDelete("Eliminar/{id}")]
        public async Task<ApiResponse<bool>> Eliminar(string id)
        {
            return await _novedadBusiness.Eliminar(id);
        }

        [HttpGet("Listar")]
        public async Task<ApiResponse<IEnumerable<NovedadDto>>> Listar()
        {
            return await _novedadBusiness.ConsultarLista();
        }
    }
}
