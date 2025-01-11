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
    public sealed class GastoBusiness : BaseBusiness, IGastoBusiness
    {
        #region Fields
        private readonly IGastoRepository _gastoRepository;
        #endregion

        #region Ctor
        public GastoBusiness(IMapper mapper, IGastoRepository gastoRepository) : base(mapper)
        {
            _gastoRepository = gastoRepository;
        }
        #endregion

        #region Methods
        public async Task<ApiResponse<GastoDto>> Actualizar(GastoDto entidad)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                await _gastoRepository.UpdateAsync(Mapper.Map<Gasto>(entidad));
                return CreateApiResponse(entidad, NotificationsEnum.Success, ResourcesApplication.MsjDatosActualizados);
            });
        }

        public async Task<ApiResponse<IEnumerable<GastoDto>>> ConsultarLista()
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                IEnumerable<Gasto> query = await _gastoRepository.GetByFilterAsync();
                return CreateApiResponse(Mapper.Map<IEnumerable<GastoDto>>(query), NotificationsEnum.Success);
            });
        }

        public async Task<ApiResponse<GastoDto>> Crear(GastoDto entidad)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                entidad.GastoId = Guid.NewGuid();
                entidad.UsuarioCreacion = Guid.NewGuid();
                Gasto query = await _gastoRepository.CreateAsync(Mapper.Map<Gasto>(entidad));
                return CreateApiResponse(entidad, NotificationsEnum.Success, ResourcesApplication.MsjDatosGuardados);
            });
        }

        public async Task<ApiResponse<bool>> Eliminar(string id)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                Gasto? existe = await _gastoRepository.GetByFilter(x => x.GastoId == Guid.Parse(id));
                if (existe is null)
                    return CreateApiResponse(false, NotificationsEnum.Error, "Registro no encontrado.");

                await _gastoRepository.DeleteAsync(existe);
                return CreateApiResponse(true, NotificationsEnum.Success, ResourcesApplication.MsjDatosEliminados);
            });
        }
        #endregion

    }
}
