using Microsoft.AspNetCore.Diagnostics;
using NLayer.Core.DTOs;
using NLayer.Service.Exceptions;
using System.Text.Json;

namespace NLayer.API.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    IExceptionHandlerFeature? exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    int statusCode = exceptionFeature.Error switch
                    {
                        NotFoundException => 404,
                        ClientSideException => 400,

                        _ => 500
                    };
                    context.Response.StatusCode = statusCode;
                    CustomResponseDto<NoContentDto>? response = CustomResponseDto<NoContentDto>.Fail(statusCode, exceptionFeature.Error.Message);
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}
