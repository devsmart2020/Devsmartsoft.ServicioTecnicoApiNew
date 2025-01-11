using Devsmartsoft.ServicioTecnico.Api.Controllers.Base;
using Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Common;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;
using Microsoft.AspNetCore.Mvc;

namespace Devsmartsoft.ServicioTecnico.Api.Controllers
{
    public sealed class ServiciosController : BaseController
    {
        private readonly IServicioBusiness _servicioBusiness;

        public ServiciosController(IServicioBusiness servicioBusiness)
        {
            _servicioBusiness = servicioBusiness;
        }

        [HttpPost("Crear")]
        public async Task<ApiResponse<ServicioDto>> Crear(ServicioDto request)
        {

            return await _servicioBusiness.Crear(request);
        }

        [HttpPut("Actualizar")]
        public async Task<ApiResponse<ServicioDto>> Actualizar(ServicioDto request)
        {

            return await _servicioBusiness.Actualizar(request);
        }

        [HttpDelete("Eliminar/{id}")]
        public async Task<ApiResponse<bool>> Eliminar(string id)
        {
            return await _servicioBusiness.Eliminar(id);
        }

        [HttpGet("Listar")]
        public async Task<ApiResponse<IEnumerable<ServicioDto>>> Listar()
        {
            return await _servicioBusiness.ConsultarLista();
        }

        [HttpPost("ListarPorFiltro")]
        public async Task<ApiResponse<IEnumerable<ServicioReporteDto>>> ListarPorFiltro(SearchOrderFilterDto filter)
        {
            return await _servicioBusiness.ListarPorFiltro(filter);
        }

        [HttpGet("ObtenerContador")]
        public async Task<ApiResponse<int>> ObtenerContador()
        {
            return await _servicioBusiness.ObtenerCantidadServicios();
        }
    }
}
