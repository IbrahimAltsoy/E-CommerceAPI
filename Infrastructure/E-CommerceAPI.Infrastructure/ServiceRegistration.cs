using E_CommerceAPI.Application.Services;
using E_CommerceAPI.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace E_CommerceAPI.Infrastructure
{
    public static class ServiceRegistration
    {      
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IFileService, FileService>();
        }
    }
}
