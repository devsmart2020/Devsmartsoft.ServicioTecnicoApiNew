using Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Devsmartsoft.ServicioTecnicoApi.Infrastructure.Persistence.Hubs
{
    public sealed class OrderHub : Hub, IOrderHub
    {
        public async Task UpdateOrderStatus(int orderId, string status)
        {
            await Clients.All.SendAsync("ReceiveOrderStatus", orderId, status);
        }

        public override Task OnConnectedAsync()
        {
            Console.WriteLine("Client connected");
            return base.OnConnectedAsync();
        }
    }
}
