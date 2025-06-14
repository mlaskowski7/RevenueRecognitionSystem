using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RevenueRecognitionSystem.Application.Repositories;
using RevenueRecognitionSystem.Infrastructure.Database;
using RevenueRecognitionSystem.Infrastructure.Repositories;

namespace RevenueRecognitionSystem.Infrastructure;

public static class InitializationExtensions
{
    public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddDbContext<RevenuesDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
                             ?? throw new ArgumentException("Default connection string must be set"));
        }).AddRepositories();
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services.AddScoped<IClientRepository, ClientRepository>();
    }
}