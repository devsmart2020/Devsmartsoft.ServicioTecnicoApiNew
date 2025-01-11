namespace Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces
{
    public interface IOrderHub
    {
        Task UpdateOrderStatus(int orderId, string status);
    }
}
