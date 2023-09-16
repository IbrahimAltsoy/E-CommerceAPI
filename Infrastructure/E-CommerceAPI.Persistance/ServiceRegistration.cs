using E_CommerceAPI.Application.Abstraction;
using E_CommerceAPI.Persistance.Concreate;
using E_CommerceAPI.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace E_CommerceAPI.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<ECommerceDbContext>(options => options.UseSqlServer(Configiration.ConnectingString));
            services.AddScoped<IProductService, ProductService>();

        }
        
        
    }
}
