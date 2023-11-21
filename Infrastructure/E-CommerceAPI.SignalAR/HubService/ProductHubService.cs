using E_CommerceAPI.Application.Abstractions.Hubs;
using E_CommerceAPI.SignalAR.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace E_CommerceAPI.SignalAR.HubService
{
    public class ProductHubService : IProductHubService
    {
        readonly IHubContext<ProductHub> _hubContext;

        public ProductHubService(IHubContext<ProductHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task ProductAddedMessageAsync(string message)
        {
            await _hubContext.Clients.All.SendAsync(ReceiveFuctionNames.ProductAddedMessage, message);
        }
    }
}
