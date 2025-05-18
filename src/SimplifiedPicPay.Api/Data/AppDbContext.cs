using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SimplifiedPicPay.Api.Modules.Transfers.Domain;
using SimplifiedPicPay.Api.Modules.Users.Domain;

namespace SimplifiedPicPay.Api.Data;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Transfer> Transfers => Set<Transfer>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}
