using Microsoft.AspNetCore.Diagnostics;

using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace E_CommerceAPI.API.Extensions
{
    static public class ConfigureExceptionHandlerExtension
    {
        public static void ConfigureExceptionHandler<T>(this WebApplication application, ILogger<T> _logger)
        {
            application.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = MediaTypeNames.Application.Json;
                    var contextFeatures = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeatures != null)
                    {
                        _logger.LogError(contextFeatures.Error.Message);
                       await context.Response.WriteAsync(JsonSerializer.Serialize(new
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeatures.Error.Message,
                            Title = "Hata alındı!!!"


                        })); 
                    }

                });
            });
        }
    }
}
