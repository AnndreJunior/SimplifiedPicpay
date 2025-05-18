using Microsoft.EntityFrameworkCore;
using SimplifiedPicPay.Api.Data;

namespace SimplifiedPicPay.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSwaggerDocs(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }

    public static IServiceCollection AddDataContext(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        string databaseConnection = configuration.GetConnectionString("DatabaseConnection")
            ?? Environment.GetEnvironmentVariable("DATABASE_CONNECTION")
            ?? throw new InvalidOperationException("Database connection not provided");

        services.AddDbContext<AppDbContext>(opts =>
            opts.UseNpgsql(databaseConnection));

        return services;
    }
}
