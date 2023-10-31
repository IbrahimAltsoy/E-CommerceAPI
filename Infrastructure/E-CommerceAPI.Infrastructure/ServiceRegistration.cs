using E_CommerceAPI.Application.Abstractions.Storage;
using E_CommerceAPI.Application.Services;
using E_CommerceAPI.Infrastructure.Enums;
using E_CommerceAPI.Infrastructure.Services;
using E_CommerceAPI.Infrastructure.Services.Stroage;
using E_CommerceAPI.Infrastructure.Services.Stroage.Local;
using Microsoft.Extensions.DependencyInjection;

namespace E_CommerceAPI.Infrastructure
{
    public static class ServiceRegistration
    {      
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            //serviceCollection.AddScoped<IFileService, FileService>();
            serviceCollection.AddScoped<IStorageService, StorageService>();
        }
        public static void AddStroage<T>(this IServiceCollection serviceCollection) where T : class, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }
        public static void AddStroage(this IServiceCollection serviceCollection, StroageType stroageType)
        {
            switch (stroageType)
            {
                case StroageType.Local:
                    serviceCollection.AddScoped<IStorage, LocalStroage>();
                    break;
                case StroageType.Aws:
                    break;
                case StroageType.Azure:
                    break;
                default:
                    serviceCollection.AddScoped<IStorage, LocalStroage>();
                    break;
            }
        }
    }
}