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
    public sealed class RepuestoBusiness : BaseBusiness, IRepuestoBusiness
    {
        #region Fields
        private readonly IRepuestoRepository _repuestoRepository;
        #endregion

        #region Ctor
        public RepuestoBusiness(IMapper mapper, IRepuestoRepository repuestoRepository) : base(mapper)
        {
            _repuestoRepository = repuestoRepository;
        }
        #endregion

        #region Methods
        public async Task<ApiResponse<RepuestoDto>> Actualizar(RepuestoDto entidad)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                await _repuestoRepository.UpdateAsync(Mapper.Map<Repuesto>(entidad));
                return CreateApiResponse(entidad, NotificationsEnum.Success, ResourcesApplication.MsjDatosActualizados);
            });
        }

        public async Task<ApiResponse<IEnumerable<RepuestoDto>>> ConsultarLista()
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                IEnumerable<Repuesto> query = await _repuestoRepository.GetByFilterAsync();
                return CreateApiResponse(Mapper.Map<IEnumerable<RepuestoDto>>(query), NotificationsEnum.Success);
            });
        }

        public async Task<ApiResponse<RepuestoDto>> Crear(RepuestoDto entidad)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                Repuesto? existe = await _repuestoRepository.GetByIdAsync(entidad.RepuestoId);
                if (existe != null)
                {
                    entidad.RepuestoId = existe.RepuestoId;
                    return await Actualizar(entidad);
                }

                entidad.RepuestoId = Guid.NewGuid();
                Repuesto query = await _repuestoRepository.CreateAsync(Mapper.Map<Repuesto>(entidad));
                return CreateApiResponse(entidad, NotificationsEnum.Success, ResourcesApplication.MsjDatosGuardados);
            });
        }

        public async Task<ApiResponse<bool>> Eliminar(string id)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                Repuesto? existe = await _repuestoRepository.GetByFilter(x => x.RepuestoId == Guid.Parse(id));
                if (existe is null)
                    return CreateApiResponse(false, NotificationsEnum.Error, "Registro no encontrado.");

                await _repuestoRepository.DeleteAsync(existe);
                return CreateApiResponse(true, NotificationsEnum.Success, ResourcesApplication.MsjDatosEliminados);
            });
        }
        #endregion

    }
}
