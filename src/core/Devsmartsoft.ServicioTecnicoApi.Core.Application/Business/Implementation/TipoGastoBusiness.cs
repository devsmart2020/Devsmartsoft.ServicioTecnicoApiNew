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
    public sealed class TipoGastoBusiness : BaseBusiness, ITipoGastoBusiness
    {
        #region Fields
        private readonly ITipoGastoRepository _tipoGastoRepository;
        #endregion

        #region Ctor
        public TipoGastoBusiness(IMapper mapper, ITipoGastoRepository tipoGastoRepository) : base(mapper)
        {
            _tipoGastoRepository = tipoGastoRepository;
        }
        #endregion

        #region Methods
        public async Task<ApiResponse<TipoGastoDto>> Actualizar(TipoGastoDto entidad)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                await _tipoGastoRepository.UpdateAsync(Mapper.Map<TipoGasto>(entidad));
                return CreateApiResponse(entidad, NotificationsEnum.Success, ResourcesApplication.MsjDatosActualizados);
            });
        }

        public async Task<ApiResponse<IEnumerable<TipoGastoDto>>> ConsultarLista()
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                IEnumerable<TipoGasto> query = await _tipoGastoRepository.GetByFilterAsync();
                return CreateApiResponse(Mapper.Map<IEnumerable<TipoGastoDto>>(query), NotificationsEnum.Success);
            });
        }

        public async Task<ApiResponse<TipoGastoDto>> Crear(TipoGastoDto entidad)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                entidad.TipoGastoId = Guid.NewGuid();
                TipoGasto query = await _tipoGastoRepository.CreateAsync(Mapper.Map<TipoGasto>(entidad));
                return CreateApiResponse(entidad, NotificationsEnum.Success, ResourcesApplication.MsjDatosGuardados);
            });
        }

        public async Task<ApiResponse<bool>> Eliminar(string id)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                TipoGasto? existe = await _tipoGastoRepository.GetByFilter(x => x.TipoGastoId == Guid.Parse(id));
                if (existe is null)
                    return CreateApiResponse(false, NotificationsEnum.Error, "Registro no encontrado.");

                await _tipoGastoRepository.DeleteAsync(existe);
                return CreateApiResponse(true, NotificationsEnum.Success, ResourcesApplication.MsjDatosEliminados);
            });
        }
        #endregion

    }
}
