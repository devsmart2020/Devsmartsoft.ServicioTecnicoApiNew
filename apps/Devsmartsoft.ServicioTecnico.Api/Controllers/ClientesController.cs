using Devsmartsoft.ServicioTecnico.Api.Controllers.Base;
using Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;
using Microsoft.AspNetCore.Mvc;

namespace Devsmartsoft.ServicioTecnico.Api.Controllers
{
    public sealed class ClientesController : BaseController
    {
        private readonly IClienteBusiness _clienteBusiness;

        public ClientesController(IClienteBusiness clienteBusiness)
        {
            _clienteBusiness = clienteBusiness;
        }

        [HttpPost("Crear")]
        public async Task<ApiResponse<ClienteDto>> Crear(ClienteDto request)
        {

            return await _clienteBusiness.Crear(request);
        }

        [HttpPut("Actualizar")]
        public async Task<ApiResponse<ClienteDto>> Actualizar(ClienteDto request)
        {

            return await _clienteBusiness.Actualizar(request);
        }

        [HttpDelete("Eliminar/{id}")]
        public async Task<ApiResponse<bool>> Eliminar(string id)
        {
            return await _clienteBusiness.Eliminar(id);
        }

        [HttpGet("Listar")]
        public async Task<ApiResponse<IEnumerable<ClienteDto>>> Listar()
        {
            return await _clienteBusiness.ConsultarLista();
        }

        [HttpGet("ConsultarPorDocumento/{docId}")]
        public async Task<ApiResponse<ClienteDto>> ConsultarPorDocumento(string docId)
        {
            return await _clienteBusiness.ConsultarPorDocumento(docId);
        }

        [HttpPost("ActivarCliente")]
        public async Task<ApiResponse<bool>> ActivarCliente(string docId)
        {
            return await _clienteBusiness.ActivarCliente(docId);
        }

        [HttpPost("GenerarCodigo")]
        public async Task<ApiResponse<string>> GenerarCodigo(string docId)
        {
            return await _clienteBusiness.GenerarCodigo(docId);
        }

        [HttpPost("ValidarCodigo")]
        public async Task<ApiResponse<bool>> ValidarCodigo(ClienteDto cliente)
        {
            return await _clienteBusiness.ValidarCodigo(cliente);
        }
    }
}
