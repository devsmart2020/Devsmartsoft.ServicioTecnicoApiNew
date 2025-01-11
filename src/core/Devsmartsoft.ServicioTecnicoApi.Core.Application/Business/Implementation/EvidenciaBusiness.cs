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
    public sealed class EvidenciaBusiness : BaseBusiness, IEvidenciaBusiness
    {
        #region Fields
        private readonly IEvidenciaRepository _evidenciaRepository;
        #endregion

        #region Ctor
        public EvidenciaBusiness(IMapper mapper, IEvidenciaRepository evidenciaRepository) : base(mapper)
        {
            _evidenciaRepository = evidenciaRepository;
        }
        #endregion

        #region Methods
        public async Task<ApiResponse<EvidenciaDto>> Actualizar(EvidenciaDto entidad)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                await _evidenciaRepository.UpdateAsync(Mapper.Map<Evidencia>(entidad));
                return CreateApiResponse(entidad, NotificationsEnum.Success, ResourcesApplication.MsjDatosActualizados);
            });
        }

        public async Task<ApiResponse<IEnumerable<EvidenciaDto>>> ConsultarLista()
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                IEnumerable<Evidencia> query = await _evidenciaRepository.GetByFilterAsync();
                return CreateApiResponse(Mapper.Map<IEnumerable<EvidenciaDto>>(query), NotificationsEnum.Success);
            });
        }

        public async Task<ApiResponse<EvidenciaDto>> Crear(EvidenciaDto entidad)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                entidad.EvidenciaId = Guid.NewGuid();
                entidad.UsuarioCreacion = Guid.NewGuid();
                entidad.FechaCreacion = DateTime.UtcNow;
                Evidencia query = await _evidenciaRepository.CreateAsync(Mapper.Map<Evidencia>(entidad));
                return CreateApiResponse(entidad, NotificationsEnum.Success, ResourcesApplication.MsjDatosGuardados);
            });
        }

        public async Task<ApiResponse<bool>> Eliminar(string id)
        {
            return await ExecuteWithHandlingAsync(async () =>
            {
                Evidencia? existe = await _evidenciaRepository.GetByFilter(x => x.EvidenciaId == Guid.Parse(id));
                if (existe is null)
                    return CreateApiResponse(false, NotificationsEnum.Error, "Registro no encontrado.");

                await _evidenciaRepository.DeleteAsync(existe);
                return CreateApiResponse(true, NotificationsEnum.Success, ResourcesApplication.MsjDatosEliminados);
            });
        }
        #endregion

    }
}
