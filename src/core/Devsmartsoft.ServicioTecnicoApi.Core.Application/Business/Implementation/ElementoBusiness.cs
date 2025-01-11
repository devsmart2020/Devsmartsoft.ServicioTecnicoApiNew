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
    public sealed class ElementoBusiness : BaseBusiness, IElementoBusiness
    {
        #region Fields
        private readonly IElementoRepository _elementoRepository;
        private readonly IServicioRepository _servicioRepository;
        #endregion

        #region Ctor
        public ElementoBusiness(IMapper mapper, IElementoRepository elementoRepository, IServicioRepository servicioRepository) : base(mapper)
        {
            _elementoRepository = elementoRepository;
            _servicioRepository = servicioRepository;
        }
        #endregion

        #region Methods
        public async Task<ApiResponse<ElementoDto>> Actualizar(ElementoDto entidad)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                await _elementoRepository.UpdateAsync(Mapper.Map<Elemento>(entidad));
                return CreateApiResponse(entidad, NotificationsEnum.Success, ResourcesApplication.MsjDatosActualizados);
            });
        }

        public async Task<ApiResponse<IEnumerable<ElementoDto>>> ConsultarLista()
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                IEnumerable<Elemento> query = await _elementoRepository.GetByFilterAsync();
                return CreateApiResponse(Mapper.Map<IEnumerable<ElementoDto>>(query), NotificationsEnum.Success);
            });
        }

        public async Task<ApiResponse<ElementoDto>> Crear(ElementoDto entidad)
        {
            return await ExecuteWithHandlingAsync(async () =>
            { 
                entidad.ElementoId = Guid.NewGuid();
                entidad.UsuarioCreacion = Guid.NewGuid();
                entidad.FechaCreacion = DateTime.UtcNow;
                Elemento elemento = Mapper.Map<Elemento>(entidad);
                Elemento query = await _elementoRepository.CreateAsync(elemento);
                return CreateApiResponse(Mapper.Map<ElementoDto>(elemento), NotificationsEnum.Success, ResourcesApplication.MsjDatosGuardados);
            });
        }

        public async Task<ApiResponse<bool>> Eliminar(string id)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                Elemento? existe = await _elementoRepository.GetByFilter(x => x.ElementoId == Guid.Parse(id));
                if (existe is null)
                    return CreateApiResponse(false, NotificationsEnum.Error, "Registro no encontrado.");

                bool asignadoServicio = await _servicioRepository.GetByFilter(x => x.ElementoId == existe.ElementoId) != null;
                if (asignadoServicio)
                    return CreateApiResponse(false, NotificationsEnum.Error, "Elemento ya asociado a un servicio.");

                await _elementoRepository.DeleteAsync(existe);
                return CreateApiResponse(true, NotificationsEnum.Success, ResourcesApplication.MsjDatosEliminados);
            });
        }
        #endregion

    }
}
