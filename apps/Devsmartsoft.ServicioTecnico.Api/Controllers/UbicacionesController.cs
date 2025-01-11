using Devsmartsoft.ServicioTecnico.Api.Controllers.Base;
using Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;
using Microsoft.AspNetCore.Mvc;

namespace Devsmartsoft.ServicioTecnico.Api.Controllers
{
    public sealed class UbicacionesController : BaseController
    {
        private readonly IUbicacionBusiness _ubicacionBusiness;

        public UbicacionesController(IUbicacionBusiness ubicacionBusiness)
        {
            _ubicacionBusiness = ubicacionBusiness;
        }

        [HttpPost("Crear")]
        public async Task<ApiResponse<UbicacionDto>> Crear(UbicacionDto request)
        {

            return await _ubicacionBusiness.Crear(request);
        }

        [HttpPut("Actualizar")]
        public async Task<ApiResponse<UbicacionDto>> Actualizar(UbicacionDto request)
        {

            return await _ubicacionBusiness.Actualizar(request);
        }

        [HttpDelete("Eliminar/{id}")]
        public async Task<ApiResponse<bool>> Eliminar(string id)
        {
            return await _ubicacionBusiness.Eliminar(id);
        }

        [HttpGet("Listar")]
        public async Task<ApiResponse<IEnumerable<UbicacionDto>>> Listar()
        {
            return await _ubicacionBusiness.ConsultarLista();
        }

        [HttpGet("ObtenerPorCliente/{id}")]
        public async Task<ApiResponse<IEnumerable<UbicacionDto>>> ObtenerPorCliente(Guid id)
        {
            return await _ubicacionBusiness.ObtenerPorCliente(id);
        }
    }
}
