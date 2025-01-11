namespace Devsmartsoft.ServicioTecnicoApi.Core.Domain.RepositoryInterfaces
{
    public interface IOrderUpdateService
    {
        Task UpdateOrderStatusAsync(int orderId, string status);
    }
}
