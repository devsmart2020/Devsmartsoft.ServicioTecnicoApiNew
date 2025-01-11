namespace Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces
{
    public interface IChatBusiness
    {
        IAsyncEnumerable<string> GetGptStream(string question);
    }
}
