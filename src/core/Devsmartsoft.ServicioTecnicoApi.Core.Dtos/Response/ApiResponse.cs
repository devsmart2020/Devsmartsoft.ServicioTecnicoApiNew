using Devsmartsoft.ServicioTecnicoApi.Shared.Enums;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response
{
    public sealed class ApiResponse<T>
    {
        public List<T>? Data { get; set; } = new List<T>()!;
        public List<string>? Messages { get; set; } = new List<string>()!;
        public NotificationsEnum NotificationType { get; set; }
    }
}
