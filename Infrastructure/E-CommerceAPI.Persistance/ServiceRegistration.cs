using E_CommerceAPI.Application.Abstraction;
using E_CommerceAPI.Persistance.Concreate;
using Microsoft.Extensions.DependencyInjection;

namespace E_CommerceAPI.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddSingleton<IProductService, ProductService>();
        }
    }
}
