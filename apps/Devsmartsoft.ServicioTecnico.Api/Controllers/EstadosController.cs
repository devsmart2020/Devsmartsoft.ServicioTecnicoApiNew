using Devsmartsoft.ServicioTecnico.Api.Controllers.Base;
using Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;
using Microsoft.AspNetCore.Mvc;

namespace Devsmartsoft.ServicioTecnico.Api.Controllers
{
    public sealed class EstadosController : BaseController
    {
        private readonly IEstadoBusiness _estadoBusiness;

        public EstadosController(IEstadoBusiness estadoBusiness)
        {
            _estadoBusiness = estadoBusiness;
        }

        [HttpPost("Crear")]
        public async Task<ApiResponse<EstadoDto>> Crear(EstadoDto request)
        {

            return await _estadoBusiness.Crear(request);
        }

        [HttpPut("Actualizar")]
        public async Task<ApiResponse<EstadoDto>> Actualizar(EstadoDto request)
        {

            return await _estadoBusiness.Actualizar(request);
        }

        [HttpDelete("Eliminar/{id}")]
        public async Task<ApiResponse<bool>> Eliminar(int id)
        {
            return await _estadoBusiness.Eliminar(id);
        }

        [HttpGet("Listar")]
        public async Task<ApiResponse<IEnumerable<EstadoDto>>> Listar()
        {
            return await _estadoBusiness.ConsultarLista();
        }
    }
}
