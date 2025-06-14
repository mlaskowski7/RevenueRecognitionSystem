using Microsoft.Extensions.DependencyInjection;
using RevenueRecognitionSystem.Application.Mappers;
using RevenueRecognitionSystem.Application.Mappers.Impl;
using RevenueRecognitionSystem.Application.Services;
using RevenueRecognitionSystem.Application.Services.Impl;
using RevenueRecognitionSystem.Application.Utils;

namespace RevenueRecognitionSystem.Application;

public static class InitializationExtensions
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        return services.AddMappers().AddServices();
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services.AddScoped<IClientService, ClientService>().AddScoped<IDateTimeProvider, DateTimeProvider>();
    }

    private static IServiceCollection AddMappers(this IServiceCollection services)
    {
        return services.AddScoped<IClientMapper, ClientMapper>();
    }
}