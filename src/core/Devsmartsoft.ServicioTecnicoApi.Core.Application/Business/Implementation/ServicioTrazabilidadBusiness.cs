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
    public sealed class ServicioTrazabilidadBusiness : BaseBusiness, IServicioTrazabilidadBusiness
    {
        #region Fields
        private readonly IServicioTrazabilidadRepository _servicioTrazabilidadRepository;
        #endregion

        #region Ctor
        public ServicioTrazabilidadBusiness(IMapper mapper, IServicioTrazabilidadRepository servicioTrazabilidadRepository) : base(mapper)
        {
            _servicioTrazabilidadRepository = servicioTrazabilidadRepository;
        }
        #endregion

        #region Methods
        public async Task<ApiResponse<ServicioTrazabilidadDto>> Actualizar(ServicioTrazabilidadDto entidad)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                await _servicioTrazabilidadRepository.UpdateAsync(Mapper.Map<ServicioTrazabilidad>(entidad));
                return CreateApiResponse(entidad, NotificationsEnum.Success, ResourcesApplication.MsjDatosActualizados);
            });
        }

        public async Task<ApiResponse<IEnumerable<ServicioTrazabilidadDto>>> ConsultarLista()
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                IEnumerable<ServicioTrazabilidad> query = await _servicioTrazabilidadRepository.GetByFilterAsync();
                return CreateApiResponse(Mapper.Map<IEnumerable<ServicioTrazabilidadDto>>(query), NotificationsEnum.Success);
            });
        }

        public async Task<ApiResponse<ServicioTrazabilidadDto>> Crear(ServicioTrazabilidadDto entidad)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                entidad.TrazabilidadId = Guid.NewGuid();
                entidad.UsuarioCreacion = Guid.NewGuid();
                entidad.FechaCreacion = DateTime.UtcNow;
                ServicioTrazabilidad query = await _servicioTrazabilidadRepository.CreateAsync(Mapper.Map<ServicioTrazabilidad>(entidad));
                return CreateApiResponse(entidad, NotificationsEnum.Success, ResourcesApplication.MsjDatosGuardados);
            });
        }

        public async Task<ApiResponse<bool>> Eliminar(string id)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                ServicioTrazabilidad? existe = await _servicioTrazabilidadRepository.GetByFilter(x => x.TrazabilidadId == Guid.Parse(id));
                if (existe is null)
                    return CreateApiResponse(false, NotificationsEnum.Error, "Registro no encontrado.");

                await _servicioTrazabilidadRepository.DeleteAsync(existe);
                return CreateApiResponse(true, NotificationsEnum.Success, ResourcesApplication.MsjDatosEliminados);
            });
        }
        #endregion

    }
}
