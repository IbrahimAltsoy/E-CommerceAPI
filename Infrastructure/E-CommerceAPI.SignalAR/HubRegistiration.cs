using E_CommerceAPI.SignalAR.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace E_CommerceAPI.SignalAR
{
    public static class HubRegistiration
    {
        public static void MapHubs(this WebApplication application)
        {
            application.MapHub<ProductHub>("/products-hub");
        }
    }
}
