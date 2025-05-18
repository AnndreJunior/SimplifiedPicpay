using Microsoft.EntityFrameworkCore;
using SimplifiedPicPay.Api.Data;

namespace SimplifiedPicPay.Api.Extensions;

public static class DatabaseExtensions
{
    public static WebApplication ApplyMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        context.Database.Migrate();

        return app;
    }

    public static WebApplication SeedData(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        // seed database bellow

        return app;
    }
}
