using Devsmartsoft.ServicioTecnico.Api.Controllers.Base;
using Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;
using Microsoft.AspNetCore.Mvc;

namespace Devsmartsoft.ServicioTecnico.Api.Controllers
{
    public sealed class VentasController : BaseController
    {
        private readonly IVentaBusiness _ventaBusiness;

        public VentasController(IVentaBusiness ventaBusiness)
        {
            _ventaBusiness = ventaBusiness;
        }

        [HttpPost("Crear")]
        public async Task<ApiResponse<VentaDto>> Crear(VentaDto request)
        {

            return await _ventaBusiness.Crear(request);
        }

        [HttpPut("Actualizar")]
        public async Task<ApiResponse<VentaDto>> Actualizar(VentaDto request)
        {

            return await _ventaBusiness.Actualizar(request);
        }

        [HttpDelete("Eliminar/{id}")]
        public async Task<ApiResponse<bool>> Eliminar(string id)
        {
            return await _ventaBusiness.Eliminar(id);
        }

        [HttpGet("Listar")]
        public async Task<ApiResponse<IEnumerable<VentaDto>>> Listar()
        {
            return await _ventaBusiness.ConsultarLista();
        }
    }
}
