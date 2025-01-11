using Devsmartsoft.ServicioTecnicoApi.Core.Domain.RepositoryInterfaces;
using Devsmartsoft.ServicioTecnicoApi.Infrastructure.Persistence.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Devsmartsoft.ServicioTecnicoApi.Infrastructure.Persistence.Services
{
    public sealed class OrderUpdateService : IOrderUpdateService
    {
        private readonly IHubContext<OrderHub> _hubContext;

        public OrderUpdateService(IHubContext<OrderHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task UpdateOrderStatusAsync(int orderId, string status)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveOrderStatus", orderId, status);
        }
    }
}
