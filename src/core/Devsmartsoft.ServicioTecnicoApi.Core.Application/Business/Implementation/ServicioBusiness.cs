using AutoMapper;
using Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces;
using Devsmartsoft.ServicioTecnicoApi.Core.Application.Resources;
using Devsmartsoft.ServicioTecnicoApi.Core.Domain.CommonEntities;
using Devsmartsoft.ServicioTecnicoApi.Core.Domain.Entities;
using Devsmartsoft.ServicioTecnicoApi.Core.Domain.RepositoryInterfaces;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Common;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;
using Devsmartsoft.ServicioTecnicoApi.Shared.Enums;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Implementation
{
    public sealed class ServicioBusiness : BaseBusiness, IServicioBusiness
    {
        #region Fields
        private readonly IServicioRepository _servicioRepository;
        private readonly IServicioTrazabilidadRepository _servicioTrazabilidadRepository;
        private readonly IOrderUpdateService _orderUpdateService;

        #endregion

        #region Ctor
        public ServicioBusiness(IMapper mapper, IServicioRepository servicioRepository,
                                IServicioTrazabilidadRepository servicioTrazabilidadRepository,
                                IOrderUpdateService orderUpdateService
                               ) : base(mapper)
        {
            _servicioRepository = servicioRepository;
            _servicioTrazabilidadRepository = servicioTrazabilidadRepository;
            _orderUpdateService = orderUpdateService;
        }
        #endregion

        #region Methods
        public async Task<ApiResponse<ServicioDto>> Actualizar(ServicioDto entidad)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                Servicio servicio = Mapper.Map<Servicio>(entidad);
                await _servicioRepository.UpdateAsync(servicio);
                return CreateApiResponse(Mapper.Map<ServicioDto>(servicio), NotificationsEnum.Success, ResourcesApplication.MsjDatosActualizados);
            });
        }

        public async Task<ApiResponse<IEnumerable<ServicioDto>>> ConsultarLista()
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                await _orderUpdateService.UpdateOrderStatusAsync(32, "Estado cambiado");
                IEnumerable<Servicio> query = await _servicioRepository.GetByFilterAsync();
                return CreateApiResponse(Mapper.Map<IEnumerable<ServicioDto>>(query), NotificationsEnum.Success);
            });
        }

        public async Task<ApiResponse<ServicioDto>> Crear(ServicioDto entidad)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                int count = await ObtenerContadorServicios();
                entidad.ServicioId = Guid.NewGuid();
                entidad.ConsecutivoServicio = $"SVC - {count + 1}";
                entidad.PorcentajeAvance = 10;
                entidad.EstadoId = (int)EstadosEnum.Ingresado;
                entidad.FechaIngreso = DateTime.Now;
                entidad.UsuarioCreacion = Guid.NewGuid();
                entidad.FechaCreacion = DateTime.Now;
                Servicio servicio = Mapper.Map<Servicio>(entidad);
                Servicio query = await _servicioRepository.CreateAsync(servicio);
                await CrearServicioTrazabilidad(query);
                return CreateApiResponse(Mapper.Map<ServicioDto>(servicio), NotificationsEnum.Success, ResourcesApplication.MsjDatosGuardados);
            });
        }

        public async Task<ApiResponse<bool>> Eliminar(string id)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                Servicio? existe = await _servicioRepository.GetByFilter(x => x.ServicioId == Guid.Parse(id));
                if (existe is null)
                    return CreateApiResponse(false, NotificationsEnum.Error, "Registro no encontrado.");

                await _servicioRepository.DeleteAsync(existe);
                return CreateApiResponse(true, NotificationsEnum.Success, ResourcesApplication.MsjDatosEliminados);
            });
        }

        public async Task<ApiResponse<IEnumerable<ServicioReporteDto>>> ListarPorFiltro(SearchOrderFilterDto filter)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                IEnumerable<ServicioReporte> query = await _servicioRepository.ListarPorFiltro(Mapper.Map<SearchOrderFilter>(filter));
                return CreateApiResponse(Mapper.Map<IEnumerable<ServicioReporteDto>>(query), NotificationsEnum.Success);
            });
        }

        public async Task<ApiResponse<int>> ObtenerCantidadServicios()
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                int count = await ObtenerContadorServicios();
                return CreateApiResponse(count, NotificationsEnum.Success);
            });
        }
        #endregion

        #region Private Methods
        private async Task<bool> CrearServicioTrazabilidad(Servicio servicio)
        {
            ServicioTrazabilidad trazabilidad = new ServicioTrazabilidad
            {
                TrazabilidadId = Guid.NewGuid(),
                ServicioId = servicio.ServicioId,
                TecnicoId = servicio.TecnicoId,
                FechaIngreso = servicio.FechaIngreso,
                FechaInicio = servicio.FechaInicio,
                FechaFin = servicio.FechaFin,
                FechaEntrega = servicio.FechaEntrega,
                PorcentajeAvance = servicio.PorcentajeAvance,
                ValorPagar = servicio.ValorPagar,
                ValorAbono = servicio.ValorAbono,
                FechaAbono = servicio.FechaAbono,
                DescripcionReparacion = servicio.DescripcionReparacion,
                Finalizado = servicio.Finalizada!.Value
            };
            return await _servicioTrazabilidadRepository.CreateAsync(trazabilidad) != null;
        }

        private async Task<int> ObtenerContadorServicios()
        {
            return await _servicioRepository.GetTableCount();
        }

        #endregion
    }
}
