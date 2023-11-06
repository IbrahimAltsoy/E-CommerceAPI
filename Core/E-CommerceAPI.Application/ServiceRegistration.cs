using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace E_CommerceAPI.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services )
        {
           services.AddMediatR(typeof(ServiceRegistration));
        }
    }
}
