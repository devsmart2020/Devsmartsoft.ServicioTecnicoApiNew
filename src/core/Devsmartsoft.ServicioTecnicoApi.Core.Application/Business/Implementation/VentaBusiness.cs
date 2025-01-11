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
    public sealed class VentaBusiness : BaseBusiness, IVentaBusiness
    {
        #region Fields
        private readonly IVentaRepository _ventaRepository;
        #endregion

        #region Ctor
        public VentaBusiness(IMapper mapper, IVentaRepository ventaRepository) : base(mapper)
        {
            _ventaRepository = ventaRepository;
        }
        #endregion

        #region Methods
        public async Task<ApiResponse<VentaDto>> Actualizar(VentaDto entidad)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                await _ventaRepository.UpdateAsync(Mapper.Map<Venta>(entidad));
                return CreateApiResponse(entidad, NotificationsEnum.Success, ResourcesApplication.MsjDatosActualizados);
            });
        }

        public async Task<ApiResponse<IEnumerable<VentaDto>>> ConsultarLista()
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                IEnumerable<Venta> query = await _ventaRepository.GetByFilterAsync();
                return CreateApiResponse(Mapper.Map<IEnumerable<VentaDto>>(query), NotificationsEnum.Success);
            });
        }

        public async Task<ApiResponse<VentaDto>> Crear(VentaDto entidad)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                entidad.VentaId = Guid.NewGuid();
                entidad.UsuarioCreacion = Guid.NewGuid();
                entidad.FechaCreacion = DateTime.UtcNow;
                Venta query = await _ventaRepository.CreateAsync(Mapper.Map<Venta>(entidad));
                return CreateApiResponse(entidad, NotificationsEnum.Success, ResourcesApplication.MsjDatosGuardados);
            });
        }

        public async Task<ApiResponse<bool>> Eliminar(string id)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                Venta? existe = await _ventaRepository.GetByFilter(x => x.VentaId == Guid.Parse(id));
                if (existe is null)
                    return CreateApiResponse(false, NotificationsEnum.Error, "Registro no encontrado.");

                await _ventaRepository.DeleteAsync(existe);
                return CreateApiResponse(true, NotificationsEnum.Success, ResourcesApplication.MsjDatosEliminados);
            });
        }
        #endregion

    }
}
