using CoinsBack.Core.Entities;
using CoinsBack.Core.Interfaces;
using CoinsBack.Infrastructure.Data;
using Npgsql;

namespace CoinsBack.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DatabaseContext _context;

    public UserRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<List<UserEntity>> GetAllAsync()
    {
        var users = new List<UserEntity>();

        using var connection = _context.GetConnection();
        using var command = new NpgsqlCommand("SELECT id, name, created_at FROM my_table", connection);

        using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            users.Add(new UserEntity
            {
                Nombre = reader.GetString(0),
                Telefono = reader.GetString(1),
                Direccion = reader.GetString(2)
            });
        }

        return users;
    }
}
