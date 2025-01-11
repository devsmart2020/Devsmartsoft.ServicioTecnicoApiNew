namespace Devsmartsoft.ServicioTecnicoApi.Core.Domain.CommonEntities
{
    public sealed class SearchOrderFilter
    {
        public string? SearchText { get; set; }
        public string? ServiceNumber { get; set; }
        public Guid Techinician { get; set; }
        public int State { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
