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
    public sealed class UbicacionBusiness : BaseBusiness, IUbicacionBusiness
    {
        #region Fields
        private readonly IUbicacionRepository _ubicacionRepository;
        #endregion

        #region Ctor
        public UbicacionBusiness(IMapper mapper, IUbicacionRepository ubicacionRepository) : base(mapper)
        {
            _ubicacionRepository = ubicacionRepository;
        }
        #endregion

        #region Methods
        public async Task<ApiResponse<UbicacionDto>> Actualizar(UbicacionDto entidad)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {

                await _ubicacionRepository.UpdateAsync(Mapper.Map<Ubicacion>(entidad));
                return CreateApiResponse(entidad, NotificationsEnum.Success, ResourcesApplication.MsjDatosActualizados);
            });
        }

        public async Task<ApiResponse<IEnumerable<UbicacionDto>>> ConsultarLista()
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                IEnumerable<Ubicacion> query = await _ubicacionRepository.GetByFilterAsync();
                return CreateApiResponse(Mapper.Map<IEnumerable<UbicacionDto>>(query), NotificationsEnum.Success);
            });
        }

        public async Task<ApiResponse<UbicacionDto>> Crear(UbicacionDto entidad)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                Ubicacion? ubicacionExiste = await _ubicacionRepository.GetByFilter(x=> x.ClienteId == entidad.ClienteId);
                if(ubicacionExiste != null)
                {
                    entidad.Id = ubicacionExiste.Id;     
                    entidad.FechaActualizacion = DateTime.Now;
                    entidad.Estado = true;
                    return await Actualizar(entidad);
                }                               
                entidad.UsuarioCreacion = Guid.NewGuid();
                entidad.Estado = true;
                entidad.FechaCreacion = DateTime.Now;
                Ubicacion ubicacionSave = Mapper.Map<Ubicacion>(entidad);
                Ubicacion query = await _ubicacionRepository.CreateAsync(ubicacionSave);
                return CreateApiResponse(Mapper.Map<UbicacionDto>(ubicacionSave), NotificationsEnum.Success, ResourcesApplication.MsjDatosGuardados);             
            });
        }

        public async Task<ApiResponse<bool>> Eliminar(string id)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                Ubicacion? existe = await _ubicacionRepository.GetByFilter(x => x.Id == int.Parse(id));
                if (existe is null)
                    return CreateApiResponse(false, NotificationsEnum.Error, "Registro no encontrado.");

                await _ubicacionRepository.DeleteAsync(existe);
                return CreateApiResponse(true, NotificationsEnum.Success, ResourcesApplication.MsjDatosEliminados);
            });
        }

        public async Task<ApiResponse<IEnumerable<UbicacionDto>>> ObtenerPorCliente(Guid id)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                IEnumerable<Ubicacion>? query = await _ubicacionRepository.GetByFilterAsync(x => x.ClienteId == id);
                IEnumerable<UbicacionDto>? data = Mapper.Map<IEnumerable<UbicacionDto>>(query);
                return CreateApiResponse(data, NotificationsEnum.Success);
            });
        }
        #endregion

    }
}
