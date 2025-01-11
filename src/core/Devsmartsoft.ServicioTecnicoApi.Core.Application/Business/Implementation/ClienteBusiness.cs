using AutoMapper;
using Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces;
using Devsmartsoft.ServicioTecnicoApi.Core.Application.Resources;
using Devsmartsoft.ServicioTecnicoApi.Core.Domain.Entities;
using Devsmartsoft.ServicioTecnicoApi.Core.Domain.RepositoryInterfaces;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;
using Devsmartsoft.ServicioTecnicoApi.Shared.Enums;
using Devsmartsoft.ServicioTecnicoApi.Shared.Helpers;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Implementation
{
    public sealed class ClienteBusiness : BaseBusiness, IClienteBusiness
    {
        #region Fields
        private readonly IClienteRepository _clienteRepository;
        #endregion

        #region Ctor
        public ClienteBusiness(IMapper mapper, IClienteRepository clienteRepository) : base(mapper)
        {
            _clienteRepository = clienteRepository;
        }
        #endregion

        #region Methods
        public async Task<ApiResponse<ClienteDto>> Actualizar(ClienteDto cliente)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                cliente.FechaActualizacion = DateTime.UtcNow;
                Cliente clienteSave = Mapper.Map<Cliente>(cliente);
                await _clienteRepository.UpdateAsync(clienteSave);
                return CreateApiResponse(Mapper.Map<ClienteDto>(clienteSave), NotificationsEnum.Success, ResourcesApplication.MsjDatosActualizados);
            });
        }

        public async Task<ApiResponse<IEnumerable<ClienteDto>>> ConsultarLista()
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                IEnumerable<Cliente> query = await _clienteRepository.GetByFilterAsync(x => x.Estado);
                return CreateApiResponse(Mapper.Map<IEnumerable<ClienteDto>>(query), NotificationsEnum.Success);
            });
        }
        public async Task<ApiResponse<ClienteDto>> Crear(ClienteDto cliente)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                Cliente? clienteExiste = await ValidarExistenciaCliente(cliente.DocId);
                if (clienteExiste != null)
                {
                    cliente.ClienteId = clienteExiste.ClienteId;
                    return await Actualizar(cliente);
                }
                cliente.ClienteId = Guid.NewGuid();
                cliente.Estado = true;
                cliente.UsuarioCreacion = Guid.NewGuid();
                Cliente clienteSave = Mapper.Map<Cliente>(cliente);
                Cliente query = await _clienteRepository.CreateAsync(clienteSave);
                return CreateApiResponse(Mapper.Map<ClienteDto>(clienteSave), NotificationsEnum.Success, ResourcesApplication.MsjDatosGuardados);
            });
        }

        public async Task<ApiResponse<bool>> Eliminar(string docId)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                ClienteDto? cliente = Mapper.Map<ClienteDto>(await ValidarExistenciaCliente(docId));
                if (cliente == null)
                    return CreateApiResponse(false, NotificationsEnum.Error, "El cliente no existe.");

                await DeshabilitarCliente(cliente);
                return CreateApiResponse(true, NotificationsEnum.Success, ResourcesApplication.MsjDatosEliminados);
            });
        }
        public async Task<ApiResponse<ClienteDto>> ConsultarPorDocumento(string docId)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                Cliente? query = await ValidarExistenciaCliente(docId);
                return CreateApiResponse(Mapper.Map<ClienteDto>(query), NotificationsEnum.Success);
            });
        }
        public async Task<ApiResponse<bool>> ActivarCliente(string docId)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                Cliente? query = await _clienteRepository.GetByFilter(x => x.DocId == docId && !x.Estado);
                if (query == null)
                    return CreateApiResponse(false, NotificationsEnum.Error, "El Cliente no existe.");

                query.Estado = true;
                query.FechaActualizacion = DateTime.UtcNow;
                await _clienteRepository.UpdateAsync(query);
                return CreateApiResponse(true, NotificationsEnum.Success, ResourcesApplication.MsjDatosActualizados);
            });
        }

        public async Task<ApiResponse<string>> GenerarCodigo(string docId)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                Cliente? cliente = await _clienteRepository.GetByFilter(x => x.DocId == docId && x.Estado);
                if (cliente is null)
                    return CreateApiResponse(string.Empty, NotificationsEnum.Error, ResourcesApplication.MsjClienteNoEncontrado);

                string code = CodeGenerator.GenerateRandomCode(6, true);
                cliente.CodigoUtilidad = code ?? string.Empty;
                await Actualizar(Mapper.Map<ClienteDto>(cliente));
                return CreateApiResponse(code!, NotificationsEnum.Success, string.Empty);
            });
        }
        public async Task<ApiResponse<bool>> ValidarCodigo(ClienteDto cliente)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                Cliente? query = await _clienteRepository.GetByFilter(x => x.DocId == cliente.DocId && x.Estado);
                if (query is null)
                    return CreateApiResponse(false, NotificationsEnum.Error, ResourcesApplication.MsjClienteNoEncontrado);

                if (!cliente.CodigoUtilidad!.Equals(query.CodigoUtilidad))
                    return CreateApiResponse(false, NotificationsEnum.Error, "Código incorrecto.");

                query.CodigoUtilidad = null;
                await Actualizar(Mapper.Map<ClienteDto>(query));
                return CreateApiResponse(true, NotificationsEnum.Success, string.Empty);
            });
        }
        #endregion

        #region Private Methods
        private async Task<Cliente?> ValidarExistenciaCliente(string docId)
        {
            return await _clienteRepository.GetByFilter(x => x.DocId == docId && x.Estado);
        }
        private async Task DeshabilitarCliente(ClienteDto cliente)
        {
            cliente.Estado = false;
            cliente.AceptaPolitica = false;
            await Actualizar(cliente);
        }
        #endregion
    }
}
