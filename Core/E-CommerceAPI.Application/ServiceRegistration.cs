using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace E_CommerceAPI.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services )
        {
            
            services.AddMediatR(typeof(ServiceRegistration));
         
            services.AddHttpClient();
            
        }
    }
}
