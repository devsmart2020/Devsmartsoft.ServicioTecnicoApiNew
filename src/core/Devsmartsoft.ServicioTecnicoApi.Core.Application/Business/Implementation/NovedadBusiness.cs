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
    public sealed class NovedadBusiness : BaseBusiness, INovedadBusiness
    {
        private readonly INovedadRepository _novedadRepository;
        #region Fields

        #endregion

        #region Ctor
        public NovedadBusiness(IMapper mapper, INovedadRepository novedadRepository) : base(mapper)
        {
            _novedadRepository = novedadRepository;
        }
        #endregion

        #region Methods
        public async Task<ApiResponse<NovedadDto>> Actualizar(NovedadDto entidad)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                await _novedadRepository.UpdateAsync(Mapper.Map<Novedad>(entidad));
                return CreateApiResponse(entidad, NotificationsEnum.Success, ResourcesApplication.MsjDatosActualizados);
            });
        }

        public async Task<ApiResponse<IEnumerable<NovedadDto>>> ConsultarLista()
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                IEnumerable<Novedad> query = await _novedadRepository.GetByFilterAsync();
                return CreateApiResponse(Mapper.Map<IEnumerable<NovedadDto>>(query), NotificationsEnum.Success);
            });
        }

        public async Task<ApiResponse<NovedadDto>> Crear(NovedadDto entidad)
        {
            entidad.NovedadId = Guid.NewGuid();
            entidad.UsuarioCreacion = Guid.NewGuid();
            entidad.FechaCreacion = DateTime.UtcNow;
            Novedad query = await _novedadRepository.CreateAsync(Mapper.Map<Novedad>(entidad));
            return CreateApiResponse(entidad, NotificationsEnum.Success, ResourcesApplication.MsjDatosGuardados);
        }

        public async Task<ApiResponse<bool>> Eliminar(string id)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                Novedad? existe = await _novedadRepository.GetByFilter(x => x.NovedadId == Guid.Parse(id));
                if (existe is null)
                    return CreateApiResponse(false, NotificationsEnum.Error, "Registro no encontrado.");

                await _novedadRepository.DeleteAsync(existe);
                return CreateApiResponse(true, NotificationsEnum.Success, ResourcesApplication.MsjDatosEliminados);
            });
        }
        #endregion

    }
}
