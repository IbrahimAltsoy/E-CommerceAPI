using E_CommerceAPI.Application.Abstractions.Services;
using E_CommerceAPI.Application.Abstractions.Services.Authencations;
using E_CommerceAPI.Application.Repositories;
using E_CommerceAPI.Application.Repositories.Basket;
using E_CommerceAPI.Application.Repositories.BasketItem;
using E_CommerceAPI.Application.Repositories.File;
using E_CommerceAPI.Application.Repositories.InvoiceFile;
using E_CommerceAPI.Application.Repositories.ProductImage;
using E_CommerceAPI.Domain.Entities.Identity;
using E_CommerceAPI.Persistance.Contexts;
using E_CommerceAPI.Persistance.Repositories;
using E_CommerceAPI.Persistance.Repositories.Basket;
using E_CommerceAPI.Persistance.Repositories.BasketItem;
using E_CommerceAPI.Persistance.Repositories.File;
using E_CommerceAPI.Persistance.Repositories.InvoiceFile;
using E_CommerceAPI.Persistance.Repositories.ProductImage;
using E_CommerceAPI.Persistance.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace E_CommerceAPI.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<ECommerceDbContext>(options => options.UseSqlServer(Configiration.ConnectingString));

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit=false;
                options.Password.RequireLowercase=false;
                options.Password.RequireUppercase=false;

            }).AddEntityFrameworkStores<ECommerceDbContext>();

            //services.AddHttpClient();
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
            services.AddScoped<IBasketReadRepository, BasketReadRepository>();
            services.AddScoped<IBasketWriteRepository, BasketWriteRepository>();
            services.AddScoped<IBasketItemReadRepository, BasketItemReadRepository>();
            services.AddScoped<IBasketItemWriteRepository, BasketItemWriteRepository>();


            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IInternalAuthencation, AuthService>();
            services.AddScoped<IExternalAuthencation, AuthService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IOrderService,OrderService>();
          


        }
        
        
    }
}
