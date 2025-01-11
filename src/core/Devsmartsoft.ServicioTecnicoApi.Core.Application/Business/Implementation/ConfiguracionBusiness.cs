using AutoMapper;
using Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces;
using Devsmartsoft.ServicioTecnicoApi.Core.Application.Resources;
using Devsmartsoft.ServicioTecnicoApi.Core.Domain.Entities;
using Devsmartsoft.ServicioTecnicoApi.Core.Domain.RepositoryInterfaces;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;
using Devsmartsoft.ServicioTecnicoApi.Shared.Enums;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Implementation
{
    public sealed class ConfiguracionBusiness : BaseBusiness, IConfiguracionBusiness
    {
        #region Fields
        private readonly IConfiguracionRepository _configuracionRepository;
        #endregion

        #region Ctor
        public ConfiguracionBusiness(IMapper mapper, IConfiguracionRepository repository) : base(mapper)
        {
            _configuracionRepository = repository;
        }
        #endregion

        #region Methods
        public async Task<ApiResponse<ConfiguracionDto>> Actualizar(ConfiguracionDto entidad)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                await _configuracionRepository.UpdateAsync(Mapper.Map<Configuracion>(entidad));
                return CreateApiResponse(entidad, NotificationsEnum.Success, ResourcesApplication.MsjDatosActualizados);
            });
        }

        public async Task<ApiResponse<IEnumerable<ConfiguracionDto>>> ConsultarLista()
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                IEnumerable<Configuracion> query = await _configuracionRepository.GetByFilterAsync();
                return CreateApiResponse(Mapper.Map<IEnumerable<ConfiguracionDto>>(query), NotificationsEnum.Success);
            });
        }

        public async Task<ApiResponse<ConfiguracionDto>> Crear(ConfiguracionDto entidad)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                entidad.ConfiguracionId = Guid.NewGuid();
                entidad.UsuarioCreacion = Guid.NewGuid();
                entidad.FechaCreacion = DateTime.UtcNow;
                Configuracion query = await _configuracionRepository.CreateAsync(Mapper.Map<Configuracion>(entidad));
                return CreateApiResponse(entidad, NotificationsEnum.Success, ResourcesApplication.MsjDatosGuardados);
            });
        }

        public async Task<ApiResponse<bool>> Eliminar(string id)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                Configuracion? existe = await _configuracionRepository.GetByFilter(x => x.ConfiguracionId == Guid.Parse(id));
                if (existe is null)
                    return CreateApiResponse(false, NotificationsEnum.Error, "Registro no encontrado.");

                await _configuracionRepository.DeleteAsync(existe);
                return CreateApiResponse(true, NotificationsEnum.Success, ResourcesApplication.MsjDatosEliminados);
            });
        }
        #endregion

    }
}
