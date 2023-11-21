using E_CommerceAPI.Application.Abstractions.Hubs;
using E_CommerceAPI.SignalAR.HubService;
using Microsoft.Extensions.DependencyInjection;

namespace E_CommerceAPI.SignalAR
{
    public static class ServiceRegistrationsSignalR
    {
        public static void AddServiceRegistrationSignalR(this IServiceCollection services)
        {
            services.AddTransient<IProductHubService, ProductHubService>();
            services.AddSignalR();
        }
    }
}
