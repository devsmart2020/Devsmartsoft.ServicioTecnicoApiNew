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
    public sealed class VentaDetalleBusiness : BaseBusiness, IVentaDetalleBusiness
    {
        #region Fields
        private readonly IVentaDetalleRepository _ventaDetalleRepository;
        #endregion

        #region Ctor
        public VentaDetalleBusiness(IMapper mapper, IVentaDetalleRepository ventaDetalleRepository) : base(mapper)
        {
            _ventaDetalleRepository = ventaDetalleRepository;
        }
        #endregion

        #region Methods
        public async Task<ApiResponse<VentaDetalleDto>> Actualizar(VentaDetalleDto entidad)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                await _ventaDetalleRepository.UpdateAsync(Mapper.Map<VentaDetalle>(entidad));
                return CreateApiResponse(entidad, NotificationsEnum.Success, ResourcesApplication.MsjDatosActualizados);
            });
        }

        public async Task<ApiResponse<IEnumerable<VentaDetalleDto>>> ConsultarLista(Guid ventaId)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                IEnumerable<VentaDetalle> query = await _ventaDetalleRepository.GetByFilterAsync(x => x.VentaId == ventaId);
                return CreateApiResponse(Mapper.Map<IEnumerable<VentaDetalleDto>>(query), NotificationsEnum.Success);
            });
        }

        public async Task<ApiResponse<bool>> Crear(IEnumerable<VentaDetalleDto> entidad)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                bool query = await _ventaDetalleRepository.CreateRangeAsync(Mapper.Map<IEnumerable<VentaDetalle>>(entidad)) != null;
                return CreateApiResponse(query, NotificationsEnum.Success, ResourcesApplication.MsjDatosGuardados);
            });
        }

        public Task<ApiResponse<bool>> Eliminar(string id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
