namespace Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Request
{
    public sealed class ChatFileRequestDto
    {
        public Stream FileStream { get; set; } = null!;
        public string? FileName { get; set; }
    }
}
