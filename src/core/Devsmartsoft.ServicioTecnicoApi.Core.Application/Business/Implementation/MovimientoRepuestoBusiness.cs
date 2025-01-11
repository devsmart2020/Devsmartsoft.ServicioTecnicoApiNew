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
    public sealed class MovimientoRepuestoBusiness : BaseBusiness, IMovimientoRepuestoBusiness
    {
        #region Fields
        private readonly IMovimientoRepuestoRepository _movimientoRepuestoRepository;
        #endregion

        #region Ctor
        public MovimientoRepuestoBusiness(IMapper mapper, IMovimientoRepuestoRepository movimientoRepuestoRepository) : base(mapper)
        {
            _movimientoRepuestoRepository = movimientoRepuestoRepository;
        }
        #endregion

        #region Methods
        public async Task<ApiResponse<MovimientoRepuestoDto>> Actualizar(MovimientoRepuestoDto entidad)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                await _movimientoRepuestoRepository.UpdateAsync(Mapper.Map<MovimientoRepuesto>(entidad));
                return CreateApiResponse(entidad, NotificationsEnum.Success, ResourcesApplication.MsjDatosActualizados);
            });
        }

        public async Task<ApiResponse<IEnumerable<MovimientoRepuestoDto>>> ConsultarLista()
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                IEnumerable<MovimientoRepuesto> query = await _movimientoRepuestoRepository.GetByFilterAsync();
                return CreateApiResponse(Mapper.Map<IEnumerable<MovimientoRepuestoDto>>(query), NotificationsEnum.Success);
            });
        }

        public async Task<ApiResponse<MovimientoRepuestoDto>> Crear(MovimientoRepuestoDto entidad)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                entidad.UsuarioCreacion = Guid.NewGuid();
                MovimientoRepuesto query = await _movimientoRepuestoRepository.CreateAsync(Mapper.Map<MovimientoRepuesto>(entidad));
                return CreateApiResponse(entidad, NotificationsEnum.Success, ResourcesApplication.MsjDatosGuardados);
            });
        }

        public async Task<ApiResponse<bool>> Eliminar(string id)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                MovimientoRepuesto? existe = await _movimientoRepuestoRepository.GetByFilter(x => x.MovimientoId == int.Parse(id));
                if (existe is null)
                    return CreateApiResponse(false, NotificationsEnum.Error, "Registro no encontrado.");

                await _movimientoRepuestoRepository.DeleteAsync(existe);
                return CreateApiResponse(true, NotificationsEnum.Success, ResourcesApplication.MsjDatosEliminados);
            });
        }
        #endregion

    }
}
