using Calc;
using Npgsql;
using Testcontainers.PostgreSql;

namespace Calc.IntegrationTests;

[Trait("Category", "Integration")]
public class PostgresTests : IAsyncLifetime
{
    private readonly PostgreSqlContainer _db = new PostgreSqlBuilder("postgres:17-alpine").Build();

    public Task InitializeAsync() => _db.StartAsync();

    public Task DisposeAsync() => _db.DisposeAsync().AsTask();

    [Fact]
    public async Task Add_MatchesDatabase()
    {
        await using var conn = new NpgsqlConnection(_db.GetConnectionString());
        await conn.OpenAsync();
        await using var cmd = new NpgsqlCommand("SELECT 2 + 3", conn);

        Assert.Equal(Calculator.Add(2, 3), (int)(await cmd.ExecuteScalarAsync())!);
    }
}
