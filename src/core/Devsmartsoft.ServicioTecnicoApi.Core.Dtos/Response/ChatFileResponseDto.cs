namespace Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response
{
    public sealed class ChatFileResponseDto
    {
        public string TextFile { get; set; } = string.Empty!;
        public string Extension { get; set; } = string.Empty!;
        public string FileName { get; set; } = string.Empty!;
    }
}
