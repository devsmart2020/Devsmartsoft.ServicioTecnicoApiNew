using Devsmartsoft.ServicioTecnico.Api.Controllers.Base;
using Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;
using Microsoft.AspNetCore.Mvc;

namespace Devsmartsoft.ServicioTecnico.Api.Controllers
{
    public sealed class MovimientoRepuestosController : BaseController
    {
        private readonly IMovimientoRepuestoBusiness _movimientoRepuestoBusiness;

        public MovimientoRepuestosController(IMovimientoRepuestoBusiness movimientoRepuestoBusiness)
        {
            _movimientoRepuestoBusiness = movimientoRepuestoBusiness;
        }

        [HttpPost("Crear")]
        public async Task<ApiResponse<MovimientoRepuestoDto>> Crear(MovimientoRepuestoDto request)
        {

            return await _movimientoRepuestoBusiness.Crear(request);
        }

        [HttpPut("Actualizar")]
        public async Task<ApiResponse<MovimientoRepuestoDto>> Actualizar(MovimientoRepuestoDto request)
        {

            return await _movimientoRepuestoBusiness.Actualizar(request);
        }

        [HttpDelete("Eliminar/{id}")]
        public async Task<ApiResponse<bool>> Eliminar(string id)
        {
            return await _movimientoRepuestoBusiness.Eliminar(id);
        }

        [HttpGet("Listar")]
        public async Task<ApiResponse<IEnumerable<MovimientoRepuestoDto>>> Listar()
        {
            return await _movimientoRepuestoBusiness.ConsultarLista();
        }
    }
}
