using E_CommerceAPI.Application.Abstractions.Hubs;
using E_CommerceAPI.SignalAR.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace E_CommerceAPI.SignalAR.HubService
{
    public class OrderHubService:IOrderHubService
    {
        readonly IHubContext<OrderHub> _hubContext;

        public OrderHubService(IHubContext<OrderHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public async Task OrderAddedMessageAsync(string message)
        {
            await _hubContext.Clients.All.SendAsync(ReceiveFuctionNames.OrderAddedMessage, message);
        }
    }
}
