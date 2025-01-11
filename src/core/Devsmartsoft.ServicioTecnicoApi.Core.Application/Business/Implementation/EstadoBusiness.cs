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
    public sealed class EstadoBusiness : BaseBusiness, IEstadoBusiness
    {
        #region Fields
        private readonly IEstadoRepository _estadoRepository;
        #endregion

        #region Ctor
        public EstadoBusiness(IMapper mapper, IEstadoRepository estadoRepository) : base(mapper)
        {
            _estadoRepository = estadoRepository;
        }
        #endregion

        #region Methods
        public async Task<ApiResponse<EstadoDto>> Actualizar(EstadoDto entidad)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                await _estadoRepository.UpdateAsync(Mapper.Map<Estado>(entidad));
                return CreateApiResponse(entidad, NotificationsEnum.Success, ResourcesApplication.MsjDatosActualizados);
            });

        }

        public async Task<ApiResponse<IEnumerable<EstadoDto>>> ConsultarLista()
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                IEnumerable<Estado> query = await _estadoRepository.GetByFilterAsync();
                return CreateApiResponse(Mapper.Map<IEnumerable<EstadoDto>>(query), NotificationsEnum.Success);
            });
        }

        public async Task<ApiResponse<EstadoDto>> Crear(EstadoDto entidad)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                Estado query = await _estadoRepository.CreateAsync(Mapper.Map<Estado>(entidad));
                return CreateApiResponse(entidad, NotificationsEnum.Success, ResourcesApplication.MsjDatosGuardados);
            });
        }

        public async Task<ApiResponse<bool>> Eliminar(int id)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                Estado? existe = await _estadoRepository.GetByFilter(x => x.EstadoId == id);
                if (existe is null)
                    return CreateApiResponse(false, NotificationsEnum.Error, "Registro no encontrado.");

                await _estadoRepository.DeleteAsync(existe);
                return CreateApiResponse(true, NotificationsEnum.Success, ResourcesApplication.MsjDatosEliminados);
            });
        }
        #endregion

    }
}
