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
    public sealed class TecnicoBusiness : BaseBusiness, ITecnicoBusiness
    {
        #region Fields
        private readonly ITecnicoRepository _tecnicoRepository;
        private readonly IServicioRepository _servicioRepository;
        #endregion

        #region Ctor
        public TecnicoBusiness(IMapper mapper, ITecnicoRepository tecnicoRepository, IServicioRepository servicioRepository) : base(mapper)
        {
            _tecnicoRepository = tecnicoRepository;
            _servicioRepository = servicioRepository;
        }
        #endregion

        #region Methods
        public async Task<ApiResponse<bool>> Activar(string docId)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                Tecnico? tecnico = await _tecnicoRepository.GetByFilter(x => x.DocId == docId && !x.Estado);
                if (tecnico is null)
                    return CreateApiResponse(false, NotificationsEnum.Error, "No se encontró el Técnico con el documento.");

                tecnico.Estado = true;
                tecnico.FechaActualizacion = DateTime.UtcNow;
                await _tecnicoRepository.UpdateAsync(tecnico);
                return CreateApiResponse(true, NotificationsEnum.Success, ResourcesApplication.MsjDatosActualizados);
            });
        }

        public async Task<ApiResponse<TecnicoDto>> Actualizar(TecnicoDto entidad)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                entidad.FechaActualizacion = DateTime.UtcNow;
                await _tecnicoRepository.UpdateAsync(Mapper.Map<Tecnico>(entidad));
                return CreateApiResponse(entidad, NotificationsEnum.Success, ResourcesApplication.MsjDatosActualizados);
            });
        }

        public async Task<ApiResponse<IEnumerable<TecnicoDto>>> ConsultarLista()
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                IEnumerable<Tecnico> query = await _tecnicoRepository.GetByFilterAsync(x => x.Estado);
                return CreateApiResponse(Mapper.Map<IEnumerable<TecnicoDto>>(query), NotificationsEnum.Success);
            });
        }

        public Task<ApiResponse<TecnicoDto>> ConsultarPorDocumento(string docId)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<TecnicoDto>> Crear(TecnicoDto entidad)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                Tecnico? existe = await ValidarExistencia(entidad.DocId);
                if (existe != null)
                {
                    entidad.TecnicoId = existe.TecnicoId;
                    return await Actualizar(entidad);
                }

                entidad.TecnicoId = Guid.NewGuid();
                entidad.Estado = true;
                entidad.UsuarioCreacion = Guid.NewGuid();
                Tecnico query = await _tecnicoRepository.CreateAsync(Mapper.Map<Tecnico>(entidad));
                return CreateApiResponse(entidad, NotificationsEnum.Success, ResourcesApplication.MsjDatosGuardados);
            });
        }

        public async Task<ApiResponse<bool>> Desactivar(string docId)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                Tecnico? tecnico = await _tecnicoRepository.GetByFilter(x => x.DocId == docId && x.Estado);
                if (tecnico is null)
                    return CreateApiResponse(false, NotificationsEnum.Error, "No se encontró el Técnico con el documento.");

                tecnico.Estado = false;
                tecnico.FechaActualizacion = DateTime.UtcNow;
                await _tecnicoRepository.UpdateAsync(tecnico);
                return CreateApiResponse(true, NotificationsEnum.Success, ResourcesApplication.MsjDatosActualizados);
            });
        }

        public async Task<ApiResponse<bool>> Eliminar(string docId)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                Tecnico? existe = await _tecnicoRepository.GetByFilter(x => x.DocId == docId);
                if (existe is null)
                    return CreateApiResponse(false, NotificationsEnum.Error, "El Técnico no existe.");

                bool servicioAsociados = await _servicioRepository.GetByFilter(x => x.TecnicoId == existe.TecnicoId) != null;
                if (servicioAsociados)
                    return CreateApiResponse(false, NotificationsEnum.Error, "El Técnico ya tiene servicios asociados, en vez de eliminarlo, proceda a desactivarlo.");

                await _tecnicoRepository.DeleteAsync(existe);
                return CreateApiResponse(true, NotificationsEnum.Success, ResourcesApplication.MsjDatosEliminados);
            });
        }

        public async Task<ApiResponse<string>> GenerarCodigo(string docId)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                Tecnico? existe = await _tecnicoRepository.GetByFilter(x => x.DocId == docId && x.Estado);
                if (existe is null)
                    return CreateApiResponse(string.Empty, NotificationsEnum.Error, ResourcesApplication.MsjClienteNoEncontrado);

                string code = CodeGenerator.GenerateRandomCode(6, true);
                existe.CodigoUtilidad = code ?? string.Empty;
                await _tecnicoRepository.UpdateAsync(existe);
                return CreateApiResponse(code!, NotificationsEnum.Success, string.Empty);
            });
        }

        public async Task<ApiResponse<bool>> ValidarCodigo(TecnicoDto entidad)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                Tecnico? query = await _tecnicoRepository.GetByFilter(x => x.DocId == entidad.DocId && x.Estado);
                if (query is null)
                    return CreateApiResponse(false, NotificationsEnum.Error, ResourcesApplication.MsjClienteNoEncontrado);

                if (!entidad.CodigoUtilidad!.Equals(query.CodigoUtilidad))
                    return CreateApiResponse(false, NotificationsEnum.Error, "Código incorrecto.");

                query.CodigoUtilidad = null;
                await _tecnicoRepository.UpdateAsync(query);
                return CreateApiResponse(true, NotificationsEnum.Success, string.Empty);
            });
        }
        #endregion

        #region Private Methods 
        private async Task<Tecnico?> ValidarExistencia(string docId)
        {
            return await _tecnicoRepository.GetByFilter(x => x.DocId == docId && x.Estado);
        }
        #endregion
    }
}
