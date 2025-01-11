using Devsmartsoft.ServicioTecnico.Api.Controllers.Base;
using Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;
using Microsoft.AspNetCore.Mvc;

namespace Devsmartsoft.ServicioTecnico.Api.Controllers
{
    public sealed class EvidenciasController : BaseController
    {
        private readonly IEvidenciaBusiness _evidenciaBusiness;

        public EvidenciasController(IEvidenciaBusiness evidenciaBusiness)
        {
            _evidenciaBusiness = evidenciaBusiness;
        }

        [HttpPost("Crear")]
        public async Task<ApiResponse<EvidenciaDto>> Crear(EvidenciaDto request)
        {

            return await _evidenciaBusiness.Crear(request);
        }

        [HttpPut("Actualizar")]
        public async Task<ApiResponse<EvidenciaDto>> Actualizar(EvidenciaDto request)
        {

            return await _evidenciaBusiness.Actualizar(request);
        }

        [HttpDelete("Eliminar/{id}")]
        public async Task<ApiResponse<bool>> Eliminar(string id)
        {
            return await _evidenciaBusiness.Eliminar(id);
        }

        [HttpGet("Listar")]
        public async Task<ApiResponse<IEnumerable<EvidenciaDto>>> Listar()
        {
            return await _evidenciaBusiness.ConsultarLista();
        }
    }
}
