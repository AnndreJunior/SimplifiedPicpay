using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace SimplifiedPicPay.Api.Data;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}
