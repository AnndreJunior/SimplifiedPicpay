using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace SimplifiedPicPay.UnitTests;

public abstract class TestWithDb<T> : IDisposable where T : DbContext
{
    private readonly SqliteConnection _connection;
    protected T context;

    protected TestWithDb()
    {
        _connection = new SqliteConnection("DataSource=:memory:");
        _connection.Open();

        var options = new DbContextOptionsBuilder<T>()
            .UseSqlite(_connection)
            .Options;

        context = CreateContext(options);
        context.Database.EnsureCreated();
    }

    protected abstract T CreateContext(DbContextOptions<T> options);

    public void Dispose()
    {
        _connection.Close();
        context.Dispose();
    }
}
