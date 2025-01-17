namespace Devsmartsoft.ServicioTecnicoApi.Core.Domain.RepositoryInterfaces
{
    public interface IClientGpt
    {
        IAsyncEnumerable<string> SendQuestionStream(string question);       
    }
}
