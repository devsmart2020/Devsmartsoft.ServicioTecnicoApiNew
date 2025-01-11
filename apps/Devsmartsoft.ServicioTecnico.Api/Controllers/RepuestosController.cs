using Devsmartsoft.ServicioTecnico.Api.Controllers.Base;
using Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;
using Microsoft.AspNetCore.Mvc;

namespace Devsmartsoft.ServicioTecnico.Api.Controllers
{
    public sealed class RepuestosController : BaseController
    {
        private readonly IRepuestoBusiness _repuestoBusiness;

        public RepuestosController(IRepuestoBusiness repuestoBusiness)
        {
            _repuestoBusiness = repuestoBusiness;
        }

        [HttpPost("Crear")]
        public async Task<ApiResponse<RepuestoDto>> Crear(RepuestoDto request)
        {

            return await _repuestoBusiness.Crear(request);
        }

        [HttpPut("Actualizar")]
        public async Task<ApiResponse<RepuestoDto>> Actualizar(RepuestoDto request)
        {

            return await _repuestoBusiness.Actualizar(request);
        }

        [HttpDelete("Eliminar/{id}")]
        public async Task<ApiResponse<bool>> Eliminar(string id)
        {
            return await _repuestoBusiness.Eliminar(id);
        }

        [HttpGet("Listar")]
        public async Task<ApiResponse<IEnumerable<RepuestoDto>>> Listar()
        {
            return await _repuestoBusiness.ConsultarLista();
        }
    }
}
