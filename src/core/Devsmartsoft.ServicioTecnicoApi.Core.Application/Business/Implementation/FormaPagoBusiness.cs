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
    public sealed class FormaPagoBusiness : BaseBusiness, IFormaPagoBusiness
    {
        #region Fields
        private readonly IFormaPagoRepository _formaPagoRepository;
        #endregion

        #region Ctor
        public FormaPagoBusiness(IMapper mapper, IFormaPagoRepository formaPagoRepository) : base(mapper)
        {
            _formaPagoRepository = formaPagoRepository;
        }
        #endregion

        #region Methods
        public async Task<ApiResponse<FormaPagoDto>> Actualizar(FormaPagoDto entidad)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                await _formaPagoRepository.UpdateAsync(Mapper.Map<FormaPago>(entidad));
                return CreateApiResponse(entidad, NotificationsEnum.Success, ResourcesApplication.MsjDatosActualizados);
            });
        }

        public async Task<ApiResponse<IEnumerable<FormaPagoDto>>> ConsultarLista()
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                IEnumerable<FormaPago> query = await _formaPagoRepository.GetByFilterAsync();
                return CreateApiResponse(Mapper.Map<IEnumerable<FormaPagoDto>>(query), NotificationsEnum.Success);
            });
        }

        public async Task<ApiResponse<FormaPagoDto>> Crear(FormaPagoDto entidad)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                entidad.FormaPagoId = Guid.NewGuid();
                entidad.UsuarioCreacion = Guid.NewGuid();
                entidad.FechaCreacion = DateTime.UtcNow;
                FormaPago query = await _formaPagoRepository.CreateAsync(Mapper.Map<FormaPago>(entidad));
                return CreateApiResponse(entidad, NotificationsEnum.Success, ResourcesApplication.MsjDatosGuardados);
            });
        }

        public async Task<ApiResponse<bool>> Eliminar(string id)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                FormaPago? existe = await _formaPagoRepository.GetByFilter(x => x.FormaPagoId == Guid.Parse(id));
                if (existe is null)
                    return CreateApiResponse(false, NotificationsEnum.Error, "Registro no encontrado.");

                await _formaPagoRepository.DeleteAsync(existe);
                return CreateApiResponse(true, NotificationsEnum.Success, ResourcesApplication.MsjDatosEliminados);
            });
        }
        #endregion

    }
}
