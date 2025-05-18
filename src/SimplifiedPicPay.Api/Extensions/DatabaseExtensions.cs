using Microsoft.EntityFrameworkCore;
using SimplifiedPicPay.Api.Data;
using SimplifiedPicPay.Api.Modules.Users.Domain;
using SimplifiedPicPay.Api.Modules.Users.Domain.Enums;

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
        List<User> users = [
            new() {
                FullName = "John Doe",
                Email = "john.doe@email.com",
                Password = "123456789",
                CpfCnpj = "000.000.000-00",
                Type = UserType.Common,
                WalletBalance = 100
            },
            new() {
                FullName = "John Doe II",
                Email = "john.doe2@email.com",
                Password = "123456789",
                CpfCnpj = "000.000.000-01",
                Type = UserType.Common,
                WalletBalance = 100
            },
            new() {
                FullName = "John Doe III",
                Email = "john.doe3@email.com",
                Password = "123456789",
                CpfCnpj = "00.000.000/0000-00",
                Type = UserType.Merchant,
                WalletBalance = 100
            }
        ];

        foreach (var user in users)
        {
            if (!context.Users.Any(u => u.Email == user.Email || u.CpfCnpj == user.CpfCnpj))
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        return app;
    }
}
