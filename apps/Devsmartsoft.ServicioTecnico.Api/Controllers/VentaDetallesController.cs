using Devsmartsoft.ServicioTecnico.Api.Controllers.Base;
using Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;
using Microsoft.AspNetCore.Mvc;

namespace Devsmartsoft.ServicioTecnico.Api.Controllers
{
    public sealed class VentaDetallesController : BaseController
    {
        private readonly IVentaDetalleBusiness _ventaDetalleBusiness;

        public VentaDetallesController(IVentaDetalleBusiness ventaDetalleBusiness)
        {
            _ventaDetalleBusiness = ventaDetalleBusiness;
        }

        [HttpPost("Crear")]
        public async Task<ApiResponse<bool>> Crear(IEnumerable<VentaDetalleDto> request)
        {

            return await _ventaDetalleBusiness.Crear(request);
        }

        [HttpPut("Actualizar")]
        public async Task<ApiResponse<VentaDetalleDto>> Actualizar(VentaDetalleDto request)
        {

            return await _ventaDetalleBusiness.Actualizar(request);
        }

        [HttpDelete("Eliminar/{id}")]
        public async Task<ApiResponse<bool>> Eliminar(string id)
        {
            return await _ventaDetalleBusiness.Eliminar(id);
        }

        [HttpGet("Listar/{ventaId}")]
        public async Task<ApiResponse<IEnumerable<VentaDetalleDto>>> Listar(Guid ventaId)
        {
            return await _ventaDetalleBusiness.ConsultarLista(ventaId);
        }
    }
}
