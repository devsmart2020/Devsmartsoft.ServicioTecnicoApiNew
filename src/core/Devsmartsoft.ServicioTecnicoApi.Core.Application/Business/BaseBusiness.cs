using AutoMapper;
using Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Shared.Enums;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Application.Business
{
    public abstract class BaseBusiness
    {
        private readonly IMapper _mapper;

        protected BaseBusiness(IMapper mapper)
        {
            _mapper = mapper;
            Mapper = _mapper;
        }

        protected async Task<ApiResponse<T>> ExecuteWithHandlingAsync<T>(Func<Task<ApiResponse<T>>> action)
        {
            try
            {
                return await action();
            }
            catch (Exception ex)
            {
                return CreateApiResponse<T>(default!, NotificationsEnum.Error, "An error occurred.", ex.Message, ex.InnerException!.Message);
            }
        }

        protected ApiResponse<T> CreateApiResponse<T>(T data, NotificationsEnum notificationType, params string[] messages)
        {
            return new ApiResponse<T>
            {
                Data = data != null ? [data] : [],
                Messages = messages.ToList(),
                NotificationType = notificationType
            };
        }

        protected IMapper Mapper { get; private set; }
    }
}
