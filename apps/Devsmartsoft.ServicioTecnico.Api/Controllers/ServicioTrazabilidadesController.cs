using Devsmartsoft.ServicioTecnico.Api.Controllers.Base;
using Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;
using Microsoft.AspNetCore.Mvc;

namespace Devsmartsoft.ServicioTecnico.Api.Controllers
{
    public sealed class ServicioTrazabilidadesController : BaseController
    {
        private readonly IServicioTrazabilidadBusiness _servicioTrazabilidadBusiness;

        public ServicioTrazabilidadesController(IServicioTrazabilidadBusiness servicioTrazabilidadBusiness)
        {
            _servicioTrazabilidadBusiness = servicioTrazabilidadBusiness;
        }


        [HttpPost("Crear")]
        public async Task<ApiResponse<ServicioTrazabilidadDto>> Crear(ServicioTrazabilidadDto request)
        {

            return await _servicioTrazabilidadBusiness.Crear(request);
        }

        [HttpPut("Actualizar")]
        public async Task<ApiResponse<ServicioTrazabilidadDto>> Actualizar(ServicioTrazabilidadDto request)
        {

            return await _servicioTrazabilidadBusiness.Actualizar(request);
        }

        [HttpDelete("Eliminar/{id}")]
        public async Task<ApiResponse<bool>> Eliminar(string id)
        {
            return await _servicioTrazabilidadBusiness.Eliminar(id);
        }

        [HttpGet("Listar")]
        public async Task<ApiResponse<IEnumerable<ServicioTrazabilidadDto>>> Listar()
        {
            return await _servicioTrazabilidadBusiness.ConsultarLista();
        }
    }
}
