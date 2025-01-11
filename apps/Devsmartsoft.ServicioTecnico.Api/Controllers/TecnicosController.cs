using Devsmartsoft.ServicioTecnico.Api.Controllers.Base;
using Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;
using Microsoft.AspNetCore.Mvc;

namespace Devsmartsoft.ServicioTecnico.Api.Controllers
{
    public sealed class TecnicosController : BaseController
    {
        private readonly ITecnicoBusiness _tecnicoBusiness;

        public TecnicosController(ITecnicoBusiness tecnicoBusiness)
        {
            _tecnicoBusiness = tecnicoBusiness;
        }

        [HttpPost("Crear")]
        public async Task<ApiResponse<TecnicoDto>> Crear(TecnicoDto request)
        {

            return await _tecnicoBusiness.Crear(request);
        }

        [HttpPut("Actualizar")]
        public async Task<ApiResponse<TecnicoDto>> Actualizar(TecnicoDto request)
        {

            return await _tecnicoBusiness.Actualizar(request);
        }

        [HttpDelete("Eliminar/{id}")]
        public async Task<ApiResponse<bool>> Eliminar(string id)
        {
            return await _tecnicoBusiness.Eliminar(id);
        }

        [HttpGet("Listar")]
        public async Task<ApiResponse<IEnumerable<TecnicoDto>>> Listar()
        {
            return await _tecnicoBusiness.ConsultarLista();
        }

        [HttpGet("ConsultarPorDocumento/{docId}")]
        public async Task<ApiResponse<TecnicoDto>> ConsultarPorDocumento(string docId)
        {
            return await _tecnicoBusiness.ConsultarPorDocumento(docId);
        }

        [HttpPost("Activar")]
        public async Task<ApiResponse<bool>> Activar(string docId)
        {
            return await _tecnicoBusiness.Activar(docId);
        }


        [HttpPost("Desactivar")]
        public async Task<ApiResponse<bool>> Desactivar(string docId)
        {
            return await _tecnicoBusiness.Desactivar(docId);
        }

        [HttpPost("GenerarCodigo")]
        public async Task<ApiResponse<string>> GenerarCodigo(string docId)
        {
            return await _tecnicoBusiness.GenerarCodigo(docId);
        }

        [HttpPost("ValidarCodigo")]
        public async Task<ApiResponse<bool>> ValidarCodigo(TecnicoDto cliente)
        {
            return await _tecnicoBusiness.ValidarCodigo(cliente);
        }
    }
}
