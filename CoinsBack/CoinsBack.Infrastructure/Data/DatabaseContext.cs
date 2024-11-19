using Npgsql;

namespace CoinsBack.Infrastructure.Data;

public class DatabaseContext : IDisposable
{
    private readonly string _connectionString;

    public DatabaseContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public NpgsqlConnection GetConnection()
    {
        var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        return connection;
    }

    public void Dispose() { }
}
