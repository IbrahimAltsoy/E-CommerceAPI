using E_CommerceAPI.Application.Abstraction;
using E_CommerceAPI.Application.Repositories;
using E_CommerceAPI.Application.Repositories.File;
using E_CommerceAPI.Application.Repositories.InvoiceFile;
using E_CommerceAPI.Application.Repositories.ProductImage;
using E_CommerceAPI.Persistance.Concreate;
using E_CommerceAPI.Persistance.Contexts;
using E_CommerceAPI.Persistance.Repositories;
using E_CommerceAPI.Persistance.Repositories.File;
using E_CommerceAPI.Persistance.Repositories.InvoiceFile;
using E_CommerceAPI.Persistance.Repositories.ProductImage;
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

            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            services.AddScoped<IFileReadRepository, FileReadRepository>();
            services.AddScoped<IFileWriteRepository, FileWriteRepository>();
            services.AddScoped<IProductImageReadRepository, ProductImageReadRepository>();
            services.AddScoped<IProductImageWriteRepository, ProductImageWriteRepository>();
            services.AddScoped<IInvoiceFileReadRepository, InvoiceFileReadRepository>();
            services.AddScoped<IInvoiceFileWriteRepository, InvoiceFileWriteRepository>();



        }
        
        
    }
}
