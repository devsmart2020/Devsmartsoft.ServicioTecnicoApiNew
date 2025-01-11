namespace Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Common
{
    public sealed class SearchOrderFilterDto
    {
        public string? SearchText { get; set; }       
        public string? ServiceNumber { get; set; }
        public Guid Techinician { get; set; }
        public int State { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
